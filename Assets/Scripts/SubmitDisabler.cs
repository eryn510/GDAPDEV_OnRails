using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitDisabler : MonoBehaviour
{
    public GameObject submitButton;

    // Start is called before the first frame update
    void Start()
    {
        if(OfflineModeManager.Instance.isOfflineModeEnabled == true)
        {
            submitButton.SetActive(false);
        }
        else
        {
            submitButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
