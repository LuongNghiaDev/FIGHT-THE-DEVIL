using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float CountBomb { get => countBomb; set => countBomb = value; }
    public float CountCoin { get => countCoin; set => countCoin = value; }

    private float countCoin = 0;
    private float countBomb = 0;

    private static ItemController instance;

    public static ItemController Instance { get => instance; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

}
