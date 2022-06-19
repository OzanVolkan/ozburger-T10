using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public float timeRemaining = 300;
    public bool timerIsRunning = false;
    public Text timeText;
    public GameObject failScreen;
    private void Start()
    {
        instance = this;
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                failScreen.SetActive(true);
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
            //timeText.text = timeRemaining.ToString();

        }

    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
