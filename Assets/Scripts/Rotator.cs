using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public int rotateSpeed = 1;
    public Vector3 rotationValue = new Vector3(0, 0, 60);
    private int randomNum = 0;

    void Start()
    {
       randomNum = Random.Range(0, 360);
        transform.Rotate(new Vector3(0, 0, randomNum));
    }

    
    void Update()
    {
        //Rotate object over time
        transform.Rotate(rotationValue * Time.deltaTime * rotateSpeed);
    }
}
