namespace Wagnificent.CharacterStats
{
    [System.Serializable]
    public class Attribute : CharacterStat
    {

        public int DefaultValue = 100; 
        public int RacialBonus = 0;
        public int AllocationBonus = 0;
        
        public Attribute ()
        {
            BaseValue = DefaultValue;
        }

        public void AddBonuses()
        {
            BaseValue = (DefaultValue + RacialBonus + AllocationBonus);
        }
    }
}
