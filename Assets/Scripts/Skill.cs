namespace Wagnificent.CharacterStats
{

    [System.Serializable]
    public class Skill : CharacterStat
    {

        public int TrainingBonus;
        public int SkillLevel;

        public Skill()
        {
            BaseValue = 100;
        }
    }
}
