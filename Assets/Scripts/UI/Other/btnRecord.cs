using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnRecord : BaseButtonController
{
    protected override void OnClick()
    {
        UIPlayerDie.Instance.RecordUI.SetActive(true);
    }
}
