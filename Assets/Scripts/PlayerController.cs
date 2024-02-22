using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody rb;
    private int pickupCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //get total pickups in scene
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        //run check pickups funct
        CheckPickups();
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
            print("===============================\n" + "----------------YOU WON----------------");
        };
    }

}