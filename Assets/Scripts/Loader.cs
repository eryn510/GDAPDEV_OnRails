using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System;

public class Loader : MonoBehaviour
{
    [SerializeField]
    public GameObject loadingPanel;
    public Slider loadingProgress;
    public Text loaderText;
    public AdsManager adsManager;

    public void LoadLevel(int SceneIndex)
    {
        BGMManager.BGMInstance.stopBGM();
        StartCoroutine(loadAsynchronously(SceneIndex));
    }

    IEnumerator loadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingPanel.SetActive(true);

        while (!operation.isDone)
        {
            if(OfflineModeManager.Instance.isOfflineModeEnabled == false)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);

                loadingProgress.value = progress;
                loaderText.text = Mathf.Round(progress * 100) + "%";
                Debug.Log(loaderText.text);


                if (PlayerPrefs.GetInt("adFree") == 0 && (sceneIndex == 1 || sceneIndex == 2 || sceneIndex == 3))
                {
                    Time.timeScale = 0;
                    adsManager.showRewardedAd();
                }
                yield return null;
            }
            else
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);

                loadingProgress.value = progress;
                loaderText.text = Mathf.Round(progress * 100) + "%";
                Debug.Log(loaderText.text);

                yield return null;
            }


            
            /*
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingProgress.value = progress;
            loaderText.text = Mathf.Round(progress * 100) + "%";
            Debug.Log(loaderText.text);

            yield return null;
            */
        }
        Time.timeScale = 1;
    }
}
