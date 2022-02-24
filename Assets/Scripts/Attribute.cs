namespace Wagnificent.CharacterStats
{
    [System.Serializable]
    public class Attribute : CharacterStat
    {

        public float RacialBonus;
        public float AllocationBonus;

        public Attribute (float defaultValue)
        {
            BaseValue = defaultValue;
        }
    }
}
