using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    [SerializeField]
    public GameObject enemyPrefab;
    public GameObject player;
    public Camera cameraObject;

    private Transform camTransform;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = cameraObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 5.0f)
        {
            Vector3 enemyPos = new Vector3(camTransform.position.x - 5.0f, 0, camTransform.position.z + 15.0f);
            Instantiate(enemyPrefab, enemyPos, camTransform.rotation);
            currentTime = 0f;
        }
    }
}
