using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class TargetCollider : MonoBehaviour
{

    bool isActive = false;
    SphereCollider m_collider;


    private void Awake()
    {
        m_collider = GetComponent<SphereCollider>();

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
