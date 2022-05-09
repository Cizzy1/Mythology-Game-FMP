using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    int Speed = 7;
    Vector2 mov;

    public float damage = 25f;
    float timetoAttack = 1.5f;
    float AttackRate = 1.5f;

    public Camera cam; 

    public LayerMask EnemyLayer;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Movement
        mov.x = Input.GetAxisRaw("Horizontal");
        mov.y = Input.GetAxisRaw("Vertical");

        movement();
        Attack();

    }

    void movement(){
        rb.MovePosition(rb.position + mov * Speed * Time.fixedDeltaTime);
    }

    void Attack(){
        RaycastHit2D EnemyCheck = Physics2D.CircleCast(transform.position, 2f, Vector2.up, EnemyLayer); 

        //Debug.Log(EnemyCheck.collider.name.ToString());

        if(EnemyCheck.collider.tag == "Enemy" && Input.GetMouseButtonDown(0) && Time.time > timetoAttack){
            Debug.Log("enemy attacked");

            timetoAttack = Time.time + AttackRate;
            EnemyCheck.collider.GetComponent<Basic_Enemy_Health>().Health -= damage;
        }
    }

    void Bow(){

        Vector3 mousePos = Input.mousePosition;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        //RaycastHit2D BowRay = Physics2D.Raycast(transform);
    }
}
