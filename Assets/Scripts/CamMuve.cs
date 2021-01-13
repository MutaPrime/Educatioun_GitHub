using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CamMuve : MonoBehaviour
{
    public CharacterController CC;
    public float MoveSpeed;
    public float G;
    public float Mass;
    public float YSpeed;
    public float JumpImpulse;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = this.transform.eulerAngles;
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x -= Input.GetAxis("Mouse Y");
        this.transform.eulerAngles = rotation;
        float shift = Input.GetAxis("Vertical");

        Vector3 forward = this.transform.forward * Input.GetAxis("Vertical");
        Vector3 right = this.transform.right * Input.GetAxis("Horizontal");
        Vector3 SummaryVector = (forward + right) * MoveSpeed;
        SummaryVector.y = 0;
        if (!CC.isGrounded)
        {
            YSpeed -= (G * Time.deltaTime) * (Mass / 1000);
        }
        else
        {
            YSpeed = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                YSpeed = JumpImpulse * (Mass / 1000);
            }
        }
        SummaryVector.y = YSpeed;

        CC.Move(SummaryVector);
    }
}