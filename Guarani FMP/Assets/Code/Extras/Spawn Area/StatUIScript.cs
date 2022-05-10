using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUIScript : MonoBehaviour
{
    //This controls the openeing and closing of the stats pannel at the ruin.
    public GameObject KeyUI;
    public GameObject StatUI;

    bool isKeyActive;
    bool statActive;
    bool RuinActive;

    /* void Start(){
        var test1 = Player.GetComponent<Currency_system>();
    } */

    void Update()
    {
        RaycastHit2D playerCheck = Physics2D.CircleCast(transform.position, 2f, Vector2.up);

        //Debug.Log(playerCheck.ToString());

        if(playerCheck.collider.tag == "Player"){
            KeyUI.SetActive(true);
            isKeyActive = true;
            //Debug.Log("popped up");
        } else{
            KeyUI.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E) && playerCheck.collider.tag == "Player" && isKeyActive){

            //Debug.Log("stats UI active");
            StatUI.SetActive(true);
            statActive = true;
            KeyUI.SetActive(false);
        }
    }

    public void CloseStats(){
        StatUI.SetActive(false);
    }
}
