using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyBoss : BaseMonobehavior
{
    public bool isRoaming = true;
    public Seeker seeker;
    public float moveSpeed;
    private float currentMoveSpeed;
    public float nextWpDistance;
    Path path;
    Coroutine moveCoroutine;

    private bool reachDestination = false;
    //kt da di den diem can den chua

    public bool updateContinuesPath;

    //health
    [SerializeField]
    protected float health;
    private float currentHeath;
    [SerializeField]
    protected GameObject effectBlood;

    //roll
    public float rollDelay;
    private float rollDelayCouter;
    public bool isRoll;
    private Animator anim;
    private float rollOneTime = 2f;
    private float rollOneTimeCouter;

    public SpriteRenderer characterRD;

    //shoot
    private float angle = 0f;
    [SerializeField]
    protected GameObject firePos;

    private float timer = 20f;

    protected override void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    protected override void Start()
    {
        //speed
        currentMoveSpeed = moveSpeed;
        //roll
        rollOneTimeCouter = rollOneTime;
        rollDelayCouter = rollDelay;
        //helth
        currentHeath = health;
        InvokeRepeating("CaculatorPath", 0f, 0.5f);
        reachDestination = true;
    }

    private void Update()
    {
        if(this.isRoll)
        {
            this.timer -= Time.deltaTime;
            if (this.timer >= 18f)
            {
                InvokeRepeating("FireBullet", 0f, 0.1f);
            }
            else if (this.timer < 17f)
            {
                CancelInvoke("FireBullet");
                if (this.timer <= 0f)
                {
                    this.timer = 20f;
                }
            }
        } else if(this.isRoaming)
        {
            this.timer -= Time.deltaTime;
            if (this.timer >= 18f)
            {
                InvokeRepeating("FireBulletFly", 0f, 0.1f);
            }
            else if (this.timer < 17f)
            {
                CancelInvoke("FireBulletFly");
                if (this.timer <= 0f)
                {
                    this.timer = 20f;
                }
            }
        }
    }

    protected void FireBullet()
    {
        float bulDirX = firePos.transform.position.x + Mathf.Sin((angle * Mathf.PI) /180f);
        float bulDirY = firePos.transform.position.y + Mathf.Cos((angle * Mathf.PI) /180f);

        Vector3 bulMove = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMove - firePos.transform.position).normalized;

        GameObject bulletFabs = ObjectPoolController.Instance.GetPoolObjectBoss();
        if (bulletFabs != null)
        {
            bulletFabs.transform.position = firePos.transform.position;
            bulletFabs.transform.rotation = firePos.transform.rotation;
            bulletFabs.SetActive(true);
            bulletFabs.GetComponent<BulletHell>().SetMoveDirection(bulDir);
            angle += 10f;
        }
    }

    protected void FireBulletFly()
    {
        for(int i=0;i<=1;i++)
        {
            float bulDirX = firePos.transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = firePos.transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMove = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMove - firePos.transform.position).normalized;

            GameObject bulletFabs = ObjectPoolController.Instance.GetPoolObjectBoss();
            if (bulletFabs != null)
            {
                bulletFabs.transform.position = firePos.transform.position;
                bulletFabs.transform.rotation = firePos.transform.rotation;
                bulletFabs.SetActive(true);
                bulletFabs.GetComponent<BulletHell>().SetMoveDirection(bulDir);
                angle += 10f;
            }
        }

        angle += 10f;
        if(angle >= 360f)
        {
            angle = 0f;
        }
    }

    private void FixedUpdate()
    {
        IsRollEnemy();
    }

    protected virtual void IsRollEnemy()
    {
        if (isRoll)
        {
            rollDelayCouter -= Time.fixedDeltaTime;
            if (rollDelayCouter <= 0)
            {
                this.currentMoveSpeed = 6;
                anim.SetBool("Roll", true);
                rollOneTimeCouter -= Time.fixedDeltaTime;
                if (rollOneTimeCouter <= 0)
                {
                    this.currentMoveSpeed = moveSpeed;
                    anim.SetBool("Roll", false);
                    rollDelayCouter = rollDelay;
                    rollOneTimeCouter = rollOneTime;
                }
            }
            else
            {
                rollDelayCouter -= Time.fixedDeltaTime;
            }
        }
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
            return (Vector2)playPos + (Random.Range(5f, 10f) * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized);
        }
        else
        {
            return playPos;
        }
    }

    //tinh toan duong di ngan nhat
    void OnPathCallBackComplete(Path p)
    {
        if (p.error) return;
        path = p;
        MoveToTarget();
    }

    void MoveToTarget()
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

    //float damageBulletDaibac = Weapon_Daibac.Instance.Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            AddDamage(Weapon_Aka.Instance.ModelGun.dame);
        }
        if (collision.CompareTag("BulletBomb"))
        {
            AddDamage(Weapon_Daibac.Instance.ModelGun.dame);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("BulletBomb"))
        {
            float damageBullet = Weapon_Daibac.Instance.ModelGun.dame;
            AddDamage(damageBullet);
        }
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
        Instantiate(effectBlood, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        Time.timeScale = 0f;
        UIManagerController.Instance.PanelWin.gameObject.SetActive(true);
        SpawnEnemyController.Instance.EnemyParent.SetActive(false);
    }
}
