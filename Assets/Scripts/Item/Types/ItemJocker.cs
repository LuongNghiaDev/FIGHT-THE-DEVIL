using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemJocker : MonoBehaviour
{
    [SerializeField]
    protected GameObject effectBomb;

    [SerializeField]
    protected GameObject bomb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(DelayBomb());
        StopCoroutine(DelayBomb());
        PlayerHeathController.Instace.CurrentHealth -= 1f;
    }

    IEnumerator DelayBomb()
    {
        Instantiate(effectBomb, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.10f);
        bomb.SetActive(false);
    }
}
