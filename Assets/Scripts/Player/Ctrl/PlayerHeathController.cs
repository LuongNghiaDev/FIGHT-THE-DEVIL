using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeathController : MonoBehaviour
{
    private static PlayerHeathController instace;

    //health
    [SerializeField] protected float health;
    private float currentHealth;
    float dameRate = 0.5f;
    //sau 5s
    public float pushbackForce;
    float nextDamage;

    public static PlayerHeathController Instace { get => instace; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Awake()
    {
        if (instace == null)
            instace = this;
    }

    private void Start()
    {
        nextDamage = 0f;
        currentHealth = health;
    }

    public virtual void AddDamge()
    {
        if (nextDamage < Time.time)
        {
            float dame = DamageEnemyController.Instance.Damage;
            currentHealth -= dame;
            if (currentHealth == 0)
            {
                Die();
            }
            nextDamage = dameRate + Time.time;
        }
    }

    private void Die()
    {
        UIPlayerDie.Instance.CoinModel.totalCoin += (ItemController.Instance.CountCoin * 10);
        Time.timeScale = 0f;
        UIPlayerDie.Instance.UiplayerDie.SetActive(true);
        GameObject player = FindObjectOfType<Player>().gameObject;
        player.SetActive(false);
    }
}
