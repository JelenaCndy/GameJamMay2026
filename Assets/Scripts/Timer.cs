using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float countdown;
    [SerializeField] TextMeshProUGUI timerText;

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else if (countdown < 0.11)
        {
            countdown = 0;
        }

        int seconds = Mathf.FloorToInt(countdown);
        timerText.text = string.Format("{0:00}", seconds);
    }
}
