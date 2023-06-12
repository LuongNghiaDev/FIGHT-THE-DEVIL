using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float health = 3f;
    private float currentHealth;
    public GameObject effectRock;
    public Transform rockPos;

    private void Start()
    {
        currentHealth = health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet") &&  collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            AddDamage();
            collision.gameObject.SetActive(false);
        }
        if(collision.CompareTag("BulletBomb"))
        {
            AddDamageBomb();
            Destroy(collision.gameObject);
        }
    }

    protected virtual void AddDamage()
    {
        currentHealth -= 1;
        if (currentHealth == 0)
        {
            gameObject.SetActive(false);
            Instantiate(effectRock, rockPos.position, Quaternion.identity);
            if(gameObject.activeInHierarchy == false)
            {
                currentHealth = health;
                Invoke("SpawnRockDelay", 10f);
            }
        }
    }

    protected virtual void AddDamageBomb()
    {
        currentHealth = 0;
        if (currentHealth == 0)
        {
            gameObject.SetActive(false);
            Instantiate(effectRock, rockPos.position, Quaternion.identity);
            if (gameObject.activeInHierarchy == false)
            {
                currentHealth = health;
                Invoke("SpawnRockDelay", 10f);
            }
        }
    }

    protected void SpawnRockDelay()
    {
        gameObject.SetActive(true);
    }
}
