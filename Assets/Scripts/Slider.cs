using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public int slideSpeed = 1;
    public float slideDuration = 1f;
    public Vector3 slideValue = new Vector3(0, 0, 60);
    private float i = 0;
    
    void Update()
    {
        if(i <= slideDuration){
            transform.Translate(slideValue * Time.deltaTime * slideSpeed);
            i += Time.deltaTime;
        }else{ slideSpeed *= -1; i = 0; }
    }
}
