using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum GameState
{
    Playing,
    Paused,
    Victory,
    Defeat


}

public class GameManager : MonoBehaviour
{
    DeliveryManager m_deliveryManager;
    public float m_matchDuration = 180f;


    public int m_deliveryCount = 0;


    public float m_currentDuration;
    public int      m_totalDeliveryCount = 0;
    public int      m_currentDeliveryCount = 0;




    public static GameManager Instance;
    public GameState m_currentState { get; set; }

    //UI -- VICTORY, DEFEAT
    public GameObject m_defeatScreen;
    public GameObject m_victoryScreen;


    

    public void CountDown(float DeltaTime)
    {
        if (m_currentDuration <= 0)
        {
            m_currentState = GameState.Defeat;
        }
        m_currentDuration -= DeltaTime;
    }

    

    public void StartGame()
    {
        m_currentState = GameState.Playing;
        m_currentDuration = m_matchDuration;


    }

    public void IncreaseDeliveryCount()
    {
        m_currentDeliveryCount++;
    }

    private void Update()
    {
        switch (m_currentState)
        {
            case GameState.Playing:
                CountDown(Time.deltaTime);
                break;
            case GameState.Defeat:
                Time.timeScale = 0;
                break;

                

        }
        
        if (m_currentDeliveryCount == m_totalDeliveryCount)
        {
            m_currentState = GameState.Victory;
        }



    }

    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        StartGame();
    }



}
