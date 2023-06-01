using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            transform.position = player.transform.position + offset;
    }
}
