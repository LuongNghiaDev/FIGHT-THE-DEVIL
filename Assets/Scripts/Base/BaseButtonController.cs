using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButtonController : MonoBehaviour
{
    [Header("Base Button")]
    [SerializeField] protected Button button;

    protected virtual void Awake()
    {
        this.LoadComponent();
    }

    private void Start()
    {
        this.AddOnClickEvent();
    }

    protected virtual void LoadComponent()
    {
        this.LoadButton();
    }

    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();

    }

    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();

}
