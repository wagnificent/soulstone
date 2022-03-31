using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public int skillIndex;
    public int skillLevel;

    private Button button;
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(TryTrainSkill);
    }

    public void TryTrainSkill()
    {
        uiManager.TryTrainSkill(skillIndex, skillLevel);
    }
}
