using System.Collections.Generic;

[System.Serializable]
public class SavedCharacter
{
    //Identity
    public int Race;

    //Attributes
    public int[] Attributes = new int[5];

    //Skills
    public int[] Skills = new int[12];

    //Equipment
    public int[] Equipment = new int[6];

    //Abilities
    public List<int> PrimaryAbilities;
    public List<int> AlternateAbilities;

}
