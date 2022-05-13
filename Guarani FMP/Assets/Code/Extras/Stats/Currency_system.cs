using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency_system : MonoBehaviour
{
    // Holds the player currency
    
    public Text Amount;
    public float Currency;
    string Key = "Curent";

    void Start(){
        PlayerPrefs.GetFloat(Key, Currency);
        //Debug.Log(PlayerPrefs.GetFloat(Key).ToString());
    }
    void Update()
    {
        PlayerPrefs.SetFloat(Key, Currency);
        Amount.text = "₲:" + Currency.ToString();
        //Debug.Log(Currency.ToString());
        PlayerPrefs.Save();
    }
}
