using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip intro;
    public AudioClip body;
    public AudioClip trackFxRec;
    public AudioClip trackFxstop;
    public AudioSource player;
    public AudioSource player2;
    public AudioSource player3;
    public AudioSource player4;
    public Animator characterAnimator;
    bool stopped = false;

    //add bool for music start

    private bool paused;
    void Start()
    {
        paused = false;
        player.loop = false;
        player2.loop = true;
        player3.loop = false;
        player4.loop = false;
        player.clip = intro;
        player2.clip = body;
        player3.clip = trackFxRec;
        player4.clip = trackFxstop;
        player.Play();
        player2.PlayDelayed(player.clip.length);
        stopped = false;
    }
    private void Update()
    {
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("splat")&&player2.isPlaying)
        {
            player2.Pause();
            //player3.Play();
            paused = true;
        }
        if (paused && !characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("splat"))
        {
           //player4.Play();
            //player2.PlayDelayed(player4.clip.length);
            player2.Play();
            paused = false;
        
        }
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Win")&&!stopped)
        {

            player2.Stop();
            stopped = true;

            print("IN HERE");
        }
    }
}

    