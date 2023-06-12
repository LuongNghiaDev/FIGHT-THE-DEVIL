using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnOpenWeapon : BaseButtonController
{
    protected override void OnClick()
    {
        UIHomeController.Instance.DialogWeapons.SetActive(true);
        UIHomeController.Instance.DialogAssistants.SetActive(false);
    }
}
