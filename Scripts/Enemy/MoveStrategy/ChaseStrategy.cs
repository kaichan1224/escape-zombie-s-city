using System;
using UnityEngine;
using UnityEngine.UIElements;

public class ChaseStrategy : MonoBehaviour,IMoveStrategy
{
    [SerializeField] private float stopDistance = 30.0f;
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    private Rigidbody rb;
    [SerializeField] private Transform target;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //プレハブから生成するときに初期化すべきことを記述
    public void Setup(Transform target)
    {
        this.target = target;
    }

    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        if (target == null)
            return;
        // 自分自身と目標Transformの距離を計算する
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        // 距離が一定値以下である場合は移動を止める
        if (distanceToTarget <= stopDistance)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        // 目標Transformに向かって移動する
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        rb.velocity = directionToTarget * moveSpeed;

        // y軸方向を中心に回転する
        Vector3 targetPosition = target.position;
        targetPosition.y = transform.position.y;
        Vector3 directionToTargetOnXZPlane = (targetPosition - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToTargetOnXZPlane, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

