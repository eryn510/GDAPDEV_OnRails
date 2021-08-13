using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public float fireRange;
    public GameObject particleScatter;
    public GameObject attackingEnemy;
    public Transform playerTransform;
    public GameObject playerObject;
    playerHealth playerhp;
    public int attackDamage = 2;

    private float atkTicks = 0.0f;
    

    private void Awake()
    {
        playerhp = playerObject.GetComponent<playerHealth>();
    }


    // Update is called once per frame
    void Update()
    {
        atkTicks += Time.deltaTime;

        {
            transform.LookAt(playerTransform);
        }

        if(atkTicks > 3.0f)
        {
            atkTicks = 0.0f;

            RaycastHit hit;
            if(Physics.Raycast(attackingEnemy.transform.position, transform.TransformDirection(Vector3.forward), out hit, fireRange))
            {
                
                //if enemy can see player
                if (hit.transform.name == "Gun")
                {
                    playerhp.takeDamage(attackDamage);
                }
            }
        }
    }
}
