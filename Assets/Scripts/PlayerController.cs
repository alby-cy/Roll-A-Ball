using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody rb;
    private int pickupCount;
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //get total pickups in scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        //run check pickups funct
        CheckPickups();
        //get Timer object and start timer
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
         
        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup" ) {
            //destroy collided object
            Destroy(other.gameObject);
            //decrement pickup count
            pickupCount--;
            //run check pickups funct
            CheckPickups();
        }
    }

    void CheckPickups()
    {
        print("Pickups left: " + pickupCount);
        if (pickupCount <= 0 ) {
            timer.EndTimer();
            print("===============================\n" + "-------YOU WON  ||  Time:" + timer.GetTime() + "------");
        };
    }

}