using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackrange = 2f;
    public Transform attackpoint;
    public float Damage = 25f;
    float StartAttack = 1.5f;
    float AttackRate = 1.5f;
    public LayerMask EnemyLayers;
    private Rigidbody2D _rb;

    public Animator anim;

    bool HasAttacked;
    bool IsMoving;

    void Start(){
        _rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {            
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time > StartAttack){
            HasAttacked = true;
            if(HasAttacked){
                StartAttack = Time.time + AttackRate;
                Debug.Log("Has attacked");
                Attack();
            }
            
        } else{
            HasAttacked = false;
        }

        if(_rb.velocity.x <= 0.5f){
            IsMoving = true;
        } else{
            IsMoving = false;
        }

        if(IsMoving && HasAttacked){
            _rb.velocity = Vector2.zero;
        }
    }

    void Attack()
    {
        anim.SetTrigger("hasAttacked");
        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, EnemyLayers);
        foreach(Collider2D enemy in hitenemy)
        {
            enemy.GetComponent<Basic_Enemy_Health>().Health -= Damage;
            Debug.Log("Enemy hit");
        }
    }
    void OnDrawGizmosSelected()
    {
       Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
