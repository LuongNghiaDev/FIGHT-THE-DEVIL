using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnOpenUpgrade : BaseButtonController
{
    protected override void OnClick()
    {
        UIHomeController.Instance.DialogUpgrade.SetActive(true);
    }
}
