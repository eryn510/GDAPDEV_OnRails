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
    public GameObject EnemyPrefab;
    public GameObject EnemyHolder;

    private Transform[] ChildSpawn;
    private GameObject currentPoint;
    private GameObject EnemyClone;
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
                EnemyPrefab.GetComponent<enemyShoot>().playerTransform = Player.transform;
                EnemyPrefab.GetComponent<enemyShoot>().playerObject = Gun;
                EnemyClone = Instantiate(EnemyPrefab, SpawnPoints.transform.Find(LevelMovement.LVLInstance.destinationName).GetChild(i));
                EnemyClone.transform.SetParent(EnemyHolder.transform, true);
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
