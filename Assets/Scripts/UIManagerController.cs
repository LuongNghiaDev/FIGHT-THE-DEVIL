using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerController : BaseMonobehavior
{
    private static UIManagerController instance;

    [SerializeField]
    private List<Image> listImage;
    [SerializeField]
    protected Text txtCoin;
    [SerializeField]
    protected Text txtBomb;
    [SerializeField]
    protected Text txtTimerCount;
    [SerializeField]
    protected float totalTime = 2 * 30;
    private float timeRemaining;
    [SerializeField]
    private GameObject panelWin;
    [SerializeField]
    private GameObject map1;
    [SerializeField]
    private GameObject map2;
    [SerializeField]
    protected Camera cam;

    public List<Image> ListImage { get => listImage; set => listImage = value; }
    public static UIManagerController Instance { get => instance; }
    public GameObject PanelWin { get => panelWin; set => panelWin = value; }
    public float TimeRemaining { get => timeRemaining; set => timeRemaining = value; }

    protected override void Awake()
    {
        if (instance == null)
            instance = this;
    }

    protected override void Start()
    {
        if(PlayerPrefs.GetInt("Level") == 1)
        {
            map1.SetActive(true);
            map2.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Level") == 2)
        {
            map2.SetActive(true);
            map1.SetActive(false);
        }
        Time.timeScale = 1f;
        txtCoin.text = "0 x";
        txtBomb.text = "0 x";
        txtTimerCount.gameObject.SetActive(true);
        timeRemaining = totalTime;
    }

    private void Update()
    {
        EditUIHealth();
        EditUIItem();
        this.TimerDeduct();
    }

    protected virtual void TimerDeduct()
    {
        timeRemaining -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        string timerText = string.Format("{0:00}:{1:00}", minutes, seconds);
        txtTimerCount.text = timerText;

        if (timeRemaining <= 0f)
        {
            txtTimerCount.text = "00:00";
        }
    }

    protected virtual void EditUIItem()
    {
        if (txtCoin != null)
        {
            PlayerPrefs.SetFloat("CoinTxt", ItemController.Instance.CountCoin);
            txtCoin.text = ItemController.Instance.CountCoin + " x";
        }
        if (txtBomb != null)
            txtBomb.text = ItemController.Instance.CountBomb + " x";
    }
    
    protected virtual void EditUIHealth()
    {
        for (int i = 0; i < listImage.Count; i++)
        {
            if (PlayerHeathController.Instace.CurrentHealth == 5)
            {
                listImage[5].gameObject.SetActive(false);
            }
            if (PlayerHeathController.Instace.CurrentHealth == 4)
            {
                listImage[4].gameObject.SetActive(false);
            }
            if (PlayerHeathController.Instace.CurrentHealth == 3)
            {
                listImage[3].gameObject.SetActive(false);
            }
            if (PlayerHeathController.Instace.CurrentHealth == 2)
            {
                listImage[2].gameObject.SetActive(false);
            }
            if (PlayerHeathController.Instace.CurrentHealth == 1)
            {
                listImage[1].gameObject.SetActive(false);
            }
            if (PlayerHeathController.Instace.CurrentHealth == 0)
            {
                listImage[0].gameObject.SetActive(false);
            }
        }
/*        GameObject player = FindObjectOfType<Player>().gameObject;
        if(player.activeInHierarchy == false)
        {
            listImage[1].gameObject.SetActive(false);
            listImage[3].gameObject.SetActive(false);
            listImage[5].gameObject.SetActive(false);
            listImage[2].gameObject.SetActive(false);
            listImage[4].gameObject.SetActive(false);
        }*/
    }
}
