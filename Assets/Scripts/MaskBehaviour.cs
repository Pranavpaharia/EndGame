using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource audioSource;

    void Start()   
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            audioSource.Play();
            Invoke("DestroyMask", 0.7f);

        }
    }

    void DestroyMask()
    {
        Destroy(gameObject);
    }
}
