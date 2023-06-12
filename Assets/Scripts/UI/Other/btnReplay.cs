using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnReplay : BaseButtonController
{
    protected override void OnClick()
    {
        Time.timeScale = 1f;
        if (UIPlayerDie.Instance.PauseUI.activeInHierarchy)
        {
            UIPlayerDie.Instance.PauseUI.SetActive(false);
        } else if (UIPlayerDie.Instance.UiplayerDie.activeInHierarchy)
        {
            UIPlayerDie.Instance.UiplayerDie.SetActive(false);
        }
        else if (UIManagerController.Instance.PanelWin.activeInHierarchy)
        {
            UIManagerController.Instance.PanelWin.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
