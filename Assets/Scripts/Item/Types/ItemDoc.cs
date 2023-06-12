using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDoc : MonoBehaviour
{
    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private float dame;

    private void Start()
    {
        Instantiate(effect, transform.position,
Quaternion.identity);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //bomb
        if (collision.CompareTag("Enemy"))
        {
            //EnemyAL.Instance.AddDamage(dame);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //bomb
        if (collision.CompareTag("Enemy"))
        {

            EnemyAL.Instance.AddDamage(dame);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
