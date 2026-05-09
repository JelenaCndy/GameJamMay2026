using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class test : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController m_controller;
    public Vector3 m_Acceleration = Vector3.zero;
    public float gravity = 0.2f;

    private void Awake()
    {
        m_controller = transform.GetComponent<CharacterController>();   
    }


    void ApplyGravity()
    {
        if (m_controller.isGrounded == true)
        {
            m_Acceleration = Vector3.zero;
            return;
        }
        m_Acceleration.y -= gravity;

        Vector3 movement = Vector3.Lerp(transform.position, m_Acceleration, Time.deltaTime);

        m_controller.Move(movement * Time.deltaTime);


    }


    private void Update()
    {

        ApplyGravity();
       if (Input.GetKey(KeyCode.W))
        {
            m_controller.Move(new Vector3(0, 0, 1) * Time.deltaTime);


        }
       if (Input.GetKey(KeyCode.S))
        {
            m_controller.Move(new Vector3(0, 0, -1));

        }


    }

}
