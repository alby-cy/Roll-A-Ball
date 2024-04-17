using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public int rotateSpeed = 1;
    public Vector3 rotationValue = new Vector3(0, 0, 60);
    
    void Update()
    {
        //Rotate object over time
        transform.Rotate(rotationValue * Time.deltaTime * rotateSpeed);
    }
}
