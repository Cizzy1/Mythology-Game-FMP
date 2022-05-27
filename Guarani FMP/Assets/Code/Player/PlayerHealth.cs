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

    void Start(){
        //HealthBar.setHealth(Health);
    }


    void Update()
    {
        //Basic not staying health 
        Healthtxt.text = (Health.ToString());

        MaxHp.text = ("Max HP: " + MaxHP.ToString());

        HealthBarFiller();
        lerpSpeed = 3f * Time.deltaTime;

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

//////////////////----------------------------------

    float StartToRegen = 5f;
    float RegenRate = 5f;

    void HealthRegen(){
        Health += 2f;
    }

//////////////////----------------------------------


    public Image HealthBar;
    public float lerpSpeed;

    void HealthBarFiller(){
        HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, Health / MaxHP, lerpSpeed);
    }
}
