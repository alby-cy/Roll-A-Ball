using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody rb;
    private int pickUpCount;
    private int totalPickUps;
    private int curPickupCount = 0;
    private Timer timer;
    private float pickUpBarNum = 0;
    public Image pickUpBar;


    [Header("UI")]
    public SceneController menuManager;
    public TMP_Text pickUpText;
    public TMP_Text timerText;
    public GameObject inGamePanel;
    public GameObject winPanel;
    public TMP_Text winTimerText;

    [Header("Teleporters")]
    public GameObject playerCamera;
    public GameObject telePoint;

    void Start()
    {
        //enable in-game ui, disable win screen ui
        resetUI();
        rb = GetComponent<Rigidbody>();
        //get total pickups in scene
        pickUpCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        totalPickUps = pickUpCount;
        //run check pickups funct
        CheckPickups();
        //get Timer object and start timer
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();
    }
    void resetUI()
    {
        inGamePanel.SetActive(true);
        winPanel.SetActive(false);
    }
    private void Update()
    {
        timerText.text = timer.GetClock();
        if (Input.GetKeyDown(KeyCode.Escape)) { menuManager.TogglePause(); }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);  

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup" ) //Pickup Collection
        {
            //destroy collided object
            Destroy(other.gameObject);
            //decrement pickup count
            pickUpCount--;
            //increast picked-up amount
            curPickupCount++;
            //run check pickups funct
            CheckPickups();
        }else if (other.tag == "Teleporter") //Teleporter Management
        {
            rb.velocity = Vector3.zero;
            transform.position = telePoint.transform.position;
        }
    }

    void CheckPickups()
    {
        pickUpText.text = "Coins: " + pickUpCount;
        //total pickup bar calc and display
        pickUpBarNum = Mathf.InverseLerp(0, totalPickUps, curPickupCount);
        pickUpBar.fillAmount = pickUpBarNum;
        //call win condition when all coins collected:
        if (pickUpCount <= 0 ) {
            Win();
        };
    }

    void Win()
    {
        timer.EndTimer();
        //remove UI and show win screen
        inGamePanel.SetActive(false);
        winPanel.SetActive(true);
        //set results
        winTimerText.text = timer.GetClock() + "ˢ";
        winTimerText.color = Color.green;
        //stop ball
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}