using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponList : MonoBehaviour
{

    [SerializeField]
    protected Image imgWeapon;
    [SerializeField]
    protected Text txtDame;
    [SerializeField]
    protected Text txtForce;
    [SerializeField]
    protected Gun modelGun;

    // Start is called before the first frame update
    void Start()
    {
        imgWeapon.sprite = modelGun.imgGun;
        txtDame.text = "Dame: " + modelGun.dame;
        txtForce.text = "Force: " + modelGun.force;
    }

}
