using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T>: MonoBehaviour where T : MonoBehaviour
{
    public int CreatedObjects { get; private set; }

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

        return objects.Dequeue();
    }
}
