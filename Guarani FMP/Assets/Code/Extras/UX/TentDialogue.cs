using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TentDialogue : MonoBehaviour
{
    [SerializeField] LayerMask Player;
    public float circleRadius;
    public GameObject Interact;
    public GameObject Panel;
    bool PlayerCheck;
    bool isInteract;

//////////////////----------------------------------

    public TextMeshProUGUI Dialogue;
    public string[] lines;
    public float textSpeed;
    private int index;

//////////////////----------------------------------

    void Start(){
        Dialogue.text = string.Empty;
    }

    void Update()
    {
        PlayerCheck = Physics2D.OverlapCircle(transform.position, circleRadius, Player);

        if(PlayerCheck){
            Interact.SetActive(true);
            isInteract = true;
            //Debug.Log("popped up");
        } else{
            Interact.SetActive(false);
            isInteract = false;
        }

        //isInteract = false;

        if(Input.GetKeyDown(KeyCode.E) && PlayerCheck && isInteract){
            Debug.Log("Panel up");
            Panel.SetActive(true);
            isInteract = false;
            Interact.SetActive(false);
            StartDialogue();
        }

        if(Input.GetMouseButtonDown(0)){
            if(Dialogue.text == lines[index]){
                NextLine();
            }
        } else{
            StopAllCoroutines();
            Dialogue.text = lines[index];
        }
    }

    public void CloseDialogue(){
        Panel.SetActive(false);
    }

    void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach (char c in lines[index].ToCharArray())
        {
            Dialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if(index < lines.Length - 1){
            index++;
            Dialogue.text = string.Empty;
            StartCoroutine(TypeLine());
        } 
    }
}
