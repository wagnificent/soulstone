using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Wagnificent.CharacterStats;

public class UIManager : MonoBehaviour
{
    private CharacterCreator characterCreator;
    private MasterList masterList;

    public GameObject TitlePanel;
    public GameObject[] TitlePanels;
    public GameObject CharacterEditorPanel;
    public GameObject[] CharacterPanels;

    //Stats Panel
    public Text CharacterName;
    public Text[] AttributesPreview = new Text[5];

    //Identity Panel
    public Image[] RaceButtons = new Image[6];

    //Attribute Panel
    public Text AttributePointBalance;
    public Slider[] AttributeSliders = new Slider[5];
    public Text[] AllocationBonuses = new Text[5];

    //Skills Panel
    public Text SkillPointTracker;
    public GameObject[] TrainingPanels;
    public GameObject[] SkillIcons;

    //Equipment Panel
    public Text[] EquipmentNames;

    public GameObject EquipmentButtonPrefab;
    public GameObject EquipmentBankPanel;

    private List<GameObject> equipmentButtons = new List<GameObject>();

    //Abilities Panel
    public Text[] AbilityNames;

    public GameObject AbilityButtonPrefab;
    public GameObject AbilityBankPanel;

    private List<GameObject> abilityButtons = new List<GameObject>();



    void Start()
    {
        characterCreator = FindObjectOfType<CharacterCreator>();
        masterList = FindObjectOfType<MasterList>();
        OpenTitleMenu();
        AddAbilityButtons();
        AddEquipmentButtons();
    }

    public void OpenTitleMenu()
    {
        CharacterEditorPanel.SetActive(false);
        TitlePanel.SetActive(true);
        OpenTitlePanel("Root Navigation");
    }

    public void OpenTitlePanel(string PanelName)
    {
        for (int i = 0; i < TitlePanels.Length; i++)
        {
            UIPanel p = TitlePanels[i].GetComponent<UIPanel>();

            if(TitlePanels[i].name == PanelName)
            { 
                TitlePanels[i].SetActive(true);
                EventSystem.current.SetSelectedGameObject(p.firstSelected); 
            }
            else 
            { 
                TitlePanels[i].SetActive(false); 
            }
        }
    }

    public void OpenCharacterEditor()
    {
        TitlePanel.SetActive(false);
        CharacterEditorPanel.SetActive(true);
        OpenCharacterPanel("Identity Panel");
    }

    public void OpenCharacterPanel(string PanelName)
    {
        for (int i = 0; i < CharacterPanels.Length; i++)
        {
            UIPanel p = CharacterPanels[i].GetComponent<UIPanel>();

            if (CharacterPanels[i].name == PanelName)
            {
                CharacterPanels[i].SetActive(true);
                EventSystem.current.SetSelectedGameObject(p.firstSelected);
            }
            else
            {
                CharacterPanels[i].SetActive(false);
            }
        }
    }

    public void UpdateIdentityUI(Character c)
    {
        int currentRace = (int)c.Race;
        for (int i = 0; i < RaceButtons.Length; i++)
        {
            if (i == currentRace)
            {
                RaceButtons[i].color = Color.green;
            }
            else
            {
                RaceButtons[i].color = Color.white;
            }
        }

        for (int i = 0; i < c.Attributes.Length; i++)
        {
            int previewValue = c.Attributes[i].BaseValue + c.Attributes[i].RacialBonus + c.Attributes[i].AllocationBonus;
            AttributesPreview[i].text = previewValue.ToString();
        }

    }

    public void UpdateAttributeUI(Attribute a, int index, int balance)
    {   
        AttributeSliders[index].value = a.AllocationBonus;
        AllocationBonuses[index].text = a.AllocationBonus.ToString();

        int i = a.BaseValue + a.RacialBonus + a.AllocationBonus;
        AttributesPreview[index].text = i.ToString();

        AttributePointBalance.text = balance.ToString();
    }

    public void TryModAttribute(int index)
    {
        int value = (int)AttributeSliders[index].value;
        characterCreator.ModAttribute(index, value);
    }

