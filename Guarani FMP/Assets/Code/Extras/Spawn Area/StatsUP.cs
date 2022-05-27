using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUP : MonoBehaviour
{
    public GameObject Player;

    public void UpHealth(){
        var cash = Player.GetComponent<Currency_system>();
        var health = Player.GetComponent<PlayerHealth>();

        if(cash.Currency > 0){
            cash.Currency -= 1;
            cash.PlLvl += 1;
            health.MaxHP += 10;
            Debug.Log("Health +10");
        }
    }

    public void UpDmg_AXE(){
        var cash = Player.GetComponent<Currency_system>();
        var dmg = Player.GetComponent<PlayerCombat>();

        if(cash.Currency > 0){
            cash.Currency -= 1;
            cash.PlLvl += 1;
            dmg.Damage += 10;
            Debug.Log("dmg +10");
        }
    }

    public void UpDmg_Dart(){
        var cash = Player.GetComponent<Currency_system>();
        var dmg = Player.GetComponent<DartSummon>();

        if(cash.Currency > 0){
            cash.Currency -= 1;
            cash.PlLvl += 1;
            dmg.BowDamage += 10;
            Debug.Log("dmg +10");
        }
    }
}
