using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnCloseMenu : BaseButtonController
{
    [SerializeField]
    private GameObject dialogUpgradeWeapon;

    protected override void OnClick()
    {
        if (dialogUpgradeWeapon.activeInHierarchy)
        {
            dialogUpgradeWeapon.SetActive(false);
        }
    }
}
