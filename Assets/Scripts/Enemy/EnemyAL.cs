using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAL : BaseMonobehavior
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

    //shoot
    public bool isShoot = false;
    public GameObject bulletEnemy;
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCoolDown;

    public SpriteRenderer characterRD;

    //health
    [SerializeField]
    protected float health;
    private float currentHeath;
    [SerializeField]
    private float spawnDelay = 8f;
    [SerializeField]
    protected GameObject effectBlood;

    //roll
    public float rollDelay;
    private float rollDelayCouter;
    public bool isRoll;
    private Animator anim;
    private float rollOneTime = 2f;
    private float rollOneTimeCouter;

    //jump
    public bool isJump;
    public float jumpDelay;
    private float jumpDelayCouter;
    private float jumpOneTime = 2f;
    private float jumpOneTimeCouter;
    public GameObject effectBomb;

    //drop item
    [SerializeField]
    protected bool isDrop;
    [SerializeField]
    protected GameObject itemCoin;
    [SerializeField]
    protected GameObject itemBomb;

    [SerializeField]
    protected List<GameObject> item;

    private enum MovementEnemyJump { walk, jump_start, jump_end }
    private MovementEnemyJump state;

    private static EnemyAL instance;

    public static EnemyAL Instance { get => instance; }
    public float SpawnDelay { get => spawnDelay; set => spawnDelay = value; }

    protected override void Awake()
    {
        if (instance == null)
            instance = this;
        anim = GetComponentInChildren<Animator>();
    }

    protected override void Start()
    {
        //jump
        jumpDelayCouter = jumpDelay;
        jumpOneTimeCouter = jumpOneTime;
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
        if (gameObject.activeInHierarchy == true && FindObjectOfType<Player>().isActiveAndEnabled == true)
        {
            fireCoolDown -= Time.deltaTime;
            if (fireCoolDown < 0)
            {
                fireCoolDown = timeBtwFire;
                //Shoot
                FireBullet();
            }
        }
    }

    private void FixedUpdate()
    {
        IsRollEnemy();
        IsJumpEnemy();
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
    protected virtual void IsJumpEnemy()
    {
        if(isJump)
        {
            jumpDelayCouter -= Time.fixedDeltaTime;
            if(jumpDelayCouter <= 0)
            {
                this.currentMoveSpeed = 6;
                state = MovementEnemyJump.jump_start;
                state = MovementEnemyJump.jump_end;
                jumpOneTimeCouter -= Time.fixedDeltaTime;
                if (jumpOneTimeCouter <= 0)
                {
                    this.currentMoveSpeed = moveSpeed;
                    anim.SetBool("Roll", false);
                    jumpDelayCouter = jumpDelay;
                    jumpOneTimeCouter = jumpOneTime;
                }
            }
            else
            {
                jumpDelayCouter -= Time.fixedDeltaTime;
            }
        }
    }

    void FireBullet()
    {
        var bullet = Instantiate(bulletEnemy, transform.position, Quaternion.identity);
        Rigidbody2D rg = bullet.GetComponent<Rigidbody2D>();
        //vi tri player
        Vector3 playPos = FindObjectOfType<Player>().transform.position;
        Vector3 direction = playPos - transform.position;
        rg.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
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
            Debug.Log("-------------------------name" + Weapon_Aka.Instance.ModelGun.name);
            Debug.Log("-------------------------dame" + Weapon_Aka.Instance.ModelGun.dame);
            AddDamage(Weapon_Aka.Instance.ModelGun.dame);
        }
        if (collision.CompareTag("BulletBomb"))
        {
            AddDamage(Weapon_Daibac.Instance.ModelGun.dame);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("BulletBomb"))
        {
            float damageBullet = Weapon_Daibac.Instance.ModelGun.dame;
            AddDamage(damageBullet);
        }
    }

    private void SpawnEnemy()
    {
        gameObject.SetActive(true);
    }

    private int enemyTxt = 0;

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
            if (gameObject.activeInHierarchy == false)
            {
                currentHeath = health;
                Invoke("SpawnEnemy", spawnDelay);
                reachDestination = true;
            }
        }
    }

    private void Die()
    {
        enemyTxt += 1;
        PlayerPrefs.SetInt("EnemyTxt", enemyTxt);
        if (isJump)
        {
            anim.SetTrigger("Die");
            StartCoroutine(DelayActiveObject());
            StopCoroutine(DelayActiveObject());
            if(isDrop)
            {
                int dropRate = Random.Range(0, 20);
                if(dropRate == 6) {
                    int random = Random.Range(0, item.Count);
                    Instantiate(item[random], transform.position, Quaternion.identity);
                }
                //Instantiate(itemBomb, transform.position, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(effectBlood, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            if (isDrop)
            {
                int dropRate = Random.Range(0, 20);
                if (dropRate == 6)
                {
                    int random = Random.Range(0, item.Count);
                    Instantiate(item[random], transform.position, Quaternion.identity);
                }
                Instantiate(itemCoin, transform.position, Quaternion.identity);
            }
        }
    }

    IEnumerator DelayActiveObject()
    {
        yield return new WaitForSeconds(0.35f);
        Instantiate(effectBomb, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.10f);
        Destroy(gameObject);
    }

}
