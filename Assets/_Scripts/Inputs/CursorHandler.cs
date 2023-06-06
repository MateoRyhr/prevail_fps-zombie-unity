using UnityEngine;

public static class CursorHandler
{
    public static void HideCursor()
    {
        Cursor.visible = false;
    }

    public static void ShowCursor()
    {
        Cursor.visible = true;
    }

    public static void ConfinCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static void ReleaseCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}