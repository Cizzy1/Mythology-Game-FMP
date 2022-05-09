using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mockscript : MonoBehaviour
{
    public Text Mock;
    int num = 1;
    int add = 1;

    void Start(){
        Mock.text = PlayerPrefs.GetInt("Count", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            num += add; 
        }
        Mock.text = num.ToString();
        PlayerPrefs.SetInt("Count", num);

    }
}
