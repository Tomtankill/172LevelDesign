using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueText : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject player;
    public GameObject NPC;
    public float sentencewait = 3f;
    public GameObject menucanvas;
    public GameObject playermenu;
    public GameObject menucamera;

    void Start() {

    }

    void Update() {
        float distance = Vector3.Distance (player.transform.position, NPC.transform.position);
        if (Input.GetKeyDown(KeyCode.Mouse1) && (distance < 50))
            dialoguestart();
        if (Input.GetKeyDown(KeyCode.Escape)){
            menucanvas.SetActive(true);
            playermenu.SetActive(false);
            menucamera.SetActive(true);
        }
            
        if (textDisplay.text == sentences[index]) {
            sentencewait -= Time.deltaTime;
            if (sentencewait <= 0) {
                NextSentence();
            }
        }
    }
    public void dialoguestart() {
        StartCoroutine(Type());
    }


    IEnumerator Type() {
        foreach(char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }
    public void NextSentence() {
        if (index < sentences.Length - 1) {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            sentencewait = 3f;

        } else {
            textDisplay.text = "";
            sentencewait = 3f;
        }
    }
    ///https://www.youtube.com/watch?v=f-oSXg6_AMQ
}
