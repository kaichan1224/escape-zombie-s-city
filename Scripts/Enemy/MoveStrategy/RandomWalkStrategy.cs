using System;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomWalkStrategy : IMoveStrategy
{
    private GameObject targetObject;
    [SerializeField] private float stopDistance = 1.0f;
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    private Rigidbody rb;
    private Transform transform;
    private Transform target;
    public RandomWalkStrategy(Transform transform, Rigidbody rb, Transform target)
    {
        this.rb = rb;
        this.target = target;
        this.transform = transform;
    }

    //プレハブから生成するときに初期化すべきことを記述
    public void Setup(Transform target)
    {
        this.target = target;
    }
    public void Move()
    {
    }
}


