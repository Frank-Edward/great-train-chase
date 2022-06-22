using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float Timer = 0.0f;
    public Text uiText1;
    public Text uiText2;
    public Animator characterAnimator;
    public int splats = 0;
    bool splated = false;
    // Start is called before the first frame update
    void Start()
    {
        int splats = 0;
        float Timer = 0.0f;
        bool splated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("splat")&&!splated){
            splats += 1;
            splated = true;
        }
        if ((!characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("splat"))&& (!characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("splat")))
        {

            splated = false;
        }
        if (!characterAnimator.GetBool("isWin")){
            Timer += Time.deltaTime;
            float var = Mathf.Round(Timer*100)/100;
            uiText1.text = "Time: " + var;
            uiText2.text = "Splats: " + splats;
        }
    }
}
