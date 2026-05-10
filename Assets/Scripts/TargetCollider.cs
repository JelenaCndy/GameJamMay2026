using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class TargetCollider : MonoBehaviour
{

    bool        isActive = false;
    BoxCollider m_collider;


    private void Awake()
    {
        m_collider = GetComponent<BoxCollider>();
        m_collider.isTrigger = true;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit SOMETHING TRIG ENTER!!!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HIT SOMETHING COL ENTER");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
