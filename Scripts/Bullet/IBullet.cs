using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    public void Move();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="launcher">0番目:Launcher,1番目:Target</param>
    public void Setup(params Transform[] launcher);
}
