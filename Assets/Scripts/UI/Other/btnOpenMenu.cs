using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnOpenMenu : BaseButtonController
{

    [SerializeField]
    private GameObject dialogUpgradeWeapon;

    protected override void OnClick()
    {
        dialogUpgradeWeapon.SetActive(true);
    }
}
