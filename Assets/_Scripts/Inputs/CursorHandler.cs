using UnityEngine;

public class CursorHandler
{
    public void HideCursor()
    {
        Cursor.visible = false;
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    public void ConfinCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ReleaseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}