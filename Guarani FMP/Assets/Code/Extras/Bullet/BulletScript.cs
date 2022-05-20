using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject Player;
    void OnCollisionEnter2D(Collider2D col){
        var BowDmg = Player.GetComponent<DartSummon>().BowDamage; 
        col.gameObject.GetComponent<Basic_Enemy_Health>().Health -= BowDmg; 
        Destroy(this.gameObject);
    }
}
