using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System;

public class currencyUpdater : MonoBehaviour
{
    public Text currencyText;
    public AdsManager adsManager;

    // Start is called before the first frame update
    void Start()
    {
        currencyText.text = CurrencyManager.Instance.currencyPoints.ToString();
        adsManager.OnAdDone += AdManagerOnAdDone;
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = PlayerPrefs.GetInt("currency").ToString();
    }

    private void AdManagerOnAdDone(object sender, AdFinishEventArgs args)
    {
        if(args.placementID == AdsManager.DebugRewardedAd)
        {
            switch(args.AdResult)
            {
                case ShowResult.Failed:
                    Debug.Log("ad failed loading");
                    break;
                case ShowResult.Skipped:
                    Debug.Log("ad skipped");
                    break;
                case ShowResult.Finished:
                    PlayerPrefs.SetInt("currency", CurrencyManager.Instance.currencyPoints += 5);
                    break;
            }
        }
    }
}
