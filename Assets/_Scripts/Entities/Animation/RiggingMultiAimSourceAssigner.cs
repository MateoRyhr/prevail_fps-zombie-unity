using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RiggingMultiAimSourceAssigner : MonoBehaviour
{
    [SerializeField] private RigBuilder _rigBuilder;
    [SerializeField] private MultiAimConstraint _aimConstraint;
    [SerializeField] private GameObject _transformGetterObject;

    ITransform _transformGetter;

    private void Awake()
    {
        _transformGetter = _transformGetterObject.GetComponent<ITransform>();
    }

    public void AddSource()
    {
        Transform sourceTransform = _transformGetter.Value;
        WeightedTransformArray sources = _aimConstraint.data.sourceObjects;
        sources.Clear();
        sources.Add(new WeightedTransform(sourceTransform,1));
        _aimConstraint.data.sourceObjects = sources;
        _rigBuilder.Build();
    }

    public void CleanSources()
    {
        WeightedTransformArray sources = _aimConstraint.data.sourceObjects;
        sources.Clear();
        _aimConstraint.data.sourceObjects = sources;
        _rigBuilder.Build();
    }
}
