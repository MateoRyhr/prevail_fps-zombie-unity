using UnityEngine;
using UnityEngine.UI;

public class RadiusSight : Sight
{
    [Tooltip("Must be ascendant curve")]
    [SerializeField] private AnimationCurve _sightRecoveryCurve;
    [SerializeField] private FloatVariable _timeToStartRecovery;
    [SerializeField] private FloatVariable _startRecoveryForce;
    [SerializeField] private FloatVariable _maxRecoveryForce;
    [SerializeField] private FloatVariable _allSightsMinimumRadius;
    [SerializeField] private FloatVariable _allSightsMaximumRadius;
    [SerializeField] private CanvasScaler _canvasScaler;

    public float SightRadius {
        get => _sightRadius;
        set => _sightRadius = Mathf.Clamp(value,_allSightsMinimumRadius.Value,_allSightsMaximumRadius.Value);
    }
    private float _sightRadius;
    // public float SightMinimumRadius { get ; set; }

    public float TimeWaitingToStartRecovery { get; set; }
    public float TimeRecovering { get; set; }

    private float RecoveryForceAddedInTime => _maxRecoveryForce.Value - _startRecoveryForce.Value;

    private void Awake()
    {
        SightRadius = _allSightsMinimumRadius.Value;
    }

    private void Update()
    {
        TimeWaitingToStartRecovery += Time.deltaTime;
        if(SightRadius > _allSightsMinimumRadius.Value && TimeWaitingToStartRecovery >= _timeToStartRecovery.Value)
        {   
            SightRadius -=  (_startRecoveryForce.Value + _sightRecoveryCurve.Evaluate(TimeRecovering) * RecoveryForceAddedInTime) * Time.deltaTime;
            TimeRecovering += Time.deltaTime;
        }
    }

    public Vector3 GetRandomPointOnRadius()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        //(Screen.height / _canvasScaler.referenceResolution.y) --> en relacion a la resolucion de la pantalla.
        Vector2 randomPointOnRadius = Random.insideUnitCircle * SightRadius * Screen.height / _canvasScaler.referenceResolution.y;
        Ray ray = _camera.ScreenPointToRay(screenCenterPoint + randomPointOnRadius);
        Vector3 rayDirection = Vector3.zero;
        Physics.Raycast(ray, out RaycastHit raycastHit ,Mathf.Infinity, _sightLayer);
        return raycastHit.point;   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(GetLookingPoint(),.025f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetRandomPointOnRadius(),.025f);
    }
}
