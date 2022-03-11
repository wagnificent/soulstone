using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetingSystem : MonoBehaviour
{
    
    public GameObject currentTarget;

    private Vector3 targetScreenPosition;
    private float distanceToPlayer;

    private Player myPlayer;
    private PlayerHUD myHUD;

    void Start()
    {
        myPlayer = GetComponent<Player>();
        myHUD = GetComponent<PlayerHUD>();
    }

    void Update()
    {
        if (currentTarget)
        {
            UpdateTargetUI();
        }
        if (!currentTarget && myHUD.CheckTargetMarker())
        {
            myHUD.ToggleTargetMarker(false);
        }
    }

    public void SelectTarget()
    {
        Vector3 pos = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.GetComponent<Destructible>())
            {
                currentTarget = hit.collider.gameObject;
            }
        }
    }

    private void UpdateTargetUI()
    {
        if (!currentTarget.gameObject.activeInHierarchy)
        {
            myHUD.ToggleTargetMarker(false);
            currentTarget = null;
            return;
        }

        myHUD.targetMarker.enabled = true;

        // Get 2D screen position of target
        targetScreenPosition = Camera.main.WorldToScreenPoint(currentTarget.transform.position);

        if(currentTarget.GetComponent<Destructible>().TeamID == this.GetComponent<Destructible>().TeamID)
        {
            myHUD.UpdateTargetMarker(targetScreenPosition, Color.green);
        } 
        else
        {
            myHUD.UpdateTargetMarker(targetScreenPosition, Color.red);
        }

        //Adjust size of target marker to match target size on screen

    }
}
