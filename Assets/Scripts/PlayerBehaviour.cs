using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{

    public int UpForceMag = 150;

    Rigidbody2D rb_Player;
    TextMeshProUGUI UI_Tpro;
    BoxCollider2D boxCol;
    SpriteRenderer SpriteRenderer;
    
    Ray GroundRay;
    RaycastHit2D groundHit;
    bool bJump = false;
    Collider2D platformCollider;

    Sprite idlePosition;
    Sprite JumpUp;
    Sprite JumpDown;

    // Start is called before the first frame update
    void Start()
    {
        rb_Player = GetComponent<Rigidbody2D>() as Rigidbody2D;
        //UI_Tpro = GameObject.FindGameObjectWithTag("Respawn").GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        boxCol = this.gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        SpriteRenderer = GetComponent<SpriteRenderer>() as SpriteRenderer;


        if (SpriteRenderer == null)
        {
            Debug.Log("Found the Sprite Component");
        }

        if (UI_Tpro == null)
        {
            Debug.Log("No text mesh");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && !bJump)
        {
            Debug.Log("Jump");
            bJump = true;
            PlayerJump();
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began && !bJump)
            {
                UI_Tpro.SetText("Tap Begins ");
                //Debug.Log("Jump");
                //bJump = true;
                //PlayerJump();
            }


            if(touch.phase == TouchPhase.Ended)
            {
                UI_Tpro.SetText("Tap Ends ");
            }
        }

        //Debug.Log("Value of Velocity " + GetPlayerVelocity() );
        if(GetPlayerVelocity() <= 0 && boxCol.isTrigger)
        {
            Debug.Log("Enable Collision");
            ChangeIstriggerProperty(false);
        }

        if(GetPlayerVelocity() >= 0.1 && !boxCol.isTrigger)
        {
            Debug.Log("Disable Collision");
            ChangeIstriggerProperty(true);
        }

        if(GetPlayerVelocity() == 0)
        {

        }

        Vector3 forward = transform.TransformDirection(Vector3.down);
        Debug.DrawLine(transform.position, forward, Color.red);
        
        if(platformCollider != null)
        {
            
        }



    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colliding with" + collision.collider.name);
        bJump = false;
    }


    void CheckGroundDistance()
    {
        groundHit = Physics2D.Raycast(transform.position, Vector2.down, 10);
        
        

        if(groundHit.collider != null)
        {
           // Debug.Log("Collider : " + groundHit.collider.name);
            platformCollider = groundHit.collider;
        }
    }

    float GetPlayerVelocity()
    {
        float vel = rb_Player.velocity.y;
        return vel;
    }


    void ChangeIstriggerProperty(bool bValue)
    {
        boxCol.isTrigger = bValue;
    }

    void PlayerJump()
    {
        rb_Player.AddForce(Vector2.up * UpForceMag);
        bJump = true;
    }

    private void FixedUpdate()
    {
        CheckGroundDistance();
    }
}
