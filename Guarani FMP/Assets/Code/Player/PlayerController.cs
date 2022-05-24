using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Header("Player movement")]
    public Rigidbody2D rb;
    public float JumpVelocity;
    public float moveSpeed;


    //Extras
    public float Height = 2f;
    bool canDoublejump;
    public BoxCollider2D box2D;
    bool facingRight = true;
    RaycastHit2D Hit2D;
    [SerializeField] LayerMask groundlayerMask;
    private float movement_test;


    //Animations
    public Animator anim;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded()){
            float JumpVelocity = 6f;
            rb.velocity = Vector2.up * JumpVelocity;

            canDoublejump = true;
        } else if(canDoublejump && Input.GetKeyDown(KeyCode.Space)){
            float DJumpVelocity = 5f;
            rb.velocity = Vector2.up * DJumpVelocity;
            canDoublejump = false;
        }

        walk();

        movement_test = rb.velocity.x;
        var JumpVEV = rb.velocity.y;
        anim.SetFloat("isRunning", Mathf.Abs(movement_test));
        
        anim.SetBool("Jump", !isGrounded());

        anim.SetFloat("yVelocity", JumpVEV);

    }

    private void walk(){
        if(Input.GetKey(KeyCode.A)){
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }else{
            if(Input.GetKey(KeyCode.D)){
                rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
            }else{
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        if(rb.velocity.x > 0 && !facingRight)
        {
            Flip();
            
        }
        else if(rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }

        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);    
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }


    private bool isGrounded(){
        return Physics2D.BoxCast(box2D.bounds.center, box2D.bounds.size, 0f, Vector2.down, Height, groundlayerMask);
    }
}
