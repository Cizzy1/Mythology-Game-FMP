using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackrange = 0.5f;
    public Transform attackpoint;
    public float Damage = 25f;
    public float StartAttack = 1.5f;
    private float AttackRate = 1.5f;
    public LayerMask playerLayers;

    public Animator anim;

    void Update()
    {            
        if(Input.GetMouseButton(0) && Time.time > StartAttack){
            Debug.Log("Has attacked");
            anim.SetBool("isAttacking", true);
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, playerLayers);     
        foreach(Collider2D player in hitplayer)
        {
            player.GetComponent<PlayerHealth>().Health -= Damage;
        }
    }
    void OnDrawGizmosSelected()
    {
       Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
