using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnBuy : BaseButtonController
{
    private static btnBuy instance;

    [SerializeField]
    protected Text txtCoin;
    [SerializeField]
    private Text txtDame;
    [SerializeField]
    private Text txtForce;
    [SerializeField]
    private Image imageWeapon;
    private Image image;

    [SerializeField]
    protected GameObject openPanel;

    public Text TxtDame { get => txtDame; set => txtDame = value; }
    public Text TxtForce { get => txtForce; set => txtForce = value; }
    public Image ImageWeapon { get => imageWeapon; set => imageWeapon = value; }
    public static btnBuy Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
            instance = this;
    }

    protected override void OnClick()
    {
        BuyItem();
        UIHomeController.Instance.DialogNotification.SetActive(true);
    }

    protected virtual void BuyItem()
    {
        float coin = float.Parse(txtCoin.text);
        if(UIHomeController.Instance.Coin.totalCoin < coin)
        {
            UIHomeController.Instance.TxtDialog.text = "Not Enough Coin";
        }
        else
        {
            UIHomeController.Instance.TxtDialog.text = "Success";
            //UIHomeController.Instance.CurTotalCoin -= coin;
            UIHomeController.Instance.Coin.totalCoin -= coin;
            openPanel.SetActive(false);
        }
    }

    protected virtual void SaveItem()
    {

    }
}
