using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseMonobehavior
{

    [SerializeField]
    protected GameObject effectBomb;
    private int count = 10;

    private void LateUpdate()
    {
        if(effectBomb != null)
        {
            for(int i = 0;i<count;i++)
            {
                Instantiate(effectBomb, transform.position, Quaternion.identity);
                if (i == count)
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("BulletBomb"))
        {
            if (collision.CompareTag("LimitesZone"))
            {
                Destroy(gameObject);
            }
        } else
        {
            if (collision.CompareTag("LimitesZone"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
