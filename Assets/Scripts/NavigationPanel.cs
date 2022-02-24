using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPanel : MonoBehaviour
{
    /*
    public RectTransform IdentityPanel;
    public RectTransform AttributePanel;
    public RectTransform SkillPanel;
    public RectTransform AbilityPanel;
    public RectTransform EquipmentPanel;
    */

    public GameObject[] Tabs;

    public void ChangeTab(GameObject targetTab)
    {
        foreach(GameObject tab in Tabs)
        {
            if (tab != targetTab)
            {
                tab.SetActive(false);
            }
            else
            {
                tab.SetActive(true);
            }
        }
    }

}
