using System;
using System.Collections.Generic;

public class Pool<T> where T : class
{
    private Func<T> _createFunction;
    private Action<T> _actionOnGet;

    private int _maxSize;
    public int _poolSize { get => _pool.Count; }

    private List<T> _pool;

    public Pool(Func<T> createFunc, Action<T> actionOnGet, int maxSize)
    {
        _createFunction = createFunc;
        _actionOnGet = actionOnGet;
        _maxSize = maxSize;
        _pool = new List<T>();
    }

    public T GetObject()
    {
        if(_poolSize < _maxSize)
        {
            T newElement = _createFunction();
            _pool.Add(newElement);
        }
        else
        {
            T recycledObject = _pool[0];
            _pool.Remove(recycledObject);
            _pool.Add(recycledObject);
        }
        _actionOnGet?.Invoke(_pool[_poolSize-1]);
        return _pool[_poolSize-1];
    }
}
