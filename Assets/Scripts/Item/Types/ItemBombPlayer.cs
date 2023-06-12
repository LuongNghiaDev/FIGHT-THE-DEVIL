using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBombPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private float dame;

    private static ItemBombPlayer instance;
    public static ItemBombPlayer Instance { get => instance; }
    public float Dame { get => dame; set => dame = value; }
    public GameObject Bomb { get => bomb; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //bomb
        if (collision.CompareTag("Enemy"))
        {
            EnemyAL.Instance.AddDamage(dame);
            Instantiate(bomb, transform.position,
                Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
