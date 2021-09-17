using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]

    [Space]

    [Header("Player")]
    public GameObject Player;
    public GameObject Gun;

    [Space]

    [Header("Enemy")]
    public GameObject SpawnPoints;

    public GameObject EnemyPrefab1;
    public GameObject EnemyPrefab2;
    public GameObject EnemyPrefab3;
    public GameObject EnemyPrefab4;
    public GameObject EnemyHolder;

    private Transform[] ChildSpawn;
    private GameObject currentPoint;

    private GameObject EnemyClone1;
    private GameObject EnemyClone2;
    private GameObject EnemyClone3;
    private GameObject EnemyClone4;

    private int randomEnemyNum;
    private bool roundStart = false;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        BGMManager.BGMInstance.play(BGMManager.BGMInstance.Level1);
        BGMManager.BGMInstance.BGM.volume = 0.5f;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (SpawnPoints.transform.Find(LevelMovement.LVLInstance.destinationName) == true && LevelMovement.LVLInstance.isStopped && !roundStart)
        {
            for (i = 0; i < SpawnPoints.transform.Find(LevelMovement.LVLInstance.destinationName).childCount; i++)
            {
                //IF NOT BOSS ENEMY COUNT
                if(LevelMovement.LVLInstance.points[LevelMovement.LVLInstance.destinationPoint + 1].name != "End")
                {
                    randomEnemyNum = Random.Range(1, 4);
                    Debug.Log("random number assigned: " + randomEnemyNum);

                    if (randomEnemyNum == 1)
                    {
                        EnemyPrefab1.GetComponent<enemyShoot>().playerTransform = Player.transform;
                        EnemyPrefab1.GetComponent<enemyShoot>().playerObject = Gun;
                        EnemyClone1 = Instantiate(EnemyPrefab1, SpawnPoints.transform.Find(LevelMovement.LVLInstance.destinationName).GetChild(i));
                        EnemyClone1.transform.SetParent(EnemyHolder.transform, true);
                    }

                    else if (randomEnemyNum == 2)
                    {
                        EnemyPrefab2.GetComponent<enemyShoot>().playerTransform = Player.transform;
                        EnemyPrefab2.GetComponent<enemyShoot>().playerObject = Gun;
                        EnemyClone2 = Instantiate(EnemyPrefab2, SpawnPoints.transform.Find(LevelMovement.LVLInstance.destinationName).GetChild(i));
                        EnemyClone2.transform.SetParent(EnemyHolder.transform, true);
                    }

                    else if (randomEnemyNum == 3)
                    {
                        EnemyPrefab3.GetComponent<enemyShoot>().playerTransform = Player.transform;
                        EnemyPrefab3.GetComponent<enemyShoot>().playerObject = Gun;
                        EnemyClone3 = Instantiate(EnemyPrefab3, SpawnPoints.transform.Find(LevelMovement.LVLInstance.destinationName).GetChild(i));
                        EnemyClone3.transform.SetParent(EnemyHolder.transform, true);
                    }
                }
                //BOSS ENEMY COUNT IS 1
                else
                {
                    EnemyPrefab4.GetComponent<enemyShoot>().playerTransform = Player.transform;
                    EnemyPrefab4.GetComponent<enemyShoot>().playerObject = Gun;
                    EnemyClone4 = Instantiate(EnemyPrefab4, SpawnPoints.transform.Find(LevelMovement.LVLInstance.destinationName).GetChild(i));
                    EnemyClone4.transform.SetParent(EnemyHolder.transform, true);
                }
                

            }
            roundStart = true;
        }

        if (EnemyHolder.GetComponent<Transform>().childCount == 0 && roundStart)
        {
            roundStart = false;
            LevelMovement.LVLInstance.AreaClear();
        }
    }
}
