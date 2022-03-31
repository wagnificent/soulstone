using UnityEngine;

public class PlayerSettings : MonoBehaviour
{

    public void SelectCharacter(int saveSlot)
    {
        PlayerPrefs.SetInt("selectedCharacter", saveSlot);
        PlayerPrefs.Save();
        Debug.Log("You have selected custom character " + (saveSlot));
    }

    public void SelectTeamSize(int teamSize)
    {
        PlayerPrefs.SetInt("TeamSize", teamSize);
        PlayerPrefs.Save();
        Debug.Log("You have selected to play with teams of " + teamSize);
    }
}
