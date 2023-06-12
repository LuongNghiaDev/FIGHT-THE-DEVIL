using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class practitionersAL : BaseMonobehavior
{

    [SerializeField]
    protected Transform weaponPos;
    private float dameRate = 0.5f;
    private float nextDame;

    [SerializeField]
    protected bool isRoaming = true;
    [SerializeField]
    protected Seeker seeker;
    [SerializeField]
    protected float moveSpeed;
    private float currentMoveSpeed;
    [SerializeField]
    protected float nextWpDistance;
    Path path;
    Coroutine moveCoroutine;

    private bool reachDestination = false;
    //kt da di den diem can den chua

    [SerializeField]
    protected bool updateContinuesPath;

    [SerializeField]
    protected SpriteRenderer characterRD;

    //health
    [SerializeField]
    protected float health;
    private float currentHeath;
    [SerializeField]
    protected GameObject effectBlood;

    protected override void Start()
    {
        nextDame = 0f;
        //speed
        currentMoveSpeed = moveSpeed;
        //helth
        currentHeath = health;
        InvokeRepeating("CaculatorPath", 0f, 0.5f);
        reachDestination = true;

        GameObject gun1 = Resources.Load<GameObject>("Weapons/gun3_3");
        GameObject newGun1 = Instantiate(gun1, weaponPos.position, Quaternion.identity);
        newGun1.transform.parent = weaponPos;
    }

    protected virtual void CaculatorPath()
    {
        Vector2 target = FindTarget();
        if (seeker.IsDone() && (reachDestination || updateContinuesPath) && gameObject.activeInHierarchy == true)
        {
            seeker.StartPath(transform.position, target, OnPathCallBackComplete); ;
        }
    }

    protected virtual Vector2 FindTarget()
    {
        Vector3 playPos = FindObjectOfType<Player>().transform.position;
        if (isRoaming)
        {

            // nhan vs vecto don vi ra toa do hinh vuong (-1, 1) (-1, -1), (1,1)
            return (Vector2)playPos + (Random.Range(5f, 8f) * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized);
        }
        else
        {
            return playPos;
        }
    }

    //tinh toan duong di ngan nhat
    private void OnPathCallBackComplete(Path p)
    {
        if (p.error) return;
        path = p;
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    //di chuyen den target
    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;
        reachDestination = false;
        while (currentWP < path.vectorPath.Count)
        {
            //vi tri sap toi se di , huong di chuyen
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector3 force = direction * currentMoveSpeed * Time.deltaTime;
            transform.position += force;

            //vi tri diem tiep theo voi AL, tinh toan lai
            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWpDistance)
            {
                currentWP++;
                //di den diem tiep theo
            }

            if (force.x != 0)
            {
                if (force.x < 0)
                    characterRD.transform.localScale = new Vector3(-1, 1, 0);
                else
                    characterRD.transform.localScale = new Vector3(1, 1, 0);
            }
            yield return null;
        }
        reachDestination = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(nextDame < Time.time)
            {
                float damage = DamageEnemyController.Instance.Damage;
                AddDamage(damage);
                nextDame = dameRate + Time.time;
            }
        }
    }

    private void SpawnPractitioners()
    {
        gameObject.SetActive(true);
    }

    public virtual void AddDamage(float dame)
    {
        if (dame > currentHeath)
        {
            currentHeath = 0;
        }
        else
        {
            currentHeath -= dame;
        }
        if (currentHeath == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        StartCoroutine(DelayActiveObject());
        StopCoroutine(DelayActiveObject());
    }

    IEnumerator DelayActiveObject()
    {
        yield return new WaitForSeconds(0.35f);
        Instantiate(effectBlood, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.10f);
        Destroy(gameObject);
    }
}
