using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Transform Player;
    public Transform Location;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            Tp();
        }
    }

    void Tp(){
        Player.position = Location.position;
    }
}
