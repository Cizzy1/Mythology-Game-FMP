using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossTele : MonoBehaviour
{
    bool PlayerCheck;
    float circleRadius = 1f;
    [SerializeField]public LayerMask Player;
    public Transform PlayerLvl;
    public GameObject Interact;

    [Header("To points")]
    public Transform ToPoint;

    
    void Update()
    {
        var level= PlayerLvl.GetComponent<Currency_system>().PlLvl;
        PlayerCheck = Physics2D.OverlapCircle(transform.position, circleRadius, Player);

        if(PlayerCheck){
            Interact.SetActive(true);
        } else{
            Interact.SetActive(false);
        }
        if(level >= 25){
            if(PlayerCheck && Input.GetKeyDown(KeyCode.E)){
                PlayerLvl.transform.position = ToPoint.position;
            }
        }
    }
}
