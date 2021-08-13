using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cheatChecker : MonoBehaviour
{
    public bool isUnliAmmo = false;
    public bool isUnliHealth = false;
    public static cheatChecker Instance;
    [SerializeField] private Button unliAmmoEnable;
    [SerializeField] private Button unliHealthEnable;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        isUnliAmmo = cheatsManager.Instance.isUnliAmmo;
        isUnliHealth = cheatsManager.Instance.isUnliHealth;

        if (isUnliAmmo == true)
        {
            unliAmmoEnable.GetComponent<Image>().color = Color.green;
        }
        else if (isUnliAmmo == false)
        {
            unliAmmoEnable.GetComponent<Image>().color = Color.white;
        }

        if (isUnliHealth == true)
        {
            unliHealthEnable.GetComponent<Image>().color = Color.green;
        }
        else if (isUnliHealth == false)
        {
            unliHealthEnable.GetComponent<Image>().color = Color.white;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateUnliAmmoCheat()
    {
        if (isUnliAmmo == true)
        {
            unliAmmoEnable.GetComponent<Image>().color = Color.green;
        }
        else if (isUnliAmmo == false)
        {
            unliAmmoEnable.GetComponent<Image>().color = Color.white;
        }
    }

    public void updateUnliHealthCheat()
    {
        if (isUnliHealth == true)
        {
            unliHealthEnable.GetComponent<Image>().color = Color.green;
        }
        else if (isUnliHealth == false)
        {
            unliHealthEnable.GetComponent<Image>().color = Color.white;
        }
    }

    public void EnableInfAmmo()
    {
        SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
        isUnliAmmo = true;
        cheatsManager.Instance.isUnliAmmo = isUnliAmmo;
        updateUnliAmmoCheat();
    }
    public void DisableInfAmmo()
    {
        SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
        SFXManager.SFXInstance.EnvironmentAudio.pitch = 0.8f;
        isUnliAmmo = false;
        cheatsManager.Instance.isUnliAmmo = isUnliAmmo;
        updateUnliAmmoCheat();
    }

    public void EnableInfHealth()
    {
        SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
        isUnliHealth = true;
        cheatsManager.Instance.isUnliHealth = isUnliHealth;
        updateUnliHealthCheat();
    }

    public void DisableInfHealth()
    {
        SFXManager.SFXInstance.EnvironmentplaySFX(SFXManager.SFXInstance.ButtonClick);
        SFXManager.SFXInstance.EnvironmentAudio.pitch = 0.8f;
        isUnliHealth = false;
        cheatsManager.Instance.isUnliHealth = isUnliHealth;
        updateUnliHealthCheat();
    }
}
