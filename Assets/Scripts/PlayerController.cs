using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed;

    private Player myPlayer;


    void Start()
    {
        myPlayer = GetComponent<Player>();
    }

    void Update()
    {
        PlayerMovement();
        CheckInput();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

    void CheckInput()
    {
        if (Input.GetMouseButton(0))
        {
            myPlayer.PrimeAbility(0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            myPlayer.ExecuteAbility();
        }

        if (Input.GetMouseButtonDown(1))
        {
            myPlayer.ClearTarget();
        }
    }

    public void UpdateSpeed(float value)
    {
        Speed = value;
    }
}
