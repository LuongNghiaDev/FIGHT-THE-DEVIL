using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAssitantsController : BaseMonobehavior
{

    protected override void Start()
    {
        SpawnAssitants();
    }

    protected virtual void SpawnAssitants()
    {
        Vector2 target = FindTarget();
        for (int i = 0; i < btnUseAssitants.Instance.ListAssitant.Count; i++)
        {
            GameObject object1 = Resources.Load<GameObject>("Practitioners/" + btnUseAssitants.Instance.ListAssitant[i]);
            Instantiate(object1, target, Quaternion.identity);
        }
    }

    protected virtual Vector2 FindTarget()
    {
        Vector3 playPos = FindObjectOfType<Player>().transform.position;
        return (Vector2)playPos + (Random.Range(5f, 8f) * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized);
    }
}
