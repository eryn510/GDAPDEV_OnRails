using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image damageTakenImage;
    public float flashSpeed;
    public Color flashColor = new Color(1.0f, 0.0f, 0.0f, 0.1f);
    bool damaged = false;
    public Text healthText;

    [Space]

    [Header("Panel")]
    public GameObject gameplayPanel;
    public GameObject revivePanel;
    public GameObject gameOverPanel;

    private int healthAmtLevel;

    private bool isReviveAvailable = true;

    private void Awake()
    {
        healthAmtLevel = CurrencyManager.Instance.healthAmtLevel;

        switch(healthAmtLevel)
        {
            case 1:
                maxHealth = 105;
                break;
            case 2:
                maxHealth = 110;
                break;
            case 3:
                maxHealth = 115;
                break;
            case 4:
                maxHealth = 125;
                break;
            case 5:
                maxHealth = 130;
                break;
        }

        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString();

        revivePanel.SetActive(false);
    }

   
    // Update is called once per frame
    void Update()
    {
        if (damaged == true)
        {
            damageTakenImage.color = flashColor;
        }
        else
        {
            damageTakenImage.color = Color.Lerp(damageTakenImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public void takeDamage(int amount)
    {
        if(cheatsManager.Instance.isUnliHealth == false)
        {
            if(currentHealth > 0)
                currentHealth -= amount;
            else
            {
                if(isReviveAvailable == true)
                {
                    Time.timeScale = 0;
                    
                    gameplayPanel.SetActive(false);
                    revivePanel.SetActive(true);
                    isReviveAvailable = false;
                    currentHealth = maxHealth;
                    
                }
                else
                {
                    Time.timeScale = 0;
                    gameOverPanel.SetActive(true);
                }
                             
            }
        }
            

        healthText.text = currentHealth.ToString();

        damaged = true;
    }
}
