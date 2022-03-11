using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{

    public GameObject firstSelected;
    public bool isParentToggle;
    public int skillIndex;
    public int skillLevel;
    public GameObject parentPanel;

    private SkillTrainer skillTrainer;
    private Button button;

    private void Awake()
    {
        skillTrainer = FindObjectOfType<SkillTrainer>();
        button = GetComponent<Button>();
        button.onClick.AddListener(TryTrainSkill);
    }

    public void TryTrainSkill()
    {
        if (skillTrainer.TrainSkill(skillIndex, skillLevel))
        {
            EventSystem.current.SetSelectedGameObject(firstSelected);
            if (isParentToggle) { parentPanel.SetActive(false); }
        }
    }

    
}
