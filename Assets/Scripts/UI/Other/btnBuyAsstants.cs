using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnBuyAsstants : BaseButtonController
{
    private static btnBuyAsstants instance;

    [SerializeField]
    protected Text txtCoin;
    [SerializeField]
    protected GameObject panel;

    public static btnBuyAsstants Instance { get => instance; }
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

    private void BuyItem()
    {
        float coin = float.Parse(txtCoin.text);
        if (UIHomeController.Instance.Coin.totalCoin < coin)
        {
            UIHomeController.Instance.TxtDialog.text = "Not Enough Coin";
        }
        else
        {
            panel.SetActive(false);
            UIHomeController.Instance.TxtDialog.text = "Success";
            UIHomeController.Instance.Coin.totalCoin -= coin;
        }
    }
}
