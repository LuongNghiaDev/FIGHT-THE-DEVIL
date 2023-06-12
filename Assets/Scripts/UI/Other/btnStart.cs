using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnStart : BaseButtonController
{
    public float timer = 3f;
    public LevelGame levelGame;

    protected override void OnClick()
    {
        UIHomeController.Instance.DialogWarning.SetActive(true);
        if(levelGame.ToString() == "level1")
        {
            PlayerPrefs.SetInt("Level", 1);
        } else if(levelGame.ToString() == "level2")
        {
            PlayerPrefs.SetInt("Level", 2);
        }
    }

    private void Update()
    {
        if(UIHomeController.Instance.DialogWarning.gameObject.activeInHierarchy)
        {
            if (this.timer <= 0f)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                this.timer -= Time.deltaTime;
            }
        }
    }
}

public enum LevelGame 
{ 
    level1,
    level2
}
