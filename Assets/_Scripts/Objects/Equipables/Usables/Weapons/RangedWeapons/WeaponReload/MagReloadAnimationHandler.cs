using UnityEngine;

public class MagReloadAnimationHandler : MonoBehaviour
{
    [SerializeField] private Transform _magParent;
    
    private GameObject _magOnHand;

    public void ShowMag(GameObject mag)
    {
        _magOnHand = Instantiate(mag,_magParent);
    }

    public void HideMag()
    {
        Destroy(_magOnHand);
    }
}