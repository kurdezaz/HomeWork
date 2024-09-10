using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour
{
    private Queue<T> _objects;

    private void Awake()
    {
        _objects = new Queue<T>();
    }

    public T GetObject()
    {
        return _objects.Dequeue();
    }

    public void PutObject(T objectPrefab)
    {
        _objects.Enqueue(objectPrefab);
    }

    public Queue<T> ReturnQueue()
    {
        return _objects;
    }
}
