using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource audioSource;
    Animator ExplosionAnimator;
    SpriteRenderer explosionSprite;
    SpriteRenderer maskSprite;
    void Start()   
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        ExplosionAnimator = transform.GetChild(0).GetComponent<Animator>();
        explosionSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        maskSprite = transform.GetComponent<SpriteRenderer>();
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
            maskSprite.enabled = false;
            explosionSprite.enabled = true;
            ExplosionAnimator.SetBool("Activate", true);
            Invoke("DestroyMask", 0.7f);


        }
    }

    void DestroyMask()
    {
        Destroy(gameObject);
    }
}
