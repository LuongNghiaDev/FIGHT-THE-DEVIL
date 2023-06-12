using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpController : MonoBehaviour
{

    private static ItemPickUpController instance;

    [SerializeField]
    protected GameObject effectBaoho;

    //item eletric
    [SerializeField]
    protected GameObject effectEletric;

    //item doc
/*    [SerializeField]
    protected Transform docPos;*/
    [SerializeField]
    protected GameObject bulletDoc;


/*    [SerializeField]
    protected Transform itemPos;*/
    private int countInstantiate = 1;

    public static ItemPickUpController Instance { get => instance; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("ItemHeart"))
            {
                if (PlayerHeathController.Instace.CurrentHealth == 5f)
                {
                    PlayerHeathController.Instace.CurrentHealth += 1f;
                    UIManagerController.Instance.ListImage[5].gameObject.SetActive(true);
                }
                else if (PlayerHeathController.Instace.CurrentHealth == 4f)
                {
                    PlayerHeathController.Instace.CurrentHealth += 2f;
                    UIManagerController.Instance.ListImage[4].gameObject.SetActive(true);
                    UIManagerController.Instance.ListImage[5].gameObject.SetActive(true);
                }
                else if (PlayerHeathController.Instace.CurrentHealth == 3f)
                {
                    PlayerHeathController.Instace.CurrentHealth += 2f;
                    UIManagerController.Instance.ListImage[3].gameObject.SetActive(true);
                    UIManagerController.Instance.ListImage[4].gameObject.SetActive(true);
                }
                else if (PlayerHeathController.Instace.CurrentHealth == 2f)
                {
                    PlayerHeathController.Instace.CurrentHealth += 2f;
                    UIManagerController.Instance.ListImage[2].gameObject.SetActive(true);
                    UIManagerController.Instance.ListImage[3].gameObject.SetActive(true);
                }
                else if (PlayerHeathController.Instace.CurrentHealth == 1f)
                {
                    PlayerHeathController.Instace.CurrentHealth += 2f;
                    UIManagerController.Instance.ListImage[1].gameObject.SetActive(true);
                    UIManagerController.Instance.ListImage[2].gameObject.SetActive(true);
                }
            }
            if (gameObject.CompareTag("ItemEletric"))
            {
                SpawnRandomObject.Instance.IsPickUp = true;
                if (countInstantiate > 0)
                {
                    Debug.Log("Cham item");
                    SpawnRandomObject.Instance.IsPickUp = true;
                    /*GameObject itemFabs = Instantiate(gameObject, targetPlayer, Quaternion.identity);
                    //itemFabs.transform.parent = itemPos;*/
                    Destroy(gameObject);
                    countInstantiate--;
                }
            }
            if (gameObject.CompareTag("ItemDoc"))
            {
                if (countInstantiate > 0)
                {

                    GameObject itemDoc = Instantiate(bulletDoc, Player.Instance.gameObject.transform.position, Quaternion.identity);
                    itemDoc.transform.parent = Player.Instance.gameObject.transform;
                    countInstantiate--;
                }
            }
            Destroy(gameObject);
        }
    }

}
