using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlattformMovement : MonoBehaviour
{

    public enum MoveState
    {
        MoveLeft,
        MoveRight,
        None
    }

    public MoveState currentState;
    public float MoveSpeed = 1.0f;
    Vector2 MoveDir;
    PlayerBehaviour playerscript;

    // Start is called before the first frame update
    void Start()
    {
        currentState = MoveState.MoveLeft;

        if(currentState == MoveState.MoveLeft)
        {
            MoveDir = Vector2.left;
        }
        else
        {
            MoveDir = Vector2.right;
        }


    }

    // Update is called once per frame
    void Update()
    {
        

        MoveThePlatform();

    }

    void MoveThePlatform()
    {
        transform.Translate(MoveDir * MoveSpeed * 0.001f, Space.World);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Player")
        {
            playerscript = collision.collider.gameObject.GetComponent<PlayerBehaviour>();
            collision.collider.transform.SetParent(transform);
 
        }

        if (collision.collider.gameObject.CompareTag("Pillar"))
        {
            if (currentState == MoveState.MoveLeft)
            {
                currentState = MoveState.MoveRight;
                MoveDir = Vector2.right;
                if(playerscript != null)
                {
                    playerscript.PlayerFlipSide(false);
                }
            }
            else 
            {
                currentState = MoveState.MoveLeft;
                MoveDir = Vector2.left;
                if (playerscript != null)
                {
                    playerscript.PlayerFlipSide(true);
                }
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
            playerscript = null;
        }
    }


}




