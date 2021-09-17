using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int startingHealth = 2;
    public int currentHealth;
    public GameObject enemyRender;
    bool damaged;
    public GameObject floatingTextPrefab;
    GameObject prefab;
    Transform textObj;
    Transform player;

    private void Awake()
    {
        currentHealth = startingHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        showDamage(amount.ToString());
        currentHealth -= amount;
        damaged = true;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            PlayerPrefs.SetInt("currency", CurrencyManager.Instance.currencyPoints += 5);
        }
    }

    private void showDamage(string text)
    {
        if(floatingTextPrefab)
        {
            prefab = Instantiate(floatingTextPrefab, enemyRender.transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;

            //Rotation Corrector
            textObj = prefab.transform.GetChild(0);
            Vector3 eulerAng = enemyRender.transform.rotation.eulerAngles;
            eulerAng.y = eulerAng.y + 180;
            textObj.rotation = Quaternion.Euler(eulerAng);

            //Position Corrector
            Vector3 positionObj = prefab.transform.position;
            positionObj.x = positionObj.x - 10;
            positionObj.z = positionObj.z + 4;
            prefab.transform.position = positionObj;
            //prefab.transform.SetParent(this.transform);
            Destroy(prefab, 0.5f);
        }
    }

}
