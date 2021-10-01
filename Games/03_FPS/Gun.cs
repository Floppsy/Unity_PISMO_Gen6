using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
    [Header("Ammo:")]
    public int maxAmmo;
    int currentAmmo;
    public Text ammoText;

    [Header("About Weapon:")]
    public float fireRate;
    float fireRateReset;
    public float accuracy = 1;
    public float reloadTime;
    float reloadTimeReset;
    public float recoil;
    public Camera mainCamera;
    public Camera scopeCamera;

    [Header("Bullet info:")]
    public Rigidbody bulletPrefab;
    public Transform bulletSpawnPosition;
    AudioSource bulletSoundSource;
    Bullet bulletScript;

    [Header("Fire mode: *Signle Fire is defoult*")]
    public bool singleFire = true; //0
    public bool automaticFire; //1
    public bool burstFire; //2
    int fireMode = 0;

    private void Start()
    {
        currentAmmo = maxAmmo;
        ShowAmmo();
        fireRateReset = fireRate;
        reloadTimeReset = reloadTime;
        bulletSoundSource = GetComponent<AudioSource>();
        bulletScript = bulletPrefab.gameObject.GetComponent<Bullet>();

        if(singleFire)
        {
            fireMode = 0;
        }
        else if(automaticFire)
        {
            fireMode = 1;
        }
        else if(burstFire)
        {
            fireMode = 2;
        }
        else
        {
            fireMode = 0;
        }
    }

    private void Update()
    {
        fireRate -= Time.deltaTime;
        reloadTime -= Time.deltaTime;

        if(Input.GetMouseButtonDown(0) && fireMode == 0 && currentAmmo > 0 && fireRate <= 0)
        {
            float xScreen = Screen.width / 2;
            float yScreen = Screen.height / 2;

            float xAcc = Random.Range(xScreen - accuracy, xScreen + accuracy);
            float yAcc = Random.Range(yScreen - accuracy, yScreen + accuracy);

            var ray = Camera.main.ScreenPointToRay(new Vector3(xAcc, yAcc, 0));

            currentAmmo--;
            ShowAmmo();

            Rigidbody cloneBullet;
            cloneBullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
            cloneBullet.velocity = bulletScript.speed * ray.direction;
        }
    }

    public void ShowAmmo()
    {
        ammoText.text = currentAmmo + "/" + maxAmmo;
    }
}
