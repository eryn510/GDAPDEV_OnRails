using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int startingHealth = 2;
    public int currentHealth;
    public GameObject enemyRender;
    bool damaged;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged == true)
        {
    
        }

        damaged = false;
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        damaged = true;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            CurrencyManager.Instance.currencyPoints += 10;
        }
    }
}
