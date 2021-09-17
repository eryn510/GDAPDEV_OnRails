using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdFreeModeManager : MonoBehaviour
{
    public static AdFreeModeManager Instance;
    public bool isAdFreeModeEnabled = false;
    public GameObject enableButton;
    public int adFreeSetting;
    

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(this);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("adFree") == 1)
        {
            enableButton.GetComponent<Image>().color = Color.green;
        }
        else
        {
            enableButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void enableAdFreeMode()
    {
        this.isAdFreeModeEnabled = true;
        this.adFreeSetting = 1;
        PlayerPrefs.SetInt("adFree", this.adFreeSetting);
        this.enableButton.GetComponent<Image>().color = Color.green;

        PlayerPrefs.Save();
    }

    public void disableAdFreeMode()
    {
        this.isAdFreeModeEnabled = false;
        this.adFreeSetting = 0;
        PlayerPrefs.SetInt("adFree", this.adFreeSetting);
        enableButton.GetComponent<Image>().color = Color.white;

        PlayerPrefs.Save();
    }
}
