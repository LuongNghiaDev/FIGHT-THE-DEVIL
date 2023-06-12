using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : BaseButtonController
{

    protected override void OnClick()
    {
        Time.timeScale = 0f;
        UIPlayerDie.Instance.PauseUI.SetActive(true);
    }

}
