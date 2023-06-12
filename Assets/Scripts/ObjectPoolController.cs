using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolController : MonoBehaviour
{
    private static ObjectPoolController instance;

    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    protected GameObject bulletBoss;
    protected List<GameObject> poolObjects = new List<GameObject>();
    protected List<GameObject> poolObjectBoss = new List<GameObject>();
    protected int amoutToPool = 40;
    public static ObjectPoolController Instance { get => instance; }
    [SerializeField]
    protected Transform bulletHolder;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnBulletHell();
    }

    public virtual GameObject GetPoolObject()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if(!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        return null;
    }

    public virtual GameObject GetPoolObjectBoss()
    {
        for (int i = 0; i < poolObjectBoss.Count; i++)
        {
            if (!poolObjectBoss[i].activeInHierarchy)
            {
                return poolObjectBoss[i];
            }
        }
        return null;
    }

    protected virtual void SpawnBulletHell()
    {
        for (int i = 0; i < amoutToPool; i++)
        {
            GameObject obj = Instantiate(bullet);
            obj.transform.parent = bulletHolder;
            obj.SetActive(false);
            poolObjects.Add(obj);
        }
        for (int i = 0; i < 100; i++)
        {
            GameObject obj = Instantiate(bulletBoss);
            obj.transform.parent = bulletHolder;
            obj.SetActive(false);
            poolObjectBoss.Add(obj);
        }
    }
}
