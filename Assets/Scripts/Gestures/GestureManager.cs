using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GestureManager : MonoBehaviour
{
    public static GestureManager Instance;
    public SwipeProperty _swipeProperty;
    public SpreadProperty _spreadProperty;
    public EventHandler<SpreadEventArgs> OnSpread;

    Touch trackedFinger1;
    Touch trackedFinger2;
    private Vector2 startPoint = Vector2.zero;
    private Vector2 endPoint = Vector2.zero;
    private float gestureTime = 0;

    public GameObject character;
    private Camera characterCamera;

    public GameObject elementalButtons;
    private float rotSpeed = 1.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        characterCamera = character.GetComponentInChildren<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1)
            {
                trackedFinger1 = Input.GetTouch(0);
                checkSingleFingerGestures();
            }
            
            else if(Input.touchCount > 1)
            {
                trackedFinger1 = Input.GetTouch(0);
                trackedFinger2 = Input.GetTouch(1);

                if (trackedFinger1.phase == TouchPhase.Moved || trackedFinger2.phase == TouchPhase.Moved)
                {
                    Vector2 prevPoint1 = GetPreviousPoint(trackedFinger1);
                    Vector2 prevPoint2 = GetPreviousPoint(trackedFinger2);

                    float currDistance = Vector2.Distance(trackedFinger1.position, trackedFinger2.position);
                    float prevDistance = Vector2.Distance(prevPoint1, prevPoint2);

                    if (Mathf.Abs(currDistance - prevDistance) >= (_spreadProperty.minDistanceChange * Screen.dpi))
                    {
                        FireSpreadEvent(currDistance - prevDistance);
                    }
                }
                else
                {
                    characterCamera.fieldOfView = Mathf.Lerp(characterCamera.fieldOfView, 45, 0.5f);
                }
            }
            

            
        }
    }

    private void checkSingleFingerGestures()
    {
        if (trackedFinger1.phase == TouchPhase.Began)
        {
            startPoint = trackedFinger1.position;
            gestureTime = 0;

            //ENEMY SWIPE MECHANIC
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(trackedFinger1.position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.name == "SwipableEnemy")
                {
                    //assign that hit.transform to a transform var here
                }
            }
            //-------------------------
        }
        else if (trackedFinger1.phase == TouchPhase.Ended)
        {
            endPoint = trackedFinger1.position;
            if (gestureTime <= _swipeProperty.swipeTime &&
                Vector2.Distance(startPoint, endPoint) >= (_swipeProperty.minSwipeDistance * Screen.dpi))
            {
                Transform rotHolder = elementalButtons.transform;
                rotHolder.Rotate(0, 0, -90, Space.Self);
                elementalButtons.transform.rotation = Quaternion.Slerp(elementalButtons.transform.rotation, rotHolder.rotation, rotSpeed * Time.deltaTime);
                //debug
                Debug.Log("swipte");
                //we destroy here yung transform var holding the enemy transform
            }
        }
        else
        {
            gestureTime += Time.deltaTime;
        }
    }

    private Vector2 GetPreviousPoint(Touch finger)
    {
        return finger.position - finger.deltaPosition;
    }

    private void FireSpreadEvent(float dist)
    {
        Vector2 mid = GetMidPoint(trackedFinger1.position, trackedFinger2.position);

        Ray ray = Camera.main.ScreenPointToRay(mid);
        RaycastHit hit = new RaycastHit();
        GameObject hitObj = null;

        if(Physics.Raycast(ray,out hit, Mathf.Infinity))
        {
            hitObj = hit.collider.gameObject;
            characterCamera.fieldOfView = Mathf.Lerp(characterCamera.fieldOfView, 20, 0.5f);
        }

    }

    private Vector2 GetMidPoint(Vector2 finger1, Vector2 finger2)
    {
        return (finger1 + finger2) / 2;
    }
}
  
