using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDetail : MonoBehaviour
{
    private static WeaponDetail instance;

    [SerializeField]
    public Text txtDame1;
    [SerializeField]
    public Text txtForce1;
    [SerializeField]
    public Image image1;

    [SerializeField]
    public Text txtDame2;
    [SerializeField]
    public Text txtForce2;
    [SerializeField]
    public Image image2;

    [SerializeField]
    public Text txtDame3;
    [SerializeField]
    public Text txtForce3;
    [SerializeField]
    public Image image3;

    private List<string> nameWeapon = new List<string>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public List<string> NameWeapon { get => nameWeapon; set => nameWeapon = value; }

    public static WeaponDetail Instance { get => instance; }

    public virtual void SwapWeapon(Gun modelGun)
    {
        if(txtDame1.text == "" && txtForce1.text == "")
        {
            nameWeapon.Add(modelGun.nameGun);
            image1.sprite = modelGun.imgGun;
            txtDame1.text = "Dame: "+ modelGun.dame;
            txtForce1.text = "Force: "+modelGun.force;
        } 
        else if (txtDame2.text == "" && txtForce2.text == "")
        {
            nameWeapon.Add(modelGun.nameGun);
            image2.sprite = modelGun.imgGun;
            txtDame2.text = "Dame: " + modelGun.dame;
            txtForce2.text = "Force: " + modelGun.force;
        }
        else if (txtDame3.text == "" && txtForce3.text == "")
        {
            nameWeapon.Add(modelGun.nameGun);
            image3.sprite = modelGun.imgGun;
            txtDame3.text = "Dame: " + modelGun.dame;
            txtForce3.text = "Force: " + modelGun.force;
        }
    }

}
