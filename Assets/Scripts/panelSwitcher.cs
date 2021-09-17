using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelSwitcher : MonoBehaviour
{
    public GameObject buttonToClick;
    public GameObject[] panelsToEnable;
    public Animator anim;

    public void OnClick()
    {
        if (buttonToClick.name == "OptionsButton")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            panelsToEnable[0].SetActive(false);
            panelsToEnable[1].SetActive(true);
            anim.SetBool("Open", true);
        }
        else if (buttonToClick.name == "backButton")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            SFXManager.SFXInstance.EnvironmentAudio.pitch = 0.8f;
            BGMManager.BGMInstance.playBGM();
            //panelsToEnable[0].SetActive(false);
            //panelsToEnable[1].SetActive(true);

            if(panelsToEnable[0].name == "pausePanel")
            {
                Time.timeScale = 1;

                Invoke("On_Disable", 0.5f);
            }
            else
            {
                Invoke("On_Disable", 1);
            }

            anim.SetBool("Open", false);

        }
        else if (buttonToClick.name == "pauseButton")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            BGMManager.BGMInstance.pauseBGM();
            panelsToEnable[0].SetActive(false); //gameplay panel
            panelsToEnable[1].SetActive(true); //pause panel
            anim.SetBool("Open", true);

            Invoke("On_Pause", 0.5f);
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
            anim.SetBool("Open", true);
        }
        else if (buttonToClick.name == "HTPButton")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            panelsToEnable[0].SetActive(false); //main men panel
            panelsToEnable[1].SetActive(true); //upgrades panel
            anim.SetBool("Open", true);
        }
        else if (buttonToClick.name == "SubmitToLeaderBoardButtonL1" || buttonToClick.name == "SubmitToLeaderBoardButtonL2" ||
            buttonToClick.name == "SubmitToLeaderBoardButtonL3")
        {
            TimeManager.Instance.canClickLeaderBoard = false;

            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            panelsToEnable[0].SetActive(false); //main men panel
            panelsToEnable[1].SetActive(true); //upgrades panel
            anim.SetBool("Open", true);
        }
        else if (buttonToClick.name == "LeaderBoardsButton")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            panelsToEnable[0].SetActive(false); //main men panel
            panelsToEnable[1].SetActive(true); //upgrades panel
            anim.SetBool("Open", true);
        }
        else if (buttonToClick.name == "StartButton")
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            panelsToEnable[0].SetActive(false); //main men panel
            panelsToEnable[1].SetActive(true); //upgrades panel
            anim.SetBool("Open", true);
        }
    }

    void On_Disable()
    {
        panelsToEnable[0].SetActive(false);
        panelsToEnable[1].SetActive(true);
    }

    void On_Pause()
    {
        Time.timeScale = 0;
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
