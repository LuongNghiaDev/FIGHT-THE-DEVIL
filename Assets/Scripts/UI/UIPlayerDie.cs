using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerDie : MonoBehaviour
{
    private static UIPlayerDie instance;

    [SerializeField]
    private GameObject uiplayerDie;

    [SerializeField]
    private GameObject pauseUI;

    [SerializeField]
    private GameObject recordUI;

    [SerializeField]
    private Text txtCoin;
    [SerializeField]
    private Text txtEnemy;
    [SerializeField]
    private Text txtCoinRecord;
    [SerializeField]
    private Text txtEnemyRecord;
    private float coin = 0f;
    private int enemy = 0;

    [SerializeField]
    protected Score scoreRecord;
    [SerializeField]
    private Coin coinModel;

    public static UIPlayerDie Instance { get => instance; set => instance = value; }
    public Text TxtCoin { get => txtCoin; set => txtCoin = value; }
    public Text TxtEnemy { get => txtEnemy; set => txtEnemy = value; }
    public GameObject UiplayerDie { get => uiplayerDie; set => uiplayerDie = value; }
    public Text TxtCoinRecord { get => txtCoinRecord; set => txtCoinRecord = value; }
    public Text TxtEnemyRecord { get => txtEnemyRecord; set => txtEnemyRecord = value; }
    public GameObject PauseUI { get => pauseUI; set => pauseUI = value; }
    public GameObject RecordUI { get => recordUI; set => recordUI = value; }
    public Coin CoinModel { get => coinModel; set => coinModel = value; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        coin = PlayerPrefs.GetFloat("CoinTxt");
        enemy = PlayerPrefs.GetInt("EnemyTxt");
        if (coin >= scoreRecord.coinRecord)
        {
            scoreRecord.coinRecord = coin;
        }
        if (enemy >= scoreRecord.enemyRecord)
        {
            scoreRecord.enemyRecord = enemy;
        }

        txtCoin.text = "Coin: x" + coin;
        txtEnemy.text = "Enemy: x" + enemy;
        txtCoinRecord.text = "Coin: x" + scoreRecord.coinRecord;
        txtEnemyRecord.text = "Enemy: x" + scoreRecord.enemyRecord;
    }
}
