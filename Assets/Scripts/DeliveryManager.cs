using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;




public struct DeliveryData
{

    public GameObject   m_target;
    public bool         m_isTarget;

}

public class DeliveryManager : MonoBehaviour
{

    public int                      m_maxActiveTargets;
    public List<GameObject>         m_possibleTargetslist;


    public List<DeliveryData>       m_activeTargetList = new();
    public              GameObject  m_currentDeliveryTarget = null;
    public    GameObject            m_player;


    private void FixedUpdate()
    {
        GameObject closestObject = GetClosestTarget(m_player.transform.position);
        if (!closestObject)
        {
            return;
        }
        m_currentDeliveryTarget = GetClosestTarget(m_player.transform.position);

    }


    private void OnDrawGizmos()
    {
        if (!m_player || !m_currentDeliveryTarget)
        {
            return;
        }
        Gizmos.color = Color.green;
        Gizmos.DrawLine(m_player.transform.position, m_currentDeliveryTarget.transform.position);
         

    }

    private void Awake()
    {
        init();
    }

    private void init()
    {
        RandomlySelectTarget();
    }

    private bool IsDistanceCloser(Vector3 distanceA, Vector3 distanceB)
    {

        if (distanceA.sqrMagnitude < distanceB.sqrMagnitude)
        {
            return true;
        }
        return false;
    }

    public void PushToObjectList()
    {

    }

    private void RandomlySelectTarget()
    {


        for (int i = 0; i < m_maxActiveTargets; i++)
        {
            

            int maxIndex    = m_possibleTargetslist.Count;
            int randomIndex = Random.Range(0, maxIndex);

            DeliveryData data;
            data.m_target   = m_possibleTargetslist[randomIndex];
            data.m_isTarget = true;

            m_activeTargetList.Add(data);
            continue;

        }

        return;
        

    }
    

    //Find the closest target to origin, ie player.position, and return it.
    public GameObject GetClosestTarget(Vector3 origin)
    {
        if (m_activeTargetList.Count <= 0)
            return null;

        GameObject toReturn = null;
        Vector3 shortestDistance = Vector3.zero;

        for (int i = 0; i < m_activeTargetList.Count; i++)
        {
            var current = m_activeTargetList[i];
            if (i == 0 && !m_currentDeliveryTarget)
            {
                shortestDistance = current.m_target.transform.position - origin;
            }
            else if(m_currentDeliveryTarget)
            {
                shortestDistance = m_currentDeliveryTarget.transform.position - origin;
                toReturn = m_currentDeliveryTarget;
            }

            if (!current.m_isTarget)
            {
                Debug.Log("Fetching Data");
                continue;
            }
            Vector3 currentDistance = current.m_target.transform.position - origin;

            if (IsDistanceCloser(currentDistance, shortestDistance))
            {
                shortestDistance = currentDistance;

            }
            toReturn = current.m_target;
            


            


        }

        return toReturn;

        

    }



    

}
