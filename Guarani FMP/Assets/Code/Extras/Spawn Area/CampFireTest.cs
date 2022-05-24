using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFireTest : MonoBehaviour
{
    float hpGain = 5f;

    float firstTick = 1f;
    float TickRate = 1f;

    bool DetectPlayer;

    public LayerMask playersMask;

    void Update()
    {

        RaycastHit2D playerCheck = Physics2D.CircleCast(transform.position, 2f, Vector2.up, playersMask);

        Debug.Log(playerCheck.collider.gameObject.name.ToString());

        if(playerCheck.collider.gameObject.CompareTag("Player")){
            DetectPlayer = true;
            Debug.Log("Player in heal zone");
        } else{
            DetectPlayer = false;
        }

        if(Time.time > firstTick && DetectPlayer){
            firstTick = Time.time + TickRate;
            Debug.Log("Player healed");
            playerCheck.collider.GetComponent<PlayerHealth>().Health += hpGain;
        }

        ClearRadius();
    }

    void ClearRadius(){
        RaycastHit2D EnemyCheck = Physics2D.CircleCast(transform.position, 2f, Vector2.up);

        if(EnemyCheck.collider.tag == "Enemy"){
            Destroy(EnemyCheck.collider);
        }
    } 

    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
