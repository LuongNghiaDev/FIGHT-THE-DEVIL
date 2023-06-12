using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTotalScore", menuName = "TotalScore")]
public class Score : ScriptableObject
{
    public new string name;
    public float coinRecord;
    public int enemyRecord;
}
