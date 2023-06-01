using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropExpBallController : MonoBehaviour
{
    [SerializeField] private int exp = 50;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLevelController>().AddExperience(exp);
            Destroy(this.gameObject);
        }
    }
}
