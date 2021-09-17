using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevelTime : MonoBehaviour
{
    public Text textToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        textToDisplay.text = TimeManager.Instance.timeToDisplay.ToString(@"mm\:ss\:fff");
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
