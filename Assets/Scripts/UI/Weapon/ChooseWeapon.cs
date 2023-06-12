using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWeapon : BaseButtonController
{
    [SerializeField]
    protected Text txtDame1;
    [SerializeField]
    protected Text txtForce1;
    [SerializeField]
    protected Image image1;

    protected override void OnClick()
    {
        txtDame1.text = "";
        txtForce1.text = "";
        image1.sprite = null;
        WeaponDetail.Instance.NameWeapon.Clear();
        btnSaveWeapon.Instance.Weapons.Clear();
    }
}
