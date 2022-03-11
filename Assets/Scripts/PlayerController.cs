using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float lookSensitivity = 1;
    public Transform Player, Target;

    private Player myPlayer;
    private Rigidbody playerRigidbody;
    private Camera myCamera;
    private float mouseX, mouseY;

    PlayerInputs playerInputs;

    private void Awake()
    {
        myPlayer = GetComponent<Player>();
        playerRigidbody = GetComponent<Rigidbody>();
        myCamera = GetComponentInChildren<Camera>();

        playerInputs = new PlayerInputs();
        playerInputs.Player.Enable();
        playerInputs.Player.Jump.performed += OnJump;
        playerInputs.Player.Ability1.started += OnAbility1;
        playerInputs.Player.Ability2.started += OnAbility2;
        playerInputs.Player.Ability3.started += OnAbility3;
        playerInputs.Player.Ability4.started += OnAbility4;
        playerInputs.Player.Ability1.canceled += OnAbilityCanceled;
        playerInputs.Player.Ability2.canceled += OnAbilityCanceled;
        playerInputs.Player.Ability3.canceled += OnAbilityCanceled;
        playerInputs.Player.Ability4.canceled += OnAbilityCanceled;
        playerInputs.Player.Cancel.performed += OnCancel;
        playerInputs.Player.Switch.performed += OnSwitch;
        playerInputs.Player.Sprint.performed += OnSprint;
        playerInputs.Player.Interact.performed += OnInteract;
        playerInputs.Player.Emote.performed += OnEmote;
        playerInputs.Player.Chat.performed += OnChat;
        playerInputs.Player.Ping.performed += OnPing;
        playerInputs.Player.Trinket.performed += OnTrinket;
        playerInputs.Player.Consumable.performed += OnConsumable;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        Look();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            myPlayer.Jump();
        }
    }

    public void Move()
    {
        Vector2 inputVector = playerInputs.Player.Move.ReadValue<Vector2>();
        Vector3 movementVector = new Vector3(inputVector.x, 0, inputVector.y);
        float cameraRot = myCamera.transform.rotation.eulerAngles.y;
        playerRigidbody.position += Quaternion.Euler(0, cameraRot, 0) * movementVector * myPlayer.speed * Time.deltaTime;
    }

    public void Look()
    {
        Vector2 inputVector = playerInputs.Player.Look.ReadValue<Vector2>();

        mouseX += inputVector.x * lookSensitivity;
        mouseY -= inputVector.y * lookSensitivity;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        myCamera.transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    void OnAbility1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            myPlayer.PrimeAbility(0);
        }
    }

    void OnAbility2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            myPlayer.PrimeAbility(1);
        }
    }

    void OnAbility3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            myPlayer.PrimeAbility(2);
        }
    }

    void OnAbility4(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            myPlayer.PrimeAbility(3);
        }
    }

    void OnAbilityCanceled(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            myPlayer.ExecuteAbility();
        }
    }

    void OnCancel(InputAction.CallbackContext context)
    {
        myPlayer.ClearTarget();
    }

    void OnSwitch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            myPlayer.SwitchWeapons();
        }
    }

    void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            myPlayer.ToggleSprint();
        }
    }

    void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            myPlayer.Interact();
        }
    }

    void OnTrinket(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            myPlayer.UseTrinket();
        }
    }

    void OnConsumable(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            myPlayer.UseConsumable();
        }
    }

    void OnEmote(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            myPlayer.Emote();
        }
    }

    void OnPing(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            myPlayer.PingLocation();
        }
    }

    void OnChat(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            myPlayer.Chat();
        }
    }

    private void RebindAction(InputAction inputAction)
    {
        playerInputs.Player.Disable();
        playerInputs.Player.Jump.PerformInteractiveRebinding()
            .OnComplete(callback =>
            {
                Debug.Log(callback);
                callback.Dispose();
                playerInputs.Player.Enable();
            })
            .Start();
    }
}
