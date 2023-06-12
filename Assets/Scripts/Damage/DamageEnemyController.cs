using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyController : BaseMonobehavior
{

    [SerializeField]
    private float damage;

    private static DamageEnemyController instance;

    public static DamageEnemyController Instance { get => instance; }
    public float Damage { get => damage; }

    protected override void Start()
    {
        if (instance == null)
            instance = this;
    }
}
