using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Enemy_Health : MonoBehaviour
{
    public GameObject Player;
    public float Health = 50f;

    float Drop = 1f;

    void Update()
    {
        if(Health <= 0){
            Destroy(this.gameObject);
            Player.GetComponent<Currency_system>().Currency += Drop;
        }
    }
}
