using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnOpenSetting : BaseButtonController
{
    protected override void OnClick()
    {
        UIHomeController.Instance.DialogSetting.SetActive(true);
    }
}
