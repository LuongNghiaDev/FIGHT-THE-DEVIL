using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNotification : BaseMonobehavior
{

    [SerializeField]
    protected float timer = 1.5f;

    private void Update()
    {
        if(gameObject.activeInHierarchy == true)
        {
            Time.timeScale = 1f;
            if (timer <= 0f)
            {
                gameObject.SetActive(false);
                timer = 1.5f;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
