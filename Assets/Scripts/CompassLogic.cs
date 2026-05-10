using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CompassLogic : MonoBehaviour
{
    public RectTransform    m_needle;
    public float            m_radius = 0.5f;
    RectTransform           m_center;
    public Vector3          m_direction;
    public DeliveryManager  m_delivery;



    private void Update()
    {
        Calculate();

        //CalcTest();
    }

    private void Start()
    {
        m_center = GetComponent<RectTransform>();
    }

    public void Calculate()
    {
        if (m_delivery.m_currentDeliveryTarget == null)
        {
            return;
        }
        Vector3 worldDir = m_delivery.m_currentDeliveryTarget.transform.position - m_delivery.m_player.transform.position;
        
        Vector3 localDir = m_delivery.m_player.transform.InverseTransformDirection(worldDir);

        float angleRadians = Mathf.Atan2(localDir.x, localDir.z);

        float x = Mathf.Sin(angleRadians) * m_radius;
        float y = Mathf.Cos(angleRadians) * m_radius;

        m_needle.localPosition = new Vector3(x, y, 0);

        float angleDegrees = angleRadians * Mathf.Rad2Deg;
        m_needle.localRotation = Quaternion.Euler(0, 0, -angleDegrees);


    }


    public void CalcTest()
    {

        if (m_delivery.m_currentDeliveryTarget == null)
        {
            Debug.Log("FAILED TO GET DELIVERY TARGET!!!!");
            return;
        }
        var target_pos_local = m_delivery.m_currentDeliveryTarget.transform.InverseTransformPoint(m_delivery.m_currentDeliveryTarget.transform.position);
        var angle_target_h = Mathf.Atan2(target_pos_local.x, target_pos_local.z) * Mathf.Rad2Deg;
        float whichWay = Vector3.Cross(m_delivery.m_player.transform.forward, target_pos_local).y;
        float pointing = m_delivery.m_player.transform.localEulerAngles.y;

        if (whichWay > 0)
        {
            angle_target_h = -angle_target_h;
        }
        m_needle.transform.eulerAngles = new Vector3(0, 0, -pointing);
    }

    // Start is called before the first frame update

    /*
    private void Awake()
    {
        m_center = transform.GetComponent<RectTransform>(); 
        
    }




    private void CalculatePosition()
    {

        Vector2     positionTarget = m_center.anchoredPosition;
        float x =   positionTarget.x * radius * Mathf.Cos(Time.deltaTime);
        float y =   positionTarget.y * radius * Mathf.Sin(Time.deltaTime);

        Debug.Log(positionTarget.x);

        Vector2 result = new Vector2(x, y);

        m_needle.anchoredPosition += result;

    }

    // Update is called once per frame
    void Update()
    {
        CalculatePosition();    
    }
     */
}
