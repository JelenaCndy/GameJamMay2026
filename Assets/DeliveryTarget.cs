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

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            isPickable = false;
            GameManager.Instance.IncreaseDeliveryCount();
        }

    }






}
