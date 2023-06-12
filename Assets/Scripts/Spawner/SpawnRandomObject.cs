using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomObject : MonoBehaviour
{
    private static SpawnRandomObject instance;

    private float spawnRate = 0.2f;
    private float nextSpawm;
    public GameObject bulletItemEletric;
    private bool isPickUp = false;

    //count seconds
    private float timeCounter = 10f;
    private float currentTimeCounter;

    public bool IsPickUp { get => isPickUp; set => isPickUp = value; }
    public static SpawnRandomObject Instance { get => instance; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        currentTimeCounter = timeCounter;
        nextSpawm = 0f;
    }

    private void Update()
    {
        Debug.Log("time " + currentTimeCounter);
        Debug.Log("pickup " + isPickUp);
        if (currentTimeCounter < 0)
        {
            isPickUp = false;
            currentTimeCounter = timeCounter;
        }
        if (isPickUp == true  && currentTimeCounter > 0)
        {
            if(nextSpawm < Time.time)
            {
                Instantiate(bulletItemEletric, new Vector2(RandomSpawn().x, RandomSpawn().y), Quaternion.identity);
                nextSpawm = spawnRate + Time.time;
            }
            currentTimeCounter -= Time.deltaTime;
            Debug.Log("Cham item");
        }
    }

    protected virtual Vector2 RandomSpawn()
    {
        Vector3 playPos = FindObjectOfType<Player>().transform.position;
        // nhan vs vecto don vi ra toa do hinh vuong (-1, 1) (-1, -1), (1,1)
        return (Vector2)playPos + (Random.Range(5f, 7f) * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized);
    }
}
