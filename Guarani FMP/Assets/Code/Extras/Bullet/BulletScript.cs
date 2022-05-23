using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Dart_Damage = 10;
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Enemy")){
            col.gameObject.GetComponent<Basic_Enemy_Health>().Health -= Dart_Damage;
        } 

        
        Destroy(this.gameObject);
    }
}
