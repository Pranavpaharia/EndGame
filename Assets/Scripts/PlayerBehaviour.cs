using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{

    public int UpForceMag = 150;

    Rigidbody2D rb_Player;
    GameObject canvasUI;
    BoxCollider2D boxCol;
    SpriteRenderer SpriteRenderer;
    
    Ray GroundRay;
    RaycastHit2D groundHit;
    bool bJump = false;
    Collider2D platformCollider;

    Sprite idlePosition;
    Sprite JumpUp;
    Sprite JumpDown;

    Transform platformDirRef;
    Animator playerAnimator;

    public AudioClip jumpSound;
    public AudioClip landingSound;
    AudioSource  audioSource;

    ShareButtonBehaviour shareScript;
    bool bShareOnce = false;
    int score = 0;
    bool bShare = true;

    
    // Start is called before the first frame update
    void Start()
    {
        rb_Player = GetComponent<Rigidbody2D>() as Rigidbody2D;
        canvasUI = GameObject.FindGameObjectWithTag("Respawn");
        boxCol = this.gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        SpriteRenderer = GetComponent<SpriteRenderer>() as SpriteRenderer;
        playerAnimator = GetComponent<Animator>() as Animator;
        playerAnimator.SetBool("MaskOn", false);
        audioSource = GetComponent<AudioSource>();
        shareScript = GetComponent<ShareButtonBehaviour>();
        canvasUI.SetActive(false);
        

        if (SpriteRenderer == null)
        {
            Debug.Log("Found the Sprite Component");
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !bJump)
        {
            Debug.Log("Jump");
            bJump = true;
            PlayerJump();
            playerAnimator.SetBool("IsJumping", true);
            playerAnimator.SetBool("Start", true);
            audioSource.clip = jumpSound;
            audioSource.Play();
            transform.SetParent(null);
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began && !bJump)
            {
                //UI_Tpro.SetText("Tap Begins ");
                //Debug.Log("Jump");
                //bJump = true;
                //PlayerJump();
                Debug.Log("Jump");
                bJump = true;
                PlayerJump();
                playerAnimator.SetBool("IsJumping", true);
                playerAnimator.SetBool("Start", true);
                audioSource.clip = jumpSound;
                audioSource.Play();
                transform.SetParent(null);
            }


            if(touch.phase == TouchPhase.Ended)
            {
               // UI_Tpro.SetText("Tap Ends ");
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

       // if(GetPlayerVelocity() == 0)
       // {

       // }

       // Vector3 forward = transform.TransformDirection(Vector3.down);
       //// Debug.DrawLine(transform.position, forward, Color.red);
        
       // if(platformCollider != null)
       // {
            
       // }



    }

    public void PlayerButtonClicked()
    {
        if(bShare)
        { 
            Debug.Log("Clicked Player Script");
            shareScript.LaunchShareWindow();
            bShare = false;
            canvasUI.SetActive(false);
            Invoke("ReInitShare", 3);
        }
    }

    void ReInitShare()
    {
        bShare = true;
        canvasUI.SetActive(true);
    }

    public void PlayerFlipSide(bool bTurn)
    {
        if(bTurn)
            SpriteRenderer.flipX = true;
        else
            SpriteRenderer.flipX = false;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Platform"))
        {
           // Debug.Log("Colliding with" + collision.collider.name);
            bJump = false;
            playerAnimator.SetBool("IsJumping", false);
            platformDirRef = collision.collider.transform;
            audioSource.clip = landingSound;
            audioSource.Play();
            if (platformDirRef.GetComponent<PlattformMovement>().currentState == PlattformMovement.MoveState.MoveLeft)
            {
                SpriteRenderer.flipX = true;
            }
            else
            {
                SpriteRenderer.flipX = false;
            }
        }


        


        if (collision.collider.CompareTag("Ground"))
        {
           // Debug.Log("Colliding with" + collision.collider.name);
            bJump = false;
            playerAnimator.SetBool("IsJumping", false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Mask"))
        {
            Debug.Log("Mask Acquired");
            playerAnimator.SetBool("MaskOn", true);
            score++;
        }

        if (collider.CompareTag("Oreo"))
        {
            Debug.Log("Oreo points");
            score++;
        }

        if (collider.CompareTag("Score"))
        {
            Debug.Log("Oreo points");
            collider.gameObject.GetComponent<TextMesh>().text =  score + "   Collectibles";
            collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

        if (collider.CompareTag("ShareBlock") && !bShareOnce)
        {
            Debug.Log("Sharing Block Started");
            Invoke("ShowShareUI", 17);
            shareScript.SendData(score.ToString());
            bShareOnce = true;
           
        }
    }


    void ShowShareUI()
    {
        canvasUI.SetActive(true);
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            platformDirRef = null;
        }
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
        //rb_Player.AddForce(Vector2.up * UpForceMag);
        rb_Player.velocity = Vector2.up * UpForceMag;
        bJump = true;
    }

    private void FixedUpdate()
    {
        CheckGroundDistance();
    }
}


