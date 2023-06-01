using System;
using UnityEngine;
public class AimBullet : MonoBehaviour,IBullet
{
    private float speed = 100f;
    [SerializeField] private int damage = 1;
    private Rigidbody rb;
    public Transform launcher;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Move();
    }
    private void FixedUpdate()
    {
        //Move();
    }

    public void Setup(params Transform[] transforms)
    {
        this.launcher = transforms[0];
    }

    public void Move()
    {
        rb.AddForce(launcher.forward * speed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damageTarget = collision.gameObject.GetComponent<ITakeDamage>();
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "bariea")
        {
            Debug.Log("bariea");
            collision.gameObject.GetComponent<ITakeDamage>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (damageTarget != null)
        {
            damageTarget.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag != "Bullet")//弾同士が衝突してもなくならない
        {
            Destroy(this.gameObject);
        }
    }
}

