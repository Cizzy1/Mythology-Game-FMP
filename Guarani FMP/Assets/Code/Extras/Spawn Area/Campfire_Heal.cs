using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire_Heal : MonoBehaviour
{
    float hpGain = 5f;

    float firstTick = 1f;
    float TickRate = 1f;

    bool DetectPlayer;

    void Update()
    {

        RaycastHit2D playerCheck = Physics2D.CircleCast(transform.position, 1f, Vector2.up);

        if(playerCheck.transform.tag == "Player"){
            DetectPlayer = true;
            //Debug.Log("Player in heal zone");
        } else{
            DetectPlayer = false;
        }

        if(Time.time > firstTick && DetectPlayer){
            firstTick = Time.time + TickRate;
            playerCheck.collider.GetComponent<PlayerHealth>().Health += hpGain;
        }
    }
}