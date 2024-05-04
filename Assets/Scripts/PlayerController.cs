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

    [Header("Bonus Collectables")]
    private int timeCoins = 0;
    private int speedCoins = 0;
    private int sizeCoins = 0;
    public TMP_Text timeCoinCount;
    public int timeCoinValue = 5;
    public TMP_Text timeRemoved;
    public TMP_Text speedCoinCount;
    public TMP_Text sizeCoinCount;


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
        //reset bonus coins collected
        timeCoins = 0; speedCoins = 0; sizeCoins = 0;
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
        if (this.transform.position.y < -50) {menuManager.RestartLevel(); }
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
        }else if (other.tag == "Teleporter") //Teleport Management
        {
            rb.velocity = Vector3.zero;
            transform.position = telePoint.transform.position;
        }else if (other.tag == "TimeCoin")
        {
            timeCoins += 1;
            Destroy(other.gameObject);
            timer.RemoveTime(timeCoinValue);
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
        if (timeCoins > 0) {
            timeCoinCount.color = Color.green;
        }
        if (speedCoins > 0) {
            speedCoinCount.color = Color.green;
        }
        if (sizeCoins > 0) {
            sizeCoinCount.color = Color.green;
        }
        timeCoinCount.text = "x " + timeCoins;
        timeRemoved.color = Color.red;
        timeRemoved.text = "- "+ (timeCoins * timeCoinValue) + "ˢ";
        //stop ball
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}