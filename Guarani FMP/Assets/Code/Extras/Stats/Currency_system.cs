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

    void Update()
    {
        Amount.text = "₲  " + Currency.ToString();
    }
}
