using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector3 inputVector;
    private float xInput;
    private float yInput;
    private float zInput;
    public float shiftInput;
    public float spaceInput;
    public float mouseInput;
    public void HandleInput()
    {
        xInput = 0;
        yInput = 0;
        zInput = 0;
        shiftInput = 0;
        spaceInput = 0;
        mouseInput = 0;
        if (Input.GetKey(KeyCode.W))
            zInput++;
        if (Input.GetKey(KeyCode.A))
            xInput--;
        if (Input.GetKey(KeyCode.S))
            zInput--;
        if (Input.GetKey(KeyCode.D))
            xInput++;
        if (Input.GetKey(KeyCode.Space))
            spaceInput++;
        if (Input.GetKey(KeyCode.LeftShift))
            shiftInput++;
        if (Input.GetMouseButton(0))
            mouseInput++;
        inputVector = new Vector3(xInput,yInput,zInput);
    }

    private void Update()
    {
        HandleInput();   
    }
}
