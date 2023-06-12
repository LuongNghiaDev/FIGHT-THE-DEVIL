using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnUseAssitants : BaseButtonController
{
    private static btnUseAssitants instance;
    [SerializeField]
    protected Text txtName;

    private List<string> listAssitant = new List<string>();
    public List<string> ListAssitant { get => listAssitant; }
    public static btnUseAssitants Instance { get => instance; }

    [SerializeField]
    protected Text txtButton;

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
            instance = this;
    }

    protected override void OnClick()
    {
        if(txtButton.text == "Use")
        {
            listAssitant.Add(txtName.text);
        } else if(txtButton.text == "Undo")
        {
            listAssitant.Clear();
        }
    }
}
