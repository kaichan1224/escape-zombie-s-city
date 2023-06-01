using System.Collections;
using System.Collections.Generic;

public interface IState
{
    public void Enter() { }//最初に状態に入った時に実行されるコード
    public void Update() { }//フレーム単位のロジックで、新しい状態に移行するための条件
    public void FixedUpdate() { }//物理演算rigidbodyに対する処理はこちらに
    public void Exit() { }//状態を抜ける時に実行されるコード
}