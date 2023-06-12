using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCoin", menuName = "Coin")]
public class Coin : ScriptableObject
{

    public new string name;
    public float totalCoin;
}
