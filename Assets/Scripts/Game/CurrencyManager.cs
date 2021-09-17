using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    public int currencyPoints;


    [HideInInspector] public int ammoSphereLevel = 0;
    [HideInInspector] public int fireDmgLevel = 0;
    [HideInInspector] public int waterDmgLevel = 0;
    [HideInInspector] public int electroDmgLevel = 0;
    [HideInInspector] public int groundDmgLevel = 0;
    [HideInInspector] public int healthAmtLevel = 0;


    private void Awake()
    {
        /*
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        */

        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);

        //PlayerPrefs.GetInt("currency", this.currencyPoints);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.currencyPoints = PlayerPrefs.GetInt("currency");
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.GetInt("currency", this.currencyPoints);
    }

    
    
    
    
    
    
}
