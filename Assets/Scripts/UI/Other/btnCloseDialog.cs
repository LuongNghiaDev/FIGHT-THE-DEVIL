using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnCloseDialog : BaseButtonController
{
    protected override void OnClick()
    {
        if(UIHomeController.Instance.DialogShop.activeInHierarchy)
        {
            UIHomeController.Instance.DialogShop.SetActive(false);
        } else if(UIHomeController.Instance.DialogUpgrade.activeInHierarchy)
        {
            UIHomeController.Instance.DialogUpgrade.SetActive(false);
        } else if(UIHomeController.Instance.DialogSetting.activeInHierarchy)
        {
            UIHomeController.Instance.DialogSetting.SetActive(false);
        }
        else if (UIHomeController.Instance.DialogSupport.activeInHierarchy)
        {
            UIHomeController.Instance.DialogSupport.SetActive(false);
        }
        else if (UIHomeController.Instance.DialogWarning.activeInHierarchy)
        {
            UIHomeController.Instance.DialogWarning.SetActive(false);
        }
        else if (UIHomeController.Instance.DialogModelOption.activeInHierarchy)
        {
            UIHomeController.Instance.DialogModelOption.SetActive(false);
        }
    }
}
