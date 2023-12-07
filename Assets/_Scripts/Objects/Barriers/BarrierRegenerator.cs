using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BarrierRegenerator : MonoBehaviour
{
    [SerializeField] private LinkBarrier _barrier;
    [SerializeField] private LinkBarrierElement[] _barriers;
    [SerializeField] private Transform _barrierRespawnPoint;
    
    private List<LinkBarrierElement> _currentBarriers;

    private void Awake() => _currentBarriers = new List<LinkBarrierElement>();
    private void Start() => GetInitialBarriers();

    public void GenerateBarrier()
    {
        LinkBarrierElement barrierPrefab = GetBarrier();
        if(barrierPrefab == null) return;
        LinkBarrierElement barrierElement =
            Instantiate(barrierPrefab,_barrierRespawnPoint);
        barrierElement.SetBarrier(_barrier);
        barrierElement.AddElement();
        _currentBarriers.Add(barrierElement);
        barrierElement.OnRemove.AddListener(() => _currentBarriers.Remove(barrierElement));
    }

    LinkBarrierElement GetBarrier()
    {
        LinkBarrierElement barrierToGenerate;
        foreach (var barrier in _barriers)
        {
            barrierToGenerate = barrier;
            for(int i = 0; i < _currentBarriers.Count; i++)
            {
                if(_currentBarriers[i].BarrierID == barrierToGenerate.BarrierID)
                {
                    barrierToGenerate = null;
                    i = _currentBarriers.Count;
                }
            }
            // foreach (var currentBarrier in _currentBarriers)
            // {
            //     if(currentBarrier.BarrierID == barrierToGenerate.BarrierID)
            //         barrierToGenerate = null;
            // }
            if(barrierToGenerate != null)
                return barrierToGenerate;
        }
        return null;
    }

    void GetInitialBarriers()
    {
        _currentBarriers = _barrierRespawnPoint.GetComponents<LinkBarrierElement>().ToList();
    }
}
