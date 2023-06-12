using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonobehavior : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void LoadComponents()
    {

    }

    protected virtual void OnEnable()
    {
        
    }

    protected virtual void ResetValue()
    {

    }

    protected virtual void Reset()
    {
        
    }
}
