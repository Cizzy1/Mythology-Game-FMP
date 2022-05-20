using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Enemy_Mov : MonoBehaviour
{
    public Transform Player;
    public float agroRange; 
    public float Movespeed;
    Rigidbody2D _rb;


    void Start(){
        _rb = GetComponent<Rigidbody2D>();
    } 

    void Update(){
        float Dis = Vector2.Distance(transform.position, Player.position);

        if(Dis < agroRange){
            ChasePlayer();
        } else{
            Stop();
        }
    }

    void ChasePlayer(){
        if(transform.position.x < Player.position.x){
            _rb.velocity = new Vector2(Movespeed, 0);
            transform.localScale = new Vector2(1, 1);
        }else if(transform.position.x >  Player.position.x){
            _rb.velocity = new Vector2(-Movespeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void Stop(){
        _rb.velocity = Vector2.zero;
    }
}
