using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAnimationVolume : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] ObjectsToAnimate;

    Animator proxyAnimator;
    void Start()
    {
        foreach(GameObject animationObject in ObjectsToAnimate)
        {
            proxyAnimator = animationObject.GetComponent<Animator>();
            if(proxyAnimator = null)
            {
                Debug.Log("No Animation Controller Found");
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
            proxyAnimator.SetBool("", true);
        }
    }
}
