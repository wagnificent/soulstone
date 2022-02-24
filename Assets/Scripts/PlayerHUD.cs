using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{

    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider energyBar;
    [SerializeField] public Image targetMarker;

    [SerializeField] private Player myPlayer;


    void Start()
    {
        //myPlayer = GetComponent<Player>();
    }

    public void UpdateVitals()
    {
        healthBar.value = myPlayer.currentHealth;
        energyBar.value = myPlayer.currentEnergy;
    }

    public void UpdateTargetMarker(Vector3 position, Color color)
    {
        targetMarker.rectTransform.position = position;
        targetMarker.color = color;
    }

    public void ToggleTargetMarker(bool toggle)
    {
        targetMarker.enabled = toggle;
    }

    public bool CheckTargetMarker()
    {
        return targetMarker.enabled;
    }

}
