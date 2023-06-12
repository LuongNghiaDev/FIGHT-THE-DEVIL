using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataSave
{

    public float coinData;
    public int weaponCountData;
    public List<WeaponData> weapon;
    public int practitionersCountData;
}


[System.Serializable]
public class WeaponData
{

    public float damage;
    public int force;
    public string name;
}