using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseMonobehavior
{
    private static Player instance;

    //speed
    [SerializeField]
    protected float moveSpeed;
    //roll
    [SerializeField]
    protected float rollBoost = 2f;
    private float rollTime;
    [SerializeField]
    protected float RollTime;
    private bool rollOne = false;

    //move input
    private Vector3 moveInput;

    private Rigidbody2D rg;
    private Animator anim;
    [SerializeField]
    protected SpriteRenderer characterRd;

    //weapon
    [SerializeField]
    protected Transform weaponPos;

    //using item bomb;
    [SerializeField]
    protected GameObject bomb;
    public static Player Instance { get => instance; }

    protected override void Awake()
    {
        if (instance == null)
            instance = this;
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        this.Movement();
        //this.DropItem();
    }

    protected virtual void Movement()
    {
        if (Input.GetMouseButton(1) && rollTime <= 0)
        {
            anim.SetBool("Rool", true);
            moveSpeed += rollBoost;
            rollTime = RollTime;
            rollOne = true;
        }

        if (rollTime <= 0 && rollOne)
        {
            anim.SetBool("Rool", false);
            moveSpeed -= rollBoost;
            rollOne = false;
        }
        else
        {
            rollTime -= Time.deltaTime;
        }
    }

    protected virtual void DropItem()
    {
        if (Input.GetMouseButton(1))
        {
            if (ItemController.Instance.CountBomb > 0)
            {
                ItemController.Instance.CountBomb -= 1f;
                Instantiate(bomb, transform.position, Quaternion.identity);
            }
        }
    }

    private void FixedUpdate()
    {
        anim.SetFloat("Run", moveInput.sqrMagnitude);
        PlayerController.Instance.Move(gameObject, moveInput, moveSpeed);
        Flip();
    }

    protected virtual void Flip()
    {
        if(moveInput.x != 0)
        {
            if(moveInput.x > 0)
            {
                characterRd.transform.localScale = new Vector3(1, 1, 0);
            } else
            {
                characterRd.transform.localScale = new Vector3(-1, 1, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            PlayerHeathController.Instace.AddDamge();
        }
    }
}
