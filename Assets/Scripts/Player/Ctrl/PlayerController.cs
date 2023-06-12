using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public static PlayerController Instance { get => instance;  }

    public virtual void Move(GameObject gameObject,Vector3 moveInput, float moveSpeed)
    {
        gameObject.transform.position += moveInput * moveSpeed * Time.fixedDeltaTime;
    }


}
