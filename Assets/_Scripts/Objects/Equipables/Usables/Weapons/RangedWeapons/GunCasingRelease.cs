using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunCasingRelease : MonoBehaviour
{
    [SerializeField] private GameObject _casingPrefab;
    [SerializeField] private Transform _casingReleaseTransform;
    [SerializeField] private Transform _casingReleaseForceFrom;
    [SerializeField] private FloatVariable _casingReleaseForce;
    [SerializeField] private FloatVariable _casingLifeTime;
    [SerializeField] private FloatVariable _forceVariation;
    [SerializeField] private FloatVariable _directionVariation;

    [SerializeField] private int poolMaxSize = 10;
    public int PoolSize { get => _pool.Count; }
    private List<GameObject> _pool;

    public UnityEvent OnCasingReleased;

    private void Awake() => _pool = new List<GameObject>();

    public void CasingRelease()
    {
        GameObject casing = GetCasing();
        SimpleEvent eventOnCasing = casing.GetComponent<SimpleEvent>();
        Rigidbody casingRb = casing.GetComponentInChildren<Rigidbody>();
        casingRb.velocity = Vector3.zero;
        casingRb.isKinematic = true;
        casingRb.position = _casingReleaseTransform.position;
        casingRb.rotation = _casingReleaseTransform.rotation;
        this.Invoke( () => {
            casingRb.isKinematic = false;
            Vector3 casingTip = casing.GetComponentInChildren<Collider>().ClosestPoint(_casingReleaseForceFrom.position);
            Vector3 randomForceVariation = new Vector3(
                Random.Range(-_directionVariation.Value,_directionVariation.Value),
                Random.Range(-_directionVariation.Value,_directionVariation.Value),
                Random.Range(-_directionVariation.Value,_directionVariation.Value)
            );
            Vector3 casingDirection = (casingTip - _casingReleaseForceFrom.position).normalized;
            float force = _casingReleaseForce.Value + Random.Range(-_forceVariation.Value,_forceVariation.Value);
            Vector3 casingExitForce = (casingDirection + randomForceVariation) * force;
            //Transfer momentum
            Vector3 parentVelocity = transform.root.GetComponentInChildren<Rigidbody>().velocity;
            casingRb.velocity = parentVelocity;
            //Add exit force
            casingRb.AddForceAtPosition(casingExitForce,casingTip,ForceMode.Impulse);
            OnCasingReleased?.Invoke();
            eventOnCasing.OnEvent?.Invoke();
            },Time.fixedDeltaTime);
    }

    GameObject GetCasing()
    {
        if(PoolSize < poolMaxSize)
        {
            _pool.Add(InstantiateCasing());
        }
        else
        {
            GameObject casing = _pool[0];
            _pool.Remove(casing);
            _pool.Add(casing);
        }
        return _pool[_pool.Count-1];
    }

    GameObject InstantiateCasing() => Instantiate(_casingPrefab,_casingReleaseTransform.position,_casingReleaseTransform.rotation,null);
}
