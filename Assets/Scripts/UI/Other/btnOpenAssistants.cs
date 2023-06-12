using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnOpenAssistants : BaseButtonController
{
    protected override void OnClick()
    {
        UIHomeController.Instance.DialogWeapons.SetActive(false);
        UIHomeController.Instance.DialogAssistants.SetActive(true);
    }
}
