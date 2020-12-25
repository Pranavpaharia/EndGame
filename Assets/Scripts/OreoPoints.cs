using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreoPoints : MonoBehaviour
{
    // Start is called before the first frame update


    bool Caught = false;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Player"))
        {
            animator.SetBool("Pop", true);
        }
    }
}
