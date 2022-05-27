using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTele : MonoBehaviour
{
    bool PlayerCheck;
    float circleRadius = 1f;
    [SerializeField]public LayerMask Player;
    public GameObject PlayerLvl;

    
    void Update()
    {
        var level= PlayerLvl.GetComponent<Currency_system>().PlLvl;
        PlayerCheck = Physics2D.OverlapCircle(transform.position, circleRadius, Player);

        if(level <= 10){
            if(PlayerCheck && Input.GetKeyDown(KeyCode.E)){
                //needs finishing
            }
        }
    }
}
