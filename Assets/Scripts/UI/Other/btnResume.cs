using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnResume : BaseButtonController
{
    protected override void OnClick()
    {
        Time.timeScale = 1f;
        UIPlayerDie.Instance.PauseUI.SetActive(false);
    }
}
