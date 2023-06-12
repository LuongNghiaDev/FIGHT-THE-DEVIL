using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwapController : MonoBehaviour
{

    int totalWeapon = 1;
    [SerializeField]
    protected int currentWeaponIndex;
    [SerializeField]
    protected GameObject[] guns = new GameObject[3];
    [SerializeField]
    protected GameObject weaponHolder;
    [SerializeField]
    protected GameObject currentGun;
    [SerializeField]
    protected Transform spawnWeapon;

    private void Awake()
    {
        for (int i = 0; i < btnSaveWeapon.Instance.Weapons.Count; i++)
        {
            GameObject gun1 = Resources.Load<GameObject>("Weapons/" + btnSaveWeapon.Instance.Weapons[i]);
            GameObject newGun1 = Instantiate(gun1, spawnWeapon.position, Quaternion.identity);
            newGun1.transform.parent = spawnWeapon;

            guns = new GameObject[]
            {
                    gun1,
            };
        }

/*        GameObject gun1 = Resources.Load<GameObject>("Weapons/weaponR1");
        GameObject newGun1 = Instantiate(gun1, spawnWeapon.position, Quaternion.identity);
        newGun1.transform.parent = spawnWeapon;

        GameObject gun2 = Resources.Load<GameObject>("Weapons/weaponR2");
        GameObject newGun2 = Instantiate(gun2, spawnWeapon.position, Quaternion.identity);
        newGun2.transform.parent = spawnWeapon;

        GameObject gun3 = Resources.Load<GameObject>("Weapons/weaponR3");
        GameObject newGun3 = Instantiate(gun3, spawnWeapon.position, Quaternion.identity);
        newGun3.transform.parent = spawnWeapon;

        guns = new GameObject[]
        {
            gun1,
            gun2,
            gun3
        };*/
    }

    // Start is called before the first frame update
    void Start()
    {
        totalWeapon = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapon];

        for(int i = 0; i < totalWeapon; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //next weapon
            if(currentWeaponIndex < totalWeapon-1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //previous weapon
            if (currentWeaponIndex > 0)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
        }
    }
}
