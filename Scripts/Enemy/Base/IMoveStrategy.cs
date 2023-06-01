using System;
using UnityEngine;

public interface IMoveStrategy
{
    public void Move();
    //プレハブから生成するときに初期化すべきことを記述
    public void Setup(Transform target);
}

