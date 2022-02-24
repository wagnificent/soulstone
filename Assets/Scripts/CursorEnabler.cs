using UnityEngine;

public class CursorEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnlockCursor();
    }

    void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
