using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    int Speed = 7;
    Vector2 mov;

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

    }

    void movement(){
        rb.MovePosition(rb.position + mov * Speed * Time.fixedDeltaTime);
    }
}
