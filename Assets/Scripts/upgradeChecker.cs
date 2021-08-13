using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeChecker : MonoBehaviour
{
    public int money;

    [SerializeField] private Text levelTextAmmo;
    [SerializeField] private Text levelTextFire;
    [SerializeField] private Text levelTextWater;
    [SerializeField] private Text levelTextElectro;
    [SerializeField] private Text levelTextGround;
    [SerializeField] private Text levelTextHealth;

    [HideInInspector] private int ammoLevel;
    [HideInInspector] private int fireLevel;
    [HideInInspector] private int waterLevel;
    [HideInInspector] private int electroLevel;
    [HideInInspector] private int groundLevel;
    [HideInInspector] private int healthLevel;
    // Start is called before the first frame update
    void Start()
    {
        money = CurrencyManager.Instance.currencyPoints;
        ammoLevel = CurrencyManager.Instance.ammoSphereLevel;
        fireLevel = CurrencyManager.Instance.fireDmgLevel;
        waterLevel = CurrencyManager.Instance.waterDmgLevel;
        electroLevel = CurrencyManager.Instance.electroDmgLevel;
        groundLevel = CurrencyManager.Instance.groundDmgLevel;
        healthLevel = CurrencyManager.Instance.healthAmtLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickUpgradeAmmoSphere()
    {
        if (money >= 20 && ammoLevel < 5)
        {
            money -= 20;
            ammoLevel += 1;
            this.levelTextAmmo.text = "lv " + ammoLevel.ToString();

            CurrencyManager.Instance.ammoSphereLevel = ammoLevel;
            CurrencyManager.Instance.currencyPoints = money;
        }
    }

    public void OnClickUpgradeFire()
    {
        if (money >= 20 && fireLevel < 5)
        {
            money -= 20;
            fireLevel += 1;
            this.levelTextFire.text = "lv " + fireLevel.ToString();

            CurrencyManager.Instance.fireDmgLevel = fireLevel;
            CurrencyManager.Instance.currencyPoints = money;
        }
    }

    public void OnClickUpgradeWater()
    {
        if (money >= 20 && waterLevel < 5)
        {
            money -= 20;
            waterLevel += 1;
            this.levelTextWater.text = "lv " + waterLevel.ToString();

            CurrencyManager.Instance.waterDmgLevel = waterLevel;
            CurrencyManager.Instance.currencyPoints = money;
        }
    }

    public void OnClickUpgradeElectro()
    {

        if (money >= 20 && electroLevel < 5)
        {
            money -= 20;
            electroLevel += 1;
            this.levelTextElectro.text = "lv " + electroLevel.ToString();

            CurrencyManager.Instance.electroDmgLevel = electroLevel;
            CurrencyManager.Instance.currencyPoints = money;
        }
    }

    public void OnClickUpgradeGround()
    {
        if (money >= 20 && groundLevel < 5)
        {
            money -= 20;
            groundLevel += 1;
            this.levelTextGround.text = "lv " + groundLevel.ToString();

            CurrencyManager.Instance.groundDmgLevel = groundLevel;
            CurrencyManager.Instance.currencyPoints = money;
        }

    }

    public void OnClickUpgradeHealth()
    {
        if (money >= 20 && healthLevel < 5)
        {
            money -= 20;
            healthLevel += 1;
            this.levelTextHealth.text = "lv " + healthLevel.ToString();

            CurrencyManager.Instance.healthAmtLevel = healthLevel;
            CurrencyManager.Instance.currencyPoints = money;
        }


    }
}
