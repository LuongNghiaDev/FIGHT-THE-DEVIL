using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnUpgrade : BaseButtonController
{
    [SerializeField]
    protected Text txtCoin;
    [SerializeField]
    protected Text txtDame;
    [SerializeField]
    protected Text txtForce;
    [SerializeField]
    private Gun modelGun;

    protected override void OnClick()
    {
        UpgradeItem();
        UIHomeController.Instance.DialogNotification.SetActive(true);
    }

    protected virtual void UpgradeItem()
    {
        float coin = float.Parse(txtCoin.text);

        if (UIHomeController.Instance.Coin.totalCoin < coin)
        {
            UIHomeController.Instance.TxtDialog.text = "Not Enough Coin";
        }
        else
        {
            //UIHomeController.Instance.CurTotalCoin -= coin;
            UIHomeController.Instance.Coin.totalCoin -= coin;
            modelGun.dame += 1;
            modelGun.force += 1;
            UIHomeController.Instance.TxtDialog.text = "Upgrade Success";
            txtDame.text = "Dame: " + modelGun.dame;
            txtForce.text = "Force: " + modelGun.force;
        }
    }
}
