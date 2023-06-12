using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHomeController : MonoBehaviour
{
    private static UIHomeController instance;

    public static UIHomeController Instance { get => instance; }
    public GameObject DialogShop { get => dialogShop; set => dialogShop = value; }
    public GameObject DialogSetting { get => dialogSetting; set => dialogSetting = value; }
    public GameObject DialogUpgrade { get => dialogUpgrade; set => dialogUpgrade = value; }
    public GameObject DialogAssistants { get => dialogAssistants; set => dialogAssistants = value; }
    public GameObject DialogWeapons { get => dialogWeapons; set => dialogWeapons = value; }
    public GameObject DialogNotification { get => dialogNotification; set => dialogNotification = value; }
    public Text TxtDialog { get => txtDialog; set => txtDialog = value; }
    public Coin Coin { get => coin; set => coin = value; }
    public GameObject DialogSupport { get => dialogSupport; set => dialogSupport = value; }
    public GameObject DialogWarning { get => dialogWarning; set => dialogWarning = value; }
    public GameObject DialogModelOption { get => dialogModelOption; set => dialogModelOption = value; }

    [SerializeField]
    private GameObject dialogShop;
    [SerializeField]
    private GameObject dialogSetting;
    [SerializeField]
    private GameObject dialogUpgrade;
    [SerializeField]
    private GameObject dialogAssistants;
    [SerializeField]
    private GameObject dialogWeapons;
    //dialog
    [SerializeField]
    private GameObject dialogNotification;
    [SerializeField]
    private Text txtDialog;
    [SerializeField]
    private GameObject dialogSupport;
    [SerializeField]
    private GameObject dialogWarning;
    [SerializeField]
    private GameObject dialogModelOption;

    [SerializeField]
    private Text txtTotalCoin;
    [SerializeField]
    private Coin coin;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        //GameSaveManager.Instance.SaveCoinToJson(coin.totalCoin);
    }

    private void Update()
    {
        if(GameSaveManager.Instance.LoadCoinToJson() != -1)
        {
            txtTotalCoin.text = GameSaveManager.Instance.LoadCoinToJson() + "";
        } else
        {
            float coinTotal =  PlayerPrefs.GetFloat("CoinTxt");
            txtTotalCoin.text = (coin.totalCoin + coinTotal) + "";
        }
    }
}
