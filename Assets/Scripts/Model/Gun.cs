using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public new string name;
    public string nameGun;
    public int dame;
    public int force;
    public Sprite imgGun;
}
