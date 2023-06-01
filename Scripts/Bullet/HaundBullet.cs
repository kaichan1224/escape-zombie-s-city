using System;
using UnityEngine;
public class HaundBullet : MonoBehaviour, IBullet
{
    private float speed = 50f;
    [SerializeField] private int damage = 1;
    private Rigidbody rb;
    public Transform launcher;
    private Vector3 launchDirection;
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
        //UpdateMove();
    }

    public void Setup(params Transform[] transforms)
    {
        this.launcher = transforms[0];
    }

    public void Move()
    {
        launchDirection = new Vector3(launcher.forward.x , launcher.forward.y+2f, launcher.forward.z);
        rb.AddForce(launchDirection * speed,ForceMode.VelocityChange);
    }

    public void UpdateMove()
    {
        launchDirection = new Vector3(launcher.forward.x, launcher.forward.y - 3f, launcher.forward.z);
        rb.AddForce(launcher.forward * speed, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damageTarget = collision.gameObject.GetComponent<ITakeDamage>();
        if (damageTarget != null)
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