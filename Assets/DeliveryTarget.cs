using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class DeliveryTarget : MonoBehaviour
{
    SphereCollider m_collider;
    public bool isPickable = true;
    

    

    private void Awake()
    {
        m_collider = GetComponent<SphereCollider>();
        m_collider.isTrigger = true;



    }

    private void Start()
    {
        DeliveryManager.Instance.PushToObjectList(gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We've Collided!!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PLEASE GOD FUCKING KILL ME!!");

        if (other.tag == "Player")
        {
            isPickable = false;
            GameManager.Instance.IncreaseDeliveryCount();
            Debug.Log("Picked up!!");
        }

    }






}
