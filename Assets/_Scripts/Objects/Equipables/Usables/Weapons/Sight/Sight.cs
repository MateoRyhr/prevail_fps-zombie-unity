using UnityEngine;

public class Sight : MonoBehaviour
{
    [SerializeField] protected Camera _camera;
    [SerializeField] protected LayerMask _sightLayer;

    public Camera Camera { get => _camera; }

    public Vector3 GetLookingPoint()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = _camera.ScreenPointToRay(screenCenterPoint);
        Vector3 rayDirection = Vector3.zero;
        Physics.Raycast(ray, out RaycastHit raycastHit ,Mathf.Infinity, _sightLayer);
        return raycastHit.point;
    }
}
