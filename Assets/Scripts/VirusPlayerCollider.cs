﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusPlayerCollider : MonoBehaviour
{
    // Start is called before the first frame update

    VirusBehaviour ParentScript;
    void Start()
    {
        //Get Parent Reference
        ParentScript = transform.parent.gameObject.GetComponent<VirusBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Player"))
        {
            ParentScript.PlayerCollided();
        }
        
    }
}
