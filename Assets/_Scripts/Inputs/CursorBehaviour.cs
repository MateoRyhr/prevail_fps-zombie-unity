using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    CursorHandler _cursorHandler;
    
    private void Awake()
    {
        _cursorHandler = new CursorHandler();    
    }

    public void HideCursor() => _cursorHandler.HideCursor();
    public void ShowCursor() => _cursorHandler.ShowCursor();
    public void ConfinCursor() => _cursorHandler.ConfinCursor();
    public void LockCursor() => _cursorHandler.LockCursor();
}
