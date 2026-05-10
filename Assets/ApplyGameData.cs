using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ApplyGameData : MonoBehaviour
{
    public TextMeshProUGUI m_deliveryCount;
    GameManager m_gameManager;
    // Start is called before the first frame update


    private void Awake()
    {
        m_gameManager = GameManager.Instance;
    }
    void Start()    
    {
        
    }

    public string FormatString()
    {

        string temp = $"Current Score: {m_gameManager.m_currentDeliveryCount}";
        return temp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_deliveryCount.text = FormatString();
    }
}
