using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class OfflineModeManager : MonoBehaviour
{
    public static OfflineModeManager Instance;

    public bool isOfflineModeEnabled = false;
    public GameObject enabledIndicator;
    public GameObject disabledIndicator;
    private bool connectionCheck;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);

        connectionCheck = CheckInternetConnection();
        if (connectionCheck == true)
        {
            onDisableOfflineMode();
        }
        else
        {
            onEnableOfflineMode();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
        StartCoroutine(CheckInternetConnection(isConnected =>
        {
            if (isConnected)
            {
                onDisableOfflineMode();
            }
            else
            {
                onEnableOfflineMode();
            }
        }));
        */
    }

    public void onEnableOfflineMode()
    {
        isOfflineModeEnabled = true;
        enabledIndicator.GetComponent<Image>().color = Color.green;
        disabledIndicator.GetComponent<Image>().color = Color.white;
    }

    public void onDisableOfflineMode()
    {
        isOfflineModeEnabled = false;
        disabledIndicator.GetComponent<Image>().color = Color.green;
        enabledIndicator.GetComponent<Image>().color = Color.white;
    }

    public bool CheckInternetConnection()
    {
        if(Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork ||
            Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            return true;
        }
        return false;

        /*
        UnityWebRequest request = new UnityWebRequest("1.1.1.1");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            Debug.Log("Error");
            action(false);
        }
        else
        {
            Debug.Log("Success");
            action(true);
        }
        */
    }

}
