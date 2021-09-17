using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class mm_to_playScene : MonoBehaviour
{
    public AdsManager adsManager;
    public void MainMenuToPlay()
    {
        SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
        BGMManager.BGMInstance.stopBGM();
        //LoaderScript.loadScene(1, SceneManager.sceneCountInBuildSettings - 1);
    }

    public void PlayToMainMenu()
    {
        if(OfflineModeManager.Instance.isOfflineModeEnabled == false)
        {
            if (PlayerPrefs.GetInt("adFree") == 0)
                adsManager.showInterstitialAd();
        }

        Time.timeScale = 1;
        BGMManager.BGMInstance.stopBGM();
        BGMManager.BGMInstance.play(BGMManager.BGMInstance.MainMenu);
        //LoaderScript.loadScene(0, SceneManager.sceneCountInBuildSettings - 1);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
