using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnExitRecord : BaseButtonController
{
    protected override void OnClick()
    {
        UIPlayerDie.Instance.RecordUI.SetActive(false);
    }
}
