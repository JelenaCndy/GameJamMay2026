using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CompassLogic : MonoBehaviour
{
    public RectTransform    m_needle;
    public float            radius = 0.5f;
    RectTransform           m_center;


    // Start is called before the first frame update


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
}
