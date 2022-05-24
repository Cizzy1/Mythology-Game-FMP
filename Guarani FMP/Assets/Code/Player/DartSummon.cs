using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSummon : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    public float bowChargeTime;

    public float BowDamage = 10f;
    float bowMax = 1;

    void Update(){
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.up = direction;
        
        if (Input.GetMouseButton(1)){
            bowChargeTime += Time.deltaTime;
        }

        if(bowChargeTime >= bowMax){
            bowChargeTime = bowMax;
        }
            
        if (Input.GetMouseButtonUp(1)){
            Shoot();
            bowChargeTime = 0;
        }
    }
    
    void Shoot(){
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        Rigidbody2D rb = newArrow.GetComponent<Rigidbody2D>();
        rb.AddForce(shotPoint.up * launchForce * bowChargeTime, ForceMode2D.Impulse);
    }
        
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    public float SmoothSpeed = .25f; 
    public Transform Player;

    void LateUpdate(){
        Vector3 targetPosition = Player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothSpeed);
    }
}

