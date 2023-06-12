using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDialog : BaseButtonController
{
    [SerializeField]
    protected GameObject panel;

    protected override void OnClick()
    {
        panel.SetActive(true);
    }
}
