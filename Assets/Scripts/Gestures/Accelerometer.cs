using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Accelerometer : MonoBehaviour
{
    public float shakeDetectionThreshold;
    public float minShakeInterval;

    private float sqrSDT;
    private float timeSinceLastShake;
    public GameObject revivePanel;
    public GameObject gameplayPanel;

    // Start is called before the first frame update
    void Start()
    {
        sqrSDT = Mathf.Pow(shakeDetectionThreshold, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.sqrMagnitude >= sqrSDT && Time.unscaledTime >= timeSinceLastShake + minShakeInterval)
        {
            revivePanel.SetActive(false);
            gameplayPanel.SetActive(true);
            BGMManager.BGMInstance.playBGM();
            Time.timeScale = 1;
            timeSinceLastShake = Time.unscaledTime;
        }
    }

    
}
