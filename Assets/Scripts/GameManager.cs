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

    public static void  GameManager Instance;
    public GameState m_currentState { get; set; }


    

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
    }



}
