using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cheatsManager : MonoBehaviour
{
    public static cheatsManager Instance;

    public bool isUnliAmmo = false;
    public bool isUnliHealth = false;
    [SerializeField] private Button unliAmmoEnable;
    [SerializeField] private Button unliHealthEnable;

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
        
    }

    public void OnUnliAmmoEnable()
    {
        if(!isUnliAmmo)
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            unliAmmoEnable.GetComponent<Image>().color = Color.green;
            isUnliAmmo = true;
        }
    }

    public void OnUnliHealthEnable()
    {
        if(!isUnliHealth)
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            unliHealthEnable.GetComponent<Image>().color = Color.green;
            isUnliHealth = true;
        }
    }

    public void OnUnliAmmoDisable()
    {
        if (isUnliAmmo)
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            SFXManager.SFXInstance.EnvironmentAudio.pitch = 0.8f;
            unliAmmoEnable.GetComponent<Image>().color = Color.white;
            isUnliAmmo = false;
        }
    }
    public void OnUnliHealthDisable()
    {
        if (isUnliHealth)
        {
            SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
            SFXManager.SFXInstance.EnvironmentAudio.pitch = 0.8f;
            unliHealthEnable.GetComponent<Image>().color = Color.white;
            isUnliHealth = false;
        }
    }
}
