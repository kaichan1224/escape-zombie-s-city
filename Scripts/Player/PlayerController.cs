using UnityEngine;
using System;

[Serializable]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StateMachine playerStateMachine;
    public Animator animator;
    public StateMachine PlayerStateMachine => playerStateMachine;
    public Rigidbody rb;
    public PlayerInput playerInput;
    public bool isShot = false;
    public int healthvalue = 50;
    public float jumppower = 100f;
    public GameObject weapon;//ここもOOPで武器の切り替えできるようにクラス設計後々する
    public Health health;
    public bool isDead;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        playerStateMachine = new StateMachine(this);
        health = GetComponent<Health>();
    }

    private void Start()
    {
        health.InitializeHealth(healthvalue);
        isDead = false;
        health.OnDeath.AddListener(Death);
        playerStateMachine.Initialize(playerStateMachine.idleState);
    }

    private void Update()
    {
        if(!isDead)
            playerStateMachine.Update();
    }

    private void FixedUpdate()
    {
        if (!isDead)
            playerStateMachine.FixedUpdate();

    }

    public void Death()
    {
        isDead = true;
        animator.SetTrigger("isDeath");
    }

    //アニメーションから呼ぶ
    private void DestroyPlayer()
    {
        Destroy(this.gameObject);
    }
}