using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency_system : MonoBehaviour
{
    // Holds the player currency
    [Header("Currency")]
    public Text Amount;
    public Text StoreAmount;
    public float Currency;
    string Key = "Current";

    [Header("Level")]
    public Text level;
    public float PlLvl;

    void Update()
    {
        Amount.text = "₲  " + Currency.ToString();
        StoreAmount.text = "Currency: ₲ " + Currency.ToString();

        level.text = PlLvl.ToString();
        //Debug.Log(PlLvl.ToString());
    }
}
