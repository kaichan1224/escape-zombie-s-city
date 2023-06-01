using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponObjects;
    private List<IWeapon> weapons = new List<IWeapon>();
    [SerializeField] private int weaponIndex = 0;
    public PlayerInput playerInput;
    public bool isShot = false;
    private Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        for(int i=0;i<weaponObjects.Length;i++)
        {
            weapons.Add(weaponObjects[i].GetComponent<IWeapon>());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateMousePosition();
        if (playerInput.mouseInput == 1)
        {
            Action(weaponIndex);
        }

    }

    void RotateMousePosition()
    {
        //前フレームとの位置の差から進行方向を割り出してその方向に回転します。
        Vector3 screenPlayerPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 screenMousePos = Input.mousePosition;
        Vector3 differenceDis = new Vector3(screenMousePos.x, 0, screenMousePos.y) - new Vector3(screenPlayerPos.x, 0, screenPlayerPos.y);
        if (Mathf.Abs(differenceDis.x) > 0.001f || Mathf.Abs(differenceDis.z) > 0.001f)
        {
            Quaternion rot = Quaternion.LookRotation(differenceDis);
            rot = Quaternion.Slerp(rb.transform.rotation, rot, 0.2f);
            transform.rotation = rot;
        }
    }

    void Action(int weaponsIndex)
    {
        weapons[weaponsIndex].Fire();
    }
}
