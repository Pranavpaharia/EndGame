using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAnimationVolume : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] ObjectsToAnimate;

    Animator proxyAnimator;
    void Start()
    {

        if(ObjectsToAnimate != null)
        {
            if(ObjectsToAnimate.Length > 0)
            {
                foreach (GameObject animationObject in ObjectsToAnimate)
                {
                    proxyAnimator = animationObject.GetComponent<Animator>();
                    if (proxyAnimator = null)
                    {
                        Debug.Log("No Animation Controller Found");
                    }
                }
            }
        }
        


        

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void TriggerAnimationEvent()
    {
        foreach (GameObject animationObject in ObjectsToAnimate)
        {
            proxyAnimator = animationObject.GetComponent<Animator>();
            proxyAnimator.SetBool("Activate", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           TriggerAnimationEvent();
        }
    }
}
