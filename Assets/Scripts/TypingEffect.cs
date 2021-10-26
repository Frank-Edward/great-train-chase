using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public float speed = 0.1f;
    public string totalText;
    private string currentText = "";
    public Text ui_text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypingText());
    }

    // Update is called once per frame
    IEnumerator TypingText() {
        for (int i = 0; i < totalText.Length; i++){
            currentText = totalText.Substring(0, i);
            ui_text.text = currentText;
            yield return new WaitForSeconds(speed);
        }
    }
}

