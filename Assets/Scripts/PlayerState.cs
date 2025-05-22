using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static bool MovementEnabled = true;

    public static void DisableMovement()
    {
        MovementEnabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public static void EnableMovement()
    {
        MovementEnabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
