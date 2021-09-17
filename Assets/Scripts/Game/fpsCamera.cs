using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsCamera : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraObject;

    Vector3 playerRotation;
    Vector3 cameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        playerRotation = player.transform.rotation.eulerAngles;
        cameraRotation = cameraObject.transform.rotation.eulerAngles;
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraObject.transform.position = player.transform.position;
    }
}
