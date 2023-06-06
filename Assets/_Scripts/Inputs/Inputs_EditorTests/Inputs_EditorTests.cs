using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

[TestFixture]
public class Inputs_EditorTests : InputTestFixture
{
    //------------------------CursorHandler

    [Test]
    public void CursorHandler_HideCursor()
    {
        Cursor.visible = true;
        CursorHandler.HideCursor();
        Assert.False(Cursor.visible);
    }

    [Test]
    public void CursorHandler_ShowCursor()
    {
        Cursor.visible = false;
        CursorHandler.ShowCursor();
        Assert.True(Cursor.visible);
    }

    [Test]
    public void CursorHandler_ConfinCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        CursorHandler.ConfinCursor();
        Assert.AreEqual(CursorLockMode.Confined,Cursor.lockState);
    }

    [Test]
    public void CursorHandler_LockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        CursorHandler.LockCursor();
        Assert.AreEqual(CursorLockMode.Locked,Cursor.lockState);
    }

    [Test]
    public void CursorHandler_ReleaseCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CursorHandler.ReleaseCursor();
        Assert.AreEqual(CursorLockMode.None,Cursor.lockState);
    }

}