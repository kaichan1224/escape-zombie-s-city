using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bariea : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private int healthValue;
    // Start is called before the first frame update
    void Awake()
    {
        //health = GetComponent<Health>();
    }

    private void Start()
    {
        health.InitializeHealth(healthValue);
        health.OnDeath.AddListener(Break);
    }

    // Update is called once per frame
    void Break()
    {
        Destroy(this.gameObject);
    }
}
