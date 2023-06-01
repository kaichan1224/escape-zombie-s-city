using System;
using UnityEngine;

public class Pistol: MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireInterval = 0.5f;
    [SerializeField] private int bulletCnt = 10;
    [SerializeField] private Transform launcher;
    private float lastFireTime = -0.5f;
    public void Setup(Transform launcher)
    {
        this.launcher = launcher;
    }
    public void Fire()
    {
        float currentTime = Time.time;
        if (currentTime - lastFireTime < fireInterval)
            return;
        GameObject tmp = Instantiate(bullet, transform.position, Quaternion.identity);
        tmp.GetComponent<IBullet>().Setup(launcher);
        lastFireTime = currentTime;
    }
}

