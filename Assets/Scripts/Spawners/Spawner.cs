using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner<T>: MonoBehaviour where T : MonoBehaviour
{
    public ObjectPool<T> _objectPool;

    public int CreatedObjects { get; private set; }
    
    private void Awake()
    {
        _objectPool = new ObjectPool<T>();
    }

    public T Spawn(T prefab)
    {
        T instance = Instantiate(prefab);
        return instance;
    }

    public T GetObject(Queue<T> objects, T objectPrefab)
    {
        if (objects.Count == 0)
        {
            CreatedObjects++;
            return Spawn(objectPrefab);
        }

        return _objectPool.GetObject();
    }
}
