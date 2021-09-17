using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reticleMovement : MonoBehaviour
{
    protected Joystick joystick;
    protected RectTransform reticlepos;
    public float reticleSensitivity;
    float ScreenWidth;
    float ScreenHeight;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        reticlepos = GetComponent<RectTransform>();
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        reticlepos.position = new Vector3(reticlepos.position.x + joystick.Horizontal * (ScreenWidth / (100 / reticleSensitivity)), 
                                          reticlepos.position.y + joystick.Vertical * (ScreenHeight / (100 / reticleSensitivity)), 
                                           0.0f);

        if (reticlepos.position.x > ScreenWidth)
        {
            reticlepos.position = new Vector3(ScreenWidth, reticlepos.position.y, 0.0f);
        }
        if (reticlepos.position.x < 0)
        {
            reticlepos.position = new Vector3(0, reticlepos.position.y, 0.0f);
        }
        if (reticlepos.position.y > ScreenHeight)
        {
            reticlepos.position = new Vector3(reticlepos.position.x, ScreenHeight, 0.0f);
        }
        if (reticlepos.position.y < 0)
        {
            reticlepos.position = new Vector3(reticlepos.position.x, 0, 0.0f);
        }
    }
}
