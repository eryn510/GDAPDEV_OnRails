using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelSwitcher : MonoBehaviour
{
    public GameObject buttonToClick;
    public GameObject[] panelsToEnable;
   
    public void OnClick()
    {
        if (buttonToClick.name == "OptionsButton")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            panelsToEnable[0].SetActive(false);
            panelsToEnable[1].SetActive(true);
        }
        else if (buttonToClick.name == "backButton")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            SFXManager.SFXInstance.EnvironmentAudio.pitch = 0.8f;
            BGMManager.BGMInstance.playBGM();
            panelsToEnable[0].SetActive(false);
            panelsToEnable[1].SetActive(true);

            if(panelsToEnable[0].name == "pausePanel")
            {
                Time.timeScale = 1;
            }
        }
        else if (buttonToClick.name == "pauseButton")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            BGMManager.BGMInstance.pauseBGM();
            Time.timeScale = 0;
            panelsToEnable[0].SetActive(false); //gameplay panel
            panelsToEnable[1].SetActive(true); //pause panel
        }
        else if (buttonToClick.name == "exitGame")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            panelsToEnable[0].SetActive(false); //pause panel
            panelsToEnable[1].SetActive(true); //confirmation panel
        }
        else if (buttonToClick.name == "quitNoButton")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            panelsToEnable[0].SetActive(false); //conf panel
            panelsToEnable[1].SetActive(true); //pause panel
        }
        else if (buttonToClick.name == "quitYesButton")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            panelsToEnable[0].SetActive(false); //conf panel
            panelsToEnable[1].SetActive(false); //pause panel
            Time.timeScale = 1;
        }
        else if (buttonToClick.name == "UpgradesButton")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            panelsToEnable[0].SetActive(false); //main men panel
            panelsToEnable[1].SetActive(true); //upgrades panel
        }
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
