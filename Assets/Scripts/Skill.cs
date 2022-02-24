namespace Wagnificent.CharacterStats
{

    [System.Serializable]
    public class Skill : CharacterStat
    {

        public float TrainingBonus;
        public int SkillLevel;

        public Skill(float defaultValue)
        {
            BaseValue = defaultValue;
        }
    }
}
