using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 50f;
    public float MaxHP = 50f;
    int MinHP = 0;
    public Text Healthtxt;
    public Text MaxHp;

    void Update()
    {
        //Basic not staying health 
        Healthtxt.text = ("HP: " + Health.ToString());

        MaxHp.text = ("Max HP: " + MaxHP.ToString());

        DeathCheck();

        //Health caps
        if(Health > MaxHP){
            Health = MaxHP;
            Healthtxt.text = Health.ToString();
        } else if(Health < MinHP){
            Health = MinHP;
        }

        if(Time.time > StartToRegen){
            StartToRegen = Time.time + RegenRate;
            HealthRegen();
        }
    }

    void DeathCheck(){
        if(Health <= 0){
            Debug.Log("Player dead");
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    float StartToRegen = 5f;
    float RegenRate = 5f;

    void HealthRegen(){
        Health += 2f;
    }
}
