using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject messageObject;
    SpriteRenderer Sprite;
    void Start()
    {

        messageObject = transform.Find("ChatBubble").gameObject;
        Sprite = messageObject.GetComponent<SpriteRenderer>();
        Sprite.enabled = false;

        

    }

    void BlinkOnMessage()
    {
        Sprite.enabled = true;
    }

    void BlinkOffMessage()
    {
        Sprite.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Player"))
        {
            InvokeRepeating("BlinkOnMessage", 0.1f, 1);
            InvokeRepeating("BlinkOffMessage", 0.7f, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            Sprite.enabled = false;
            CancelInvoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
