using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //float elapsedTime;

    // Update is called once per frame
    void Update()
    {
        //elapsedTime += Time.deltaTime;
    }

    public void CountDown(float remainingTime, TextMeshProUGUI timerText)
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;

            //timerText.color = Color.red;
        }

        //remainingTime -= Time.deltaTime;
        int minuets = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minuets, seconds);
    }
}
