using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateUpgrade : MonoBehaviour
{
    public GameObject KeyUI;
    public GameObject StatUI;

    bool statActive;

    void Update()
    {
        RaycastHit2D playerCheck = Physics2D.CircleCast(transform.position, 2f, Vector2.up);

        //Debug.Log(playerCheck.ToString());

        if(playerCheck.collider.tag == "Player"){
            KeyUI.SetActive(true);
            //Debug.Log("popped up");
        } else{
            KeyUI.SetActive(false);
        } 

        if(Input.GetKeyDown(KeyCode.E) && playerCheck.collider.tag == "Player"){

            Debug.Log("stats UI active");

            StatUI.SetActive(true);
            statActive = true;
            KeyUI.SetActive(false);
        }
    }

    public void CloseStats(){
        StatUI.SetActive(false);
    }
}
