using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] TitleMenus;
    public GameObject[] CCMenus;

    void Awake()
    {
        //ActivateTitleMenus();
        //ActivateCCMenus();
    }

    private void ActivateTitleMenus()
    {
        for (int i = 0; i < TitleMenus.Length; i++)
        {
            if (i < 2)
            {
                TitleMenus[i].SetActive(true);
            }
            else
            {
                TitleMenus[i].SetActive(false);
            }
        }
    }

    private void ActivateCCMenus()
    {
        for (int i = 0; i < CCMenus.Length; i++)
        {
            if (i == 1 || i == 3)
            {
                CCMenus[i].SetActive(true);
            }
            else
            {
                CCMenus[i].SetActive(false);
            }
        }
    }
}
