using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHandler : MonoBehaviour
{
    public int TeamCount;
    public int TeamSize;
    public int PlayerCount = 1;
    public Transform[] TeamBase;
    public GameObject SoulStonePrefab;
    public GameObject PlayerPrefab;
    public GameObject BotPrefab;

    private int[] currentTeamSize;
    private int teamsRemaining;
    private SceneChanger sceneChanger;
    private SaveHandler saveHandler;

    void Start()
    {
        sceneChanger = FindObjectOfType<SceneChanger>();
        saveHandler = FindObjectOfType<SaveHandler>();
        int teamSizer = PlayerPrefs.GetInt("TeamSize");
        TeamSize = teamSizer;
        currentTeamSize = new int[TeamCount];
        CreateTeams();
    }

    public void UpdateTeam(int teamID)
    {
        currentTeamSize[teamID]--;

        if (currentTeamSize[teamID] <= 0)
        {
            teamsRemaining--;
            CheckWinCondition();
        }
    }

    private void CheckWinCondition()
    {
        if (teamsRemaining == 1)
        {
            sceneChanger.ChangeScene("Victory");
        }
        //ChangeScene("Defeat");
    }



    private void CreateTeams()
    {
        for (int i = 0; i < TeamCount; i++)
        {
            GameObject soulStone = Instantiate(SoulStonePrefab, TeamBase[i].position, Quaternion.identity);
            soulStone.GetComponent<Destructible>().TeamID = i;
            teamsRemaining++;
            PopulateTeam(soulStone);
        }
    }

    private void PopulateTeam(GameObject teamSoulStone)
    {
        int teamID = teamSoulStone.GetComponent<Destructible>().TeamID;
        currentTeamSize[teamID] = 0;

        for (int i = 0; i < TeamSize; i++)
        {

            if (PlayerCount > 0)
            {
                GameObject Combatant = Instantiate(PlayerPrefab, teamSoulStone.GetComponent<SoulStone>().SpawnPoint[i].position, Quaternion.identity);
                Combatant.GetComponent<Destructible>().TeamID = teamID;
                Combatant.GetComponent<Player>().SoulStone = teamSoulStone;
                int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
                saveHandler.LoadCharacter(Combatant.GetComponent<Character>(), (selectedCharacter));
                PlayerCount--;
            }
            else
            {
                GameObject Combatant = Instantiate(BotPrefab, teamSoulStone.GetComponent<SoulStone>().SpawnPoint[i].position, Quaternion.identity);
                Combatant.GetComponent<Destructible>().TeamID = teamID;
                Combatant.GetComponent<Bot>().SoulStone = teamSoulStone;
            }

            currentTeamSize[teamID]++;
        }
    }
}
