using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private static WeaponController instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public static WeaponController Instance { get => instance; }

    public virtual void RotateGun(GameObject gameObject)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - gameObject.transform.position;
        //lay vi tri sung den con tro chuot

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        gameObject.transform.rotation = rotation;

        if(gameObject.transform.eulerAngles.z > 90 && gameObject.transform.eulerAngles.z < 270)
        {
            gameObject.transform.localScale = new Vector3(1, -1, 0);
        } else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 0);
        }
    }

}
