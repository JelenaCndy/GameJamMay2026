using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



[DisallowMultipleComponent]
public class Compass : MonoBehaviour
{




    [HideInInspector] public Vector3    m_targetPos => m_target.transform.position;
    public GameObject                          m_target;
    float                               m_radius = 80f;

    public Vector3 direction => CalculateDirection();

    private Vector3 CalculateDirection()
    {
        if(m_target == null) { return Vector3.zero; }
        Vector3 ourPos = transform.position;
        Vector3 rotationAxis = Vector3.Cross(m_targetPos, ourPos);

        return  m_radius * rotationAxis;

    }

    private void OnDrawGizmos()
    {
        if (!m_target) { return; }
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, direction);

    }

}
