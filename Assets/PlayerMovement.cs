using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public CinemachineDollyCart dolly;
    public CinemachineSmoothPath path;
    // Start is called before the first frame update
    void Start()
    {
        dolly.m_Speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
