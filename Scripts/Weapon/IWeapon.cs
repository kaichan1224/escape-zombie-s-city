using System;
using UnityEngine;

public interface IWeapon
{
    public void Fire();
    public void Setup(Transform launcher);
}

