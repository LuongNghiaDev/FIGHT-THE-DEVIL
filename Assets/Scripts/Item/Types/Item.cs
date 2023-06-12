using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(gameObject.CompareTag("Coin"))
            {
                ItemController.Instance.CountCoin += 1;
            }
            if (gameObject.CompareTag("Bomb"))
            {
                ItemController.Instance.CountBomb += 1;
            }
            Destroy(gameObject);
        }
    }
}
