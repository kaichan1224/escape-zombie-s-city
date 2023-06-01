using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShot: MonoBehaviour,IShotStrategy
{
    [SerializeField] private GameObject weapon;
    private void Update()
    {
        Shot();
    }

    public void Shot()
    {
        weapon.GetComponent<IWeapon>().Fire();
    }
}
