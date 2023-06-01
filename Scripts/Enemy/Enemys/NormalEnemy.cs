using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy:MonoBehaviour
{
    public Health health;
    [SerializeField] private GameObject dropExpBall;
    [SerializeField] private int healthvalue = 2;
    [SerializeField] private int bodyDamage = 1;//プレイヤーへのダメージ
    [SerializeField] private float intervalAttackTime = 1f;
    private float lastAttackTime = -0.5f;
    private float currentTime;

    void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        health.InitializeHealth(healthvalue);
        health.OnDeath.AddListener(Death);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
    }

    public void Death()
    {
        Instantiate(dropExpBall, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && currentTime - lastAttackTime > intervalAttackTime)
        {
            currentTime = Time.time;
            collision.gameObject.GetComponent<ITakeDamage>().TakeDamage(bodyDamage);
            lastAttackTime = currentTime;
        }
    }

}
