using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy_1 : MonoBehaviour
{
    public Transform player;

    int Damage = 10;
    float nextAttack = 2f;
    float attackRate = 2f;

    float MinDis = 5f;
    float MinAttackDis = 1.3f;

    bool AttackReady;

    void Update()
    {
        AttackReady = false;
        Attack();
    }

    void Attack(){
        if(Vector2.Distance(transform.position, player.position) < MinAttackDis && Time.time > nextAttack){
            nextAttack = Time.time + attackRate;
            AttackReady = true;
            player.GetComponent<PlayerHealth>().Health -= Damage;
        }
    }
}
