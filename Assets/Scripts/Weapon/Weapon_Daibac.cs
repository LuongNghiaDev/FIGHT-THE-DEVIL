using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Daibac : MonoBehaviour
{
    private static Weapon_Daibac instance;

    public GameObject bullet;
    public Transform firePos;
    public float timeBtwfire = 0.2f;
    public GameObject muzzle;
    public GameObject fireEffect;
    private float timeBtwfireCounter;
    public static Weapon_Daibac Instance { get => instance; }
    public Gun ModelGun { get => modelGun; }

    [SerializeField]
    private Gun modelGun;
    [SerializeField]
    private SoundGun soundGun;

    private void Awake()
    {
        if (instance == null)
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
            GameObject bulletFabs = Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwfireCounter = timeBtwfire;
            bulletFabs.transform.position = firePos.position;

            Instantiate(muzzle, firePos.position, transform.rotation, transform);

            Rigidbody2D rg = bulletFabs.GetComponent<Rigidbody2D>();
            rg.AddForce(transform.right * modelGun.force, ForceMode2D.Impulse);
    }
}
