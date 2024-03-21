﻿using System.Collections;
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
    public bool isPaused = false; //Private this <--- public for testing only
    private float pickUpBarNum = 0;
    public Image pickUpBar;


    [Header("UI")]
    public TMP_Text pickUpText;
    public TMP_Text timerText;
    public GameObject inGamePanel;
    public GameObject winPanel;
    public TMP_Text winTimerText;

    // Start is called before the first frame update
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
        //timerText.text = timer.GetTime().ToString("#.");
        timerText.text = timer.GetClock();
    }

    void FixedUpdate()
    {
        if (isPaused) { }else {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            rb.AddForce(movement * speed);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup" ) {
            //destroy collided object
            Destroy(other.gameObject);
            //decrement pickup count
            pickUpCount--;
            //increast picked-up amount
            curPickupCount++;
            //run check pickups funct
            CheckPickups();
        }
    }

    void CheckPickups()
    {
        pickUpText.text = "Bingus: " + pickUpCount;
        pickUpBarNum = Mathf.InverseLerp(0, totalPickUps, curPickupCount);
        Debug.Log("pickUpBarNum " +pickUpBarNum);
        Debug.Log("pickUpCount " + pickUpCount);
        Debug.Log("curPickUpCount " + curPickupCount);
        pickUpBar.fillAmount = pickUpBarNum;
        //win condition:
        if (pickUpCount <= 0 ) {
            Win();
        };
    }

    void Win()
    {
        isPaused = true;
        timer.EndTimer();
        //remove UI and show win screen
        inGamePanel.SetActive(false);
        winPanel.SetActive(true);
        //set results
        winTimerText.text = timer.GetClock() + "s";
        winTimerText.color = Color.green;
        //stop ball
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    //TEMP - Remove during Assess2
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}