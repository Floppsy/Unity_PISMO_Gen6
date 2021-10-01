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
    public float accuracy;
    public float reloadTime;
    float reloadTimeReset;
    public float recoil;
    public Camera mainCamera;
    public Camera scopeCamera;

    [Header("Bullet info:")]
    public Rigidbody bulletPrefab;
    public Transform bulletSpawnPosition;
    AudioSource bulletSoundSource;
    //Bullet script

    [Header("Fire mode:")]
    public bool singleFire = true;
    public bool automaticFire;
    public bool burstFire;

    private void Start()
    {
        
    }
}
