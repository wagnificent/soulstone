using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wagnificent.CharacterStats;

public class CombatHandler : MonoBehaviour
{

    public bool DidDefend(float attackSkill, float defendSkill)
    {
        float defendChance = defendSkill / (attackSkill + defendSkill);
        int roll = Random.Range(0, 100) / 100;
        if(defendChance >= roll)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
