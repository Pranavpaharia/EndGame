using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreoPoints : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;
    AudioSource audioSource;
    bool bOnce = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Player") && !bOnce)
        {
            animator.SetBool("Pop", true);
            audioSource.Play();
            Invoke("DestroyOreo", 1);
            bOnce = true;
        }
    }


    void DestroyOreo()
    {
        Destroy(gameObject);
    }
}
