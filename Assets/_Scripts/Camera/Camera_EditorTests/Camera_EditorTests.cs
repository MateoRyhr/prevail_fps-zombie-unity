using NUnit.Framework;

public class Camera_EditorTests
{
    [TestCase(0,1,1)]
    [TestCase(0,1,10)]
    [TestCase(0,-1,100)]
    [TestCase(-100,100,12)]
    [TestCase(-100,-4,22)]
    public void Camera_EditorTestsSimplePasses(float current,float input, float sensivity)
    {
        CameraController cameraController = new CameraController();
        float result = cameraController.GetRotation(current,input,sensivity);
        float expected = current + input * sensivity;
        Assert.AreEqual(expected,result,$"Camera turn in axis is {result} but expected {expected}.");  
    }
}
