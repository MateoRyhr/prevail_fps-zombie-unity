using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;


public class EntityMovement_EditorTests
{
    private IAceleratedMovement _aceleratedMovement;
    private AnimationCurve _aceleractionCurve;
    private AnimationCurve _deceleractionCurve;

    const float MAX_SPEED = 100f;
    const float TIME_TO_MAX_SPEED = 1f;
    const float TIME_TO_STOP = 1f;

    private AcelerationMover _mover;

    [SetUp]
    public void SetUp()
    {
        _aceleratedMovement = Substitute.For<IAceleratedMovement>();

        _aceleratedMovement.MaxSpeed.Returns(MAX_SPEED);
        _aceleratedMovement.TimeToReachMaxSpeed.Returns(TIME_TO_MAX_SPEED);
        _aceleratedMovement.TimeToStop.Returns(TIME_TO_STOP);
        Keyframe[] acelerationKeyFrames = {new Keyframe(0f,0f), new Keyframe(1f,1f)};
        Keyframe[] decelerationKeyFrames = {new Keyframe(0f,0f), new Keyframe(1f,1f)};
        _aceleractionCurve = new AnimationCurve(acelerationKeyFrames);
        _deceleractionCurve = new AnimationCurve(decelerationKeyFrames);

        _mover = new AcelerationMover(_aceleratedMovement,_aceleractionCurve,_deceleractionCurve);
    }

    [TestCase(new float[3]{0,0,0},0f,new float[3]{0,0,0})]
    [TestCase(new float[3]{1,1,1},0f,new float[3]{0,0,0})]
    [TestCase(new float[3]{0,0,0},1f,new float[3]{0,0,0})]
    [TestCase(new float[3]{1,0,0},TIME_TO_MAX_SPEED,new float[3]{MAX_SPEED,0,0})]
    [TestCase(new float[3]{0,1,0},TIME_TO_MAX_SPEED,new float[3]{0,MAX_SPEED,0})]
    [TestCase(new float[3]{0,0,1},TIME_TO_MAX_SPEED,new float[3]{0,0,MAX_SPEED})]
    [TestCase(new float[3]{1,1,1},TIME_TO_MAX_SPEED,new float[3]{MAX_SPEED,MAX_SPEED,MAX_SPEED})]
    public void AcelerationMover_Move(float[] direction, float timeLapsed, float[] expected)
    {
        //Arrange
        Vector3 vDirection = new Vector3(direction[0],direction[1],direction[2]);
        Vector3 expectedVelocity = new Vector3(expected[0],expected[1],expected[2]);
        //Act
        Vector3 result = _mover.Move(vDirection,timeLapsed);
        //Assert
        Assert.AreEqual(expectedVelocity,result);
    }
}
