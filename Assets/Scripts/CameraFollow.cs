﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float verticalOffset;
    public float MaxXDistance;
    public float MinXDistance;

    GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player") as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, Player.transform.position.y + verticalOffset, transform.position.z);

        float CamXValue = Mathf.Clamp(Player.transform.position.x,MinXDistance, MaxXDistance);      
        transform.position = new Vector3(CamXValue, Player.transform.position.y + verticalOffset, transform.position.z);
    }
}
