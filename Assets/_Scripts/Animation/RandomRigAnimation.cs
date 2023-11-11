using UnityEngine;

public class RandomRigAnimation : MonoBehaviour
{
    [SerializeField] private SimpleRigAnimation[] _animations;

    public void PlayRandomAnimation() => _animations[Random.Range(0,_animations.Length)].PlayAnimationRig();
}