    public void TryTrainSkill(int index, int level)
    {
        characterCreator.TrainSkill(index, level);
    }

    public void UpdateSkillUI(int index, int level, int balance)
    {
        SkillIcons[index].transform.SetParent(TrainingPanels[level].transform);
        SkillPointTracker.text = balance.ToString();
        OpenCharacterPanel("Skills Panel");
    }

    public void AddAbilityButtons()
    {
        for (int i = 0; i < masterList.Abilities.Count; i++)
        {
            GameObject abilityButton = Instantiate(AbilityButtonPrefab, AbilityBankPanel.transform);

            AbilityButton b = abilityButton.GetComponent<AbilityButton>();
            b.abilityID = masterList.Abilities[i].AbilityID;

            Text t = abilityButton.GetComponentInChildren<Text>();
            t.text = masterList.Abilities[i].Name;

            abilityButtons.Add(abilityButton);
        }
    }

    public void TryEquipAbility(int id, int index, bool isPrimary)
    {
        characterCreator.EquipAbility(id, index, isPrimary);
        OpenCharacterPanel("Abilities Panel");
    }

    public void UpdateAbilitiesUI(Ability a, int slot)
    {
        if(a == null) 
        { 
            AbilityNames[slot].text = "<Empty>"; 
        }
        else 
        { 
            AbilityNames[slot].text = a.Name; 
        }
    }

    public void OpenAbilityBank(int slotIndex, bool isPrimary)
    {
        //Set each button to match the slotindex and the bool
        foreach (GameObject button in abilityButtons)
        {
            AbilityButton a = button.GetComponent<AbilityButton>();
            a.abilityIndex = slotIndex;
            a.isPrimary = isPrimary;
        }
        
        //Filter the abilities based on character's skills and equipment
        OpenCharacterPanel("Ability Bank");
    }

    public void TogglePrimarySlots(bool b)
    {
        AbilitySlot[] abilitySlots = FindObjectsOfType<AbilitySlot>();
        foreach(AbilitySlot a in abilitySlots)
        {
            a.IsPrimary = b;
        }
        for(int i = 0; i < characterCreator.character.PrimaryAbilities.Length; i++)
        {
            if (b)
            {
                UpdateAbilitiesUI(characterCreator.character.PrimaryAbilities[i], i);
            }
            else
            {
                UpdateAbilitiesUI(characterCreator.character.AlternateAbilities[i], i);
            }
        }
    }

    public void AddEquipmentButtons()
    {
        for (int i = 0; i < masterList.Equipment.Count; i++)
        {
            GameObject equipmentButton = Instantiate(EquipmentButtonPrefab, EquipmentBankPanel.transform);

            EquipmentButton b = equipmentButton.GetComponent<EquipmentButton>();
            b.EquipmentType = (int)masterList.Equipment[i].type;
            b.ID = masterList.Equipment[i].ID;

            Text t = equipmentButton.GetComponentInChildren<Text>();
            t.text = masterList.Equipment[i].Name;

            equipmentButtons.Add(equipmentButton);
        }
    }

    public void OpenEquipmentBank(int equipmentType, int slot)
    {
        foreach(GameObject button in equipmentButtons)
        {
            EquipmentButton e = button.GetComponent<EquipmentButton>();

            if(e.EquipmentType == equipmentType)
            {
                button.SetActive(true);
                e.Slot = slot;
            }
            else
            {
                button.SetActive(false);
            }
        }
        OpenCharacterPanel("Equipment Bank");
    }

    public void TryEquipItem(int type, int id, int slot)
    {
        characterCreator.EquipItem(type, id, slot);
        OpenCharacterPanel("Equipment Panel");
    }

    public void UpdateEquipmentUI(Equipment e, int slot)
    {
        if(e == null)
        {
            EquipmentNames[slot].text = "<Empty>";
        }
        else
        {
            EquipmentNames[slot].text = e.Name;
        }
    }
}
