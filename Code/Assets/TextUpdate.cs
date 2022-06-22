using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextUpdate : MonoBehaviour
{
    float Timer = 0.0f;
    public Text uiText1;
    public Text uiText2;
    public Text uiText3;
    public Text uiTextres1;
    public Text uiTextres2;
    public Animator characterAnimator;
    public Transform box;
    private bool ran = false;
    public GameObject timerObject;
    public AudioSource player;
    public AudioClip endClip;

    // Start is called before the first frame update
    void Start()
    {
        int splats = 0;
        float Timer = 0.0f;
        bool splated = false;
        ran = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Win") && !ran)
        {
            player.Stop();
            player.clip = endClip;
            player.Play();

            box.Translate(-150, 0, 0);
            StartCoroutine(ResultScreen());
            ran = true;
        }
        if (Input.anyKeyDown && ran)
        {
            SceneManager.LoadScene("Title");
        }
       
    }
    IEnumerator ResultScreen()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                uiText1.text = uiTextres1.text;
            }
            else if (i == 1)
            {
                uiText2.text = uiTextres2.text;
            }
            else
            {
                float timer = timerObject.GetComponent<TimerScript>().Timer;
                int splats = timerObject.GetComponent<TimerScript>().splats;
                if ((timer <= 120) && (splats == 0)) {
                    uiText3.text = "Rank: SS";
                }
                else if((timer <= 150) && (splats ==0)) {
                    uiText3.text = "Rank: S";
                }
                else if ((timer <= 200) && (splats < 3))
                {
                    uiText3.text = "Rank: A";
                }
                else if ((timer <= 500) && (splats < 10))
                {
                    uiText3.text = "Rank: B";
                }
                else if ((timer <= 600))
                {
                    uiText3.text = "Rank: C";
                }
                else
                {
                    uiText3.text = "Rank: D";
                }

            }
            yield return new WaitForSeconds(1f);
        }
    }
}
