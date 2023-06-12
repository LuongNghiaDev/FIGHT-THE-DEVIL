using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : BaseMonobehavior
{
    [SerializeField]
    protected GameObject effectEletric;

    private void LateUpdate()
    {
        /*if (effectEletric != null)
        {
            Instantiate(effectEletric, transform.position, Quaternion.identity);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LimitesZone"))
        {
            Destroy(gameObject);
        }
    }
}
