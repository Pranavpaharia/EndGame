using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreoPoints : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animator;
    AudioSource audioSource;
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
        if(collider2D.CompareTag("Player"))
        {
            animator.SetBool("Pop", true);
            audioSource.Play();
            Invoke("DestroyOreo", 1);
        }
    }


    void DestroyOreo()
    {
        Destroy(gameObject);
    }
}
