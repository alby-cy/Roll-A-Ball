using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        //set camera offset from player pos
        offset = transform.position - player.transform.position;
    }

    
    void Update()
    {
        //make camera transform pos follow player transform pos
        transform.position = player.transform.position + offset;
    }
}
