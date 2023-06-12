using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnOpenQuestion : BaseButtonController
{
    [SerializeField]
    protected GameObject dialogDetail;

    protected override void OnClick()
    {
        if(dialogDetail.activeInHierarchy)
        {
            dialogDetail.SetActive(false);
        } else
        {
            dialogDetail.SetActive(true);
        }
    }
}
