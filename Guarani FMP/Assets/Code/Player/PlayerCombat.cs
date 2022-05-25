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
    public LayerMask EnemyLayers;

    public Animator anim;

    void Update()
    {            
        if(Input.GetMouseButton(0) && Time.time > StartAttack){
            Debug.Log("Has attacked");
            anim.SetBool("hasAttacked", true);
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, EnemyLayers);     
        foreach(Collider2D player in hitplayer)
        {
            player.GetComponent<Basic_Enemy_Health>().Health -= Damage;
        }
    }
    void OnDrawGizmosSelected()
    {
       Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
