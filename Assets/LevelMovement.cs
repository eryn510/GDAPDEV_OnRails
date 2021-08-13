using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelMovement : MonoBehaviour
{
    [SerializeField]
    [Space]

    [Header("Transforms & Objects")]
    public Transform[] points;
    public GameObject canvas;

    [Space]

    [Header("Panels")]
    public GameObject gameplayPanel;
    public GameObject pausePanel;
    public GameObject confirmationPanel;
    public GameObject revivePanel;
    public GameObject gameOverPanel;

    [Space]

    [Header("Current Condition")]
    public string destinationName;
    public bool isStopped;
    private int destinationPoint;
    private int letterASCII = 65;
    private GameObject destination;
    private Transform destinationTransform;
    private float rotationSpeed;
    private int visited;

    NavMeshAgent navMeshAgent;

    public static LevelMovement LVLInstance;

    // Start is called before the first frame update
    void Start()
    {
        if (LVLInstance != null && LVLInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        LVLInstance = this;

        destination = GameObject.FindGameObjectWithTag("Waypoints");


        navMeshAgent = GetComponent<NavMeshAgent>();

        rotationSpeed = navMeshAgent.speed;
    }
    void gameOver()
    {
        gameplayPanel.SetActive(false);
        pausePanel.SetActive(false);
        confirmationPanel.SetActive(false);
        revivePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isStopped = navMeshAgent.isStopped;

        if (points[destinationPoint].name == "Start" && visited > 0)
        {
            gameOver();
            canvas.SetActive(true);
            navMeshAgent.isStopped = true;
        }

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance == 0.0f && points[destinationPoint].name == (char)letterASCII + "Final")
        {
            canvas.SetActive(true);
            navMeshAgent.isStopped = true;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, points[destinationPoint].transform.rotation, rotationSpeed * Time.deltaTime);
        }

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f && points[destinationPoint].name != (char)letterASCII + "Final")
            GoToNextPoint();

    }

    void GoToNextPoint()
    {
        visited++;
        if (points.Length == 0 || visited == points.Length)
        {
            navMeshAgent.isStopped = true;
            return;
        }
        if (canvas.activeSelf)
            canvas.SetActive(false);
        destinationPoint = (destinationPoint + 1) % points.Length;
        destinationName = points[destinationPoint].name;
        navMeshAgent.destination = points[destinationPoint].position;
    }

    public void AreaClear()
    {
        if (points[destinationPoint].name == (char)letterASCII + "Final")
        {
            letterASCII++;
            navMeshAgent.isStopped = false;
            GoToNextPoint();
        }
    }
}
