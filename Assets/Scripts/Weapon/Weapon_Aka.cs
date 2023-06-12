using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Aka : MonoBehaviour
{
    private static Weapon_Aka instance;

/*    private int damage;*/
    public List<Transform> firePos;
    public float timeBtwfire = 2f;
/*    private int bulletForce;*/
    public GameObject muzzle;
    public GameObject fireEffect;
    private float timeBtwfireCounter;
    [SerializeField]
    private Gun modelGun;
    [SerializeField]
    private SoundGun soundGun;

    public static Weapon_Aka Instance { get => instance; }
/*    public int Damage { get => damage; set => damage = value; }
*/    public Gun ModelGun { get => modelGun; }

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }


    private void FixedUpdate()
    {
        WeaponController.Instance.RotateGun(gameObject);
        timeBtwfireCounter -= Time.fixedDeltaTime;
        if (Input.GetMouseButton(0) && timeBtwfireCounter < 0)
        {
            AudioController.Instance.playSound(soundGun.weaponSound);
            FireBullet();
        }
    }

    protected virtual void FireBullet()
    {
        for(int i=0; i<firePos.Count;i++)
        {
            GameObject bulletFabs = ObjectPoolController.Instance.GetPoolObject();
            if(bulletFabs != null)
            {
                bulletFabs.SetActive(true);
                timeBtwfireCounter = timeBtwfire;
                bulletFabs.transform.position = firePos[i].position;

                Instantiate(muzzle, firePos[i].position, transform.rotation, transform);
                Instantiate(fireEffect, firePos[i].position, transform.rotation, transform);

                Rigidbody2D rg = bulletFabs.GetComponent<Rigidbody2D>();
                rg.AddForce(transform.right * modelGun.force, ForceMode2D.Impulse);

            }
        }
    }

}
