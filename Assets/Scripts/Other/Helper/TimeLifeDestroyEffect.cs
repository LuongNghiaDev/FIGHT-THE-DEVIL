using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLifeDestroyEffect : MonoBehaviour
{
    public float timeDestroy = 10f;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeDestroy);
    }
}
