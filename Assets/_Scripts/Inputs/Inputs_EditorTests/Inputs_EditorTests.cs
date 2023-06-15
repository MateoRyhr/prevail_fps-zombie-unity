using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

[TestFixture]
public class Inputs_EditorTests : InputTestFixture
{
    //------------------------CursorHandler

    CursorHandler _cursorHandler;

    [SetUp]
    public void SetUp()
    {
        _cursorHandler = new CursorHandler();
    }

    [Test]
    public void CursorHandler_HideCursor()
    {
        Cursor.visible = true;
        _cursorHandler.HideCursor();
        Assert.False(Cursor.visible);
    }

    [Test]
    public void CursorHandler_ShowCursor()
    {
        Cursor.visible = false;
        _cursorHandler.ShowCursor();
        Assert.True(Cursor.visible);
    }

    [Test]
    public void CursorHandler_ConfinCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        _cursorHandler.ConfinCursor();
        Assert.AreEqual(CursorLockMode.Confined,Cursor.lockState);
    }

    [Test]
    public void CursorHandler_LockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        _cursorHandler.LockCursor();
        Assert.AreEqual(CursorLockMode.Locked,Cursor.lockState);
    }

    [Test]
    public void CursorHandler_ReleaseCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _cursorHandler.ReleaseCursor();
        Assert.AreEqual(CursorLockMode.None,Cursor.lockState);
    }
}