﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Wagnificent.CharacterStats
{
    [Serializable]
    public class CharacterStat
    {
        public int BaseValue;

        protected bool isDirty = true;
        protected int _value;
        protected int lastBaseValue = int.MinValue;
        protected readonly List<StatModifier> statModifiers;

        public ReadOnlyCollection<StatModifier> StatModifiers;

        public virtual int Value
        {
            get
            {
                if (isDirty || BaseValue != lastBaseValue)
                {
                    lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    isDirty = false;
                }
                return _value;
            }
        }

        public CharacterStat()
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }

        public CharacterStat(int baseValue) : this()
        {
            BaseValue = baseValue;
        }

        public virtual void AddModifier(StatModifier mod)
        {
            isDirty = true;
            statModifiers.Add(mod);
            statModifiers.Sort(CompareModifierOrder);
        }

        protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            if (a.Order < b.Order)
            {
                return -1;
            }
            else if (a.Order > b.Order)
            {
                return 1;
            }
            return 0;
        }

        public virtual bool RemoveModifier(StatModifier mod)
        {
            if (statModifiers.Remove(mod))
            {
                isDirty = true;
                return true;
            }
            return false;
        }

        public virtual bool RemoveAllModifiersFromSource(object source)
        {

            bool didRemove = false;

            for (int i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (statModifiers[i].Source == source)
                {
                    isDirty = true;
                    didRemove = true;
                    statModifiers.RemoveAt(i);
                }
            }

            return didRemove;
        }

        public virtual int CalculateFinalValue()
        {
            int finalValue = BaseValue;
            int sumPercentAdd = 0;

            for (int i = 0; i < statModifiers.Count; i++)
            {
                StatModifier mod = statModifiers[i];
                if (mod.Type == StatModType.FLAT)
                {
                    finalValue += statModifiers[i].Value;
                }
                else if (mod.Type == StatModType.PERCENTADD)
                {
                    sumPercentAdd += mod.Value;
                    if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PERCENTADD)
                    {
                        finalValue *= (1 + sumPercentAdd);
                        sumPercentAdd = 0;
                    }

                }
                else if (mod.Type == StatModType.PERCENTMULT)
                {
                    finalValue *= 1 + mod.Value;
                }
            }
            return finalValue;
        }

    }
}
