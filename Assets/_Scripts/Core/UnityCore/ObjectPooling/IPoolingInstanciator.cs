using System;
using UnityEngine;
using UnityEngine.Pool;

public interface IPoolingInstanciator
{
    abstract Component InstantiateObject();
    abstract void OnGetComponent(Component component);
    abstract void OnReturnToPool(Component component);
    abstract void OnDestroyFromPool(Component component);
}