using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnCombat : BaseButtonController
{
    protected override void OnClick()
    {
        UIHomeController.Instance.DialogModelOption.SetActive(true);
    }
}
