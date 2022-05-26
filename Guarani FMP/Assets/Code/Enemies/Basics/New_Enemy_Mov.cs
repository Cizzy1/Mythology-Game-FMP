using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Enemy_Mov : MonoBehaviour
{
    [Header("Petrolling")]
    [SerializeField] float moveSpeed;
    private float moveDiection = 1;
    private bool facingRight = true;
    [SerializeField] Transform GroundCheck;
    [SerializeField] Transform WallCheck;
    [SerializeField] float circleRadius;
    [SerializeField] LayerMask groundLayer;
    private bool CheckingGround;
    private bool CheckingWall;

    [Header("Extras")]
    private Rigidbody2D rb;
    public Animator anim;

    void Start(){
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update(){

    }

    void FixedUpdate(){

        var Move = rb.velocity.x;
        anim.SetFloat("isRunning", Mathf.Abs(Move));


        CheckingGround = Physics2D.OverlapCircle(GroundCheck.position, circleRadius, groundLayer);
        CheckingWall = Physics2D.OverlapCircle(WallCheck.position, circleRadius, groundLayer);

        Petrolling();
        Detection();

        CheckingPlayer = Physics2D.OverlapBox(PlayerCheck.position, boxSize, 0, PlayerMask);
    }

    void Petrolling(){

        if(!CheckingGround || CheckingWall){
            if(facingRight){
                Flip();
            }
            else if(!facingRight){
                Flip();
            }
        }

        rb.velocity = new Vector2(moveSpeed * moveDiection, rb.velocity.y);
    }

//Attacking
//////////////////----------------------------------

    [Header("Attack")]
    [SerializeField] Transform PlayerCheck;
    [SerializeField] LayerMask PlayerMask;
    [SerializeField] float attackRange;
    [SerializeField] Transform Player;
    [SerializeField] Vector2 boxSize;
    private bool CheckingPlayer;

    void Detection(){
        float disFromPlayer = Player.position.x - transform.position.x;

        if(CheckingPlayer){
            
        }

    }

    void Flip(){
        moveDiection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }


//Gizmos things
//////////////////----------------------------------
    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(GroundCheck.position, circleRadius);
        Gizmos.DrawWireSphere(WallCheck.position, circleRadius);
        Gizmos.DrawWireCube(PlayerCheck.position, boxSize);
    }
}
