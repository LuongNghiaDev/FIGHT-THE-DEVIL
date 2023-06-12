using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyController : MonoBehaviour
{
    private static SpawnEnemyController instance;

    //length object
    [SerializeField]
    protected int enemyObjectFly;
    [SerializeField]
    protected int enemyObjectWalk;
    [SerializeField]
    protected int enemyObjectRoll;
    [SerializeField]
    protected int enemyObjectBomb;

    //object
    [SerializeField]
    protected GameObject enemyFly;
    [SerializeField]
    protected GameObject enemyWalk;
    [SerializeField]
    protected GameObject enemyRoll;
    [SerializeField]
    protected GameObject enemyBomb;
    [SerializeField]
    protected GameObject enemyBoss1;
    [SerializeField]
    protected GameObject enemyBoss2;
    private int countLength = 5;

    //time delay
    private float timeRate = 30f;
    private float curTimeRate;
    [SerializeField]
    protected float totalTime = 2 * 30;
    private float timeRemaining;
    [SerializeField]
    private int countBoss = 1;


    [SerializeField]
    private GameObject enemyParent;

    Vector3 spawnLocation;

    public static SpawnEnemyController Instance { get => instance; set => instance = value; }
    public GameObject EnemyParent { get => enemyParent; set => enemyParent = value; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        timeRemaining = totalTime;
        curTimeRate = timeRate;
        StartCoroutine(StartCreateEnemy());
    }

    IEnumerator StartCreateEnemy()
    {
        CreateObjectEnemyFly();
        CreateObjectEnemyWalk();
        CreateObjectEnemyRoll();
        CreateObjectEnemyBomb();
        yield return null;
    }

    private void Update()
    {
        if (curTimeRate > 0)
        {
            curTimeRate -= Time.deltaTime;
        }
        else
        {
            EnemyAL.Instance.SpawnDelay = 5f;
            curTimeRate = 0f;
        }
        this.TimerDeduct();
    }

    protected virtual void TimerDeduct()
    {
        timeRemaining -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        string timerText = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timeRemaining <= 0f)
        {
            CreateObjectEnemyBoss();
        }
    }

    private Vector3 GetSpawnLocation(Vector3 center, float radius)
    {
        float angle = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    private void CreateObjectEnemyFly()
    {
        spawnLocation = GetSpawnLocation(transform.position, 24f);
        for (int i = 0; i < enemyObjectFly; i++)
        {
            GameObject obj = Instantiate(enemyFly);
            obj.transform.parent = enemyParent.transform;
            obj.transform.position = spawnLocation;
        }
    }

    private void CreateObjectEnemyWalk()
    {
        spawnLocation = GetSpawnLocation(transform.position, 24f);
        for (int i = 0; i < enemyObjectWalk; i++)
        {
            GameObject obj = Instantiate(enemyWalk);
            obj.transform.parent = enemyParent.transform;
            obj.transform.position = new Vector3(spawnLocation.x, spawnLocation.y + countLength, spawnLocation.z);
            countLength += 4;
        }
    }

    private void CreateObjectEnemyRoll()
    {
        spawnLocation = GetSpawnLocation(transform.position, 24f);
        for (int i = 0; i < enemyObjectRoll; i++)
        {
            GameObject obj = Instantiate(enemyRoll);
            obj.transform.parent = enemyParent.transform;
            obj.transform.position = new Vector3(spawnLocation.x - countLength, spawnLocation.y, spawnLocation.z);
            countLength += 4;

        }
    }

    private void CreateObjectEnemyBomb()
    {
        spawnLocation = GetSpawnLocation(transform.position, 24f);
        for (int i = 0; i < enemyObjectBomb; i++)
        {
            GameObject obj = Instantiate(enemyBomb);
            obj.transform.parent = enemyParent.transform;
            obj.transform.position = new Vector3(spawnLocation.x + countLength, spawnLocation.y, spawnLocation.z);
            countLength += 4;
        }
    }

    private void CreateObjectEnemyBoss()
    {
        if(countBoss > 0)
        {
            if(PlayerPrefs.GetInt("Level") == 1)
            {
                spawnLocation = GetSpawnLocation(transform.position, 24f);
                GameObject obj = Instantiate(enemyBoss1);
                obj.transform.parent = enemyParent.transform;
                obj.transform.position = new Vector3(spawnLocation.x, spawnLocation.y, spawnLocation.z);
                countBoss -= 1;
            } else if (PlayerPrefs.GetInt("Level") == 2)
            {
                spawnLocation = GetSpawnLocation(transform.position, 24f);
                GameObject obj = Instantiate(enemyBoss2);
                obj.transform.parent = enemyParent.transform;
                obj.transform.position = new Vector3(spawnLocation.x, spawnLocation.y, spawnLocation.z);
                countBoss -= 1;
            }
        }
    }
}
