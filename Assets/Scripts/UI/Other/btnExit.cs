using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnExit : BaseButtonController
{
    protected override void OnClick()
    {
        Time.timeScale = 1f;
        UIPlayerDie.Instance.PauseUI.SetActive(false);
        SceneManager.LoadScene("HomeScene");
    }
}
