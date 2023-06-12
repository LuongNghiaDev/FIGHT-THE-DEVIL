using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSaveWeapon : BaseButtonController
{
    private static btnSaveWeapon instance;
    private List<string> weapons = new List<string>();

    public static btnSaveWeapon Instance { get => instance; }
    public List<string> Weapons { get => weapons; set => weapons = value; }

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
            instance = this;
    }

    protected override void OnClick()
    {
        for (int i = 0; i < WeaponDetail.Instance.NameWeapon.Count; i++)
        {
            if (WeaponDetail.Instance.NameWeapon[i] == "")
            {

            }
            else
            {
                weapons.Add(WeaponDetail.Instance.NameWeapon[i]);
            }
        }
        UIHomeController.Instance.TxtDialog.text = "Save Success";
        UIHomeController.Instance.DialogNotification.SetActive(true);
        var funcCorutine = StartCoroutine(DelayCloseDialog());
        if (funcCorutine != null) StopCoroutine(DelayCloseDialog());
    }

    IEnumerator DelayCloseDialog()
    {
        yield return new WaitForSeconds(1.5f);
        UIHomeController.Instance.DialogNotification.SetActive(false);
    }
}
