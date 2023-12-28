using System.Collections.Generic;
using UnityEngine;

public class RevolverBulletsAnimation : MonoBehaviour
{
    [SerializeField] GameObject _bulletsLoadedGetterContainer;
    [SerializeField] Transform _revolverWheel;
    [SerializeField] GameObject[] _bullets;
    [SerializeField] Rigidbody _rigidbodyOnFall;
    [SerializeField] int _layerAfterDrop;
    [SerializeField] float _timeToRespawnBullets;
    [SerializeField] float _timeBeforeBulletsStartFall;

    [SerializeField] FloatVariable _forceToDrop;
    [SerializeField] Vector3 _axisForce;

    [SerializeField] int _startAmount;
    [SerializeField] float _timeToDestroyBullets;

    private IInt _bulletsLoadedGetter;

    private List<GameObject> _currentBullets;

    private void Awake() {
        _bulletsLoadedGetter = _bulletsLoadedGetterContainer.GetComponent<IInt>();
        _currentBullets = new List<GameObject>();   
    }

    private void Start() => RespawnBullets(_startAmount);

    public void RespawnBullets() => this.Invoke(() => RespawnBullets(6),_timeToRespawnBullets);

    void RespawnBullets(int bulletsLoaded)
    {
        for(int i = 0; i < bulletsLoaded; i++)
        {
            GameObject bullet = Instantiate(_bullets[i],_revolverWheel);
            _currentBullets.Add(bullet);
            bullet.SetActive(true);
        }
    }

    public void DropBullets()
    {
        int bulletsToDrop = _currentBullets.Count;
        this.Invoke(() =>
        {

            for(int i = bulletsToDrop-1; i >= 0; i--)
            {
                _currentBullets[i].GetComponentInChildren<Collider>().enabled = true;
                Rigidbody rb = _currentBullets[i].AddComponent<Rigidbody>();
                SetRigidbody(rb);
                //Transfer momentum
                Vector3 parentVelocity = transform.root.GetComponentInChildren<Rigidbody>().velocity;
                rb.velocity = parentVelocity;
                // Debug.Log($"Parent velovity: {parentVelocity}");
                _currentBullets[i].transform.parent = null;
                Vector3 dropeForce = rb.transform.TransformDirection(_axisForce) * _forceToDrop.Value;
                rb.AddForce(dropeForce);
                Destroy(_currentBullets[i].gameObject,_timeToDestroyBullets);
                _currentBullets.Remove(_currentBullets[i]);
            }
        },_timeBeforeBulletsStartFall);
    }

    void SetRigidbody(Rigidbody rb)
    {
        rb.mass = _rigidbodyOnFall.mass;
        rb.angularDrag = _rigidbodyOnFall.angularDrag;
        rb.drag = _rigidbodyOnFall.drag;
        rb.interpolation = _rigidbodyOnFall.interpolation;
        // rb.useGravity = false;
        this.Invoke(() => 
        {
            // rb.useGravity = true;
            rb.gameObject.layer = _layerAfterDrop;
        },0.15f);
    }
}
