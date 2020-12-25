using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 Direction;
    float MoveSpeed;
    float Torque;
    public float TimePeriod;
    Animator explosionAnimator;
    AudioSource audioSource;

    void Start()
    {

        //TimePeriod = Random.Range(5, 6);
        audioSource = gameObject.GetComponent<AudioSource>();
        explosionAnimator = transform.GetChild(1).GetComponent<Animator>();
        
        if(explosionAnimator != null)
        {
            Debug.Log("Animator Found! Turn it off");
            explosionAnimator.enabled = false;
        }

        InvokeRepeating("RandomForce", TimePeriod, TimePeriod);

    }


    public void PlayerCollided()
    {
        Debug.Log("AA gaya mein");
        explosionAnimator.enabled = true;
        audioSource.Play();
        Invoke("DestroyVirus", 0.5f);
    }

    void DestroyVirus()
    {
        Destroy(gameObject);
    }

    void RandomForce()
    {
        TimePeriod = Random.Range(5, 10);
        Direction.x = Random.Range(0.1f, 1);
        Direction.y = Random.Range(0.1f, 1);
        MoveSpeed = Random.Range(5, 10);
        Torque = Random.Range(-6, 6);
        GetComponent<Rigidbody2D>().velocity = Direction * MoveSpeed;
        //GetComponent<Rigidbody2D>().angularVelocity = 0;
        //GetComponent<Rigidbody2D>().drag = 200;
        //GetComponent<Rigidbody2D>().AddForce(Direction * MoveSpeed);
        GetComponent<Rigidbody2D>().AddTorque(Torque);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
