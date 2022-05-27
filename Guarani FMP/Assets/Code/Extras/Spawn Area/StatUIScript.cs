using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUIScript : MonoBehaviour
{
    //This controls the openeing and closing of the stats pannel at the ruin.
    public GameObject KeyUI;
    public GameObject StatUI;

    [SerializeField] LayerMask Player;
    public float circleRadius;
    bool PlayerCheck;

    bool isKeyActive;
    bool statActive;
    bool RuinActive;

    void Update()
    {
        PlayerCheck = Physics2D.OverlapCircle(transform.position, circleRadius, Player);


        if(PlayerCheck){
            KeyUI.SetActive(true);
            isKeyActive = true;
            //Debug.Log("popped up");
        } else{
            KeyUI.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E) && PlayerCheck && isKeyActive){

            //Debug.Log("stats UI active");
            StatUI.SetActive(true);
            statActive = true;
            KeyUI.SetActive(false);
        }
    }

    public void CloseStats(){
        StatUI.SetActive(false);
    }


//Gizmos
//////////////////----------------------------------
    void OnGizmosDrawSelected(){
        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }
}
