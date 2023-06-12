using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItemTimer : MonoBehaviour
{
    private static DestroyItemTimer instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [SerializeField]
    protected float destroyDelay;

    public static DestroyItemTimer Instance { get => instance; }

    void Update()
    {
        Destroy(gameObject, destroyDelay);
    }
}
