using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public EventHandler<AdFinishEventArgs> OnAdDone;
    private bool isBannerVisible = true;
    public int isAdFreeMode;

    public string GameID
    {
        get
        {
#if UNITY_ANDROID
            return "4287859";
#elif UNITY_IOS
            return "4287858";
#else
            return "";
#endif
        }
    }

    public const string DebugInterstitialAd = "DebugInterstitial";
    public const string DebugRewardedAd = "DebugRewarded";
    public const string DebugBannerAd = "DebugBanner";

    private void Awake()
    {
        //SET TO TRUE FOR APDEV MP SUBMISSION
        //SET TO FALSE FOR PUBLISHING
        Advertisement.Initialize(GameID, true);
        isAdFreeMode = PlayerPrefs.GetInt("adFree");
    }

    public void showInterstitialAd()
    {
        if(Advertisement.IsReady(DebugInterstitialAd) && isAdFreeMode == 0)
        {
            Advertisement.Show(DebugInterstitialAd);
        }
        else
        {
            Debug.Log("no ads");
        }
    }

    IEnumerator showBannerAd_Routine()
    {
        while(!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_LEFT);
        Advertisement.Banner.Show(DebugBannerAd);
    }

    public void showBannerAd()
    {
        isBannerVisible = true;
        StartCoroutine(showBannerAd_Routine());
    }

    public void hideBannerAd()
    {
        if(Advertisement.Banner.isLoaded)
        {
            Advertisement.Banner.Hide();
            isBannerVisible = false;
        }
    }

    public void OnUnityAdsReady(string placementID)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementID)
    {

    }

    public void OnUnityAdsDidFinish(string placementID, ShowResult showResult)
    {
        if(OnAdDone != null)
        {
            AdFinishEventArgs args = new AdFinishEventArgs(placementID, showResult);
            OnAdDone(this, args);
        }
    }

    public void showRewardedAd()
    {
        if(Advertisement.IsReady(DebugRewardedAd) && isAdFreeMode == 0)
        {
            Advertisement.Show(DebugRewardedAd);
        }
        else
        {
            Debug.Log("no ads");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        showBannerMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        showBannerMainMenu();
    }

    void showBannerMainMenu()
    {
        isAdFreeMode = PlayerPrefs.GetInt("adFree");

        if (isBannerVisible == true && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu") && OfflineModeManager.Instance.isOfflineModeEnabled == false &&
            isAdFreeMode == 0)
            showBannerAd();
        else
        {
            hideBannerAd();
        }
    }
}
