using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : BaseMonobehavior
{

    [SerializeField]
    protected Vector2 moveDirection;
    [SerializeField]
    protected float moveSpeed = 10f;

    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHeathController.Instace.AddDamge();
            gameObject.SetActive(false);
        }
        else if (collision.CompareTag("LimitesZone"))
        {
            gameObject.SetActive(false);
        }
    }
}
