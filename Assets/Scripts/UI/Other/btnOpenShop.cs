using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnOpenShop : BaseButtonController
{
    protected override void OnClick()
    {
        UIHomeController.Instance.DialogShop.SetActive(true);
    }
}
