using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BaseMonobehavior
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else
        {
            if (collision.CompareTag("LimitesZone"))
            {
                Destroy(gameObject);
            }
        }
    }
}
