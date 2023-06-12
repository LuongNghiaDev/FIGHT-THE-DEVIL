using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSwapWeapon : BaseButtonController
{
    [SerializeField]
    protected Gun modelGun;

    protected override void OnClick()
    {
        WeaponDetail.Instance.SwapWeapon(modelGun);
    }
}
