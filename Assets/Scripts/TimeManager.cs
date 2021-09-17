using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    [HideInInspector] public float measuredTime;
    [HideInInspector] public TimeSpan timeToDisplay;

    bool stopwatchActive = false;
    public bool canClickLeaderBoard = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        measuredTime = 0;
        startStopWatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchActive == true)
        {
            measuredTime += Time.deltaTime;
        }
        timeToDisplay = TimeSpan.FromSeconds(measuredTime);
    }

    public void startStopWatch()
    {
        stopwatchActive = true;
    }

    public void stopStopWatch()
    {
        stopwatchActive = false;
        canClickLeaderBoard = true;
    }
}
