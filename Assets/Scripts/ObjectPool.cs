using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    T prefab;

    [SerializeField]
    int initialValue;

    List<T> pool = new List<T>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        for (int i = 0; i < initialValue; i++)
        {
            CreateObject();
        }
    }


    T CreateObject()
    {
        var newObj = Instantiate(prefab, transform);
        newObj.gameObject.SetActive(false);
        pool.Add(newObj);

        return newObj;
    }

    public T GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        return CreateObject();
    }

    public int GetNumActiveObjects()
    {
        return pool.Count(x => x.gameObject.activeInHierarchy);
    }
}
