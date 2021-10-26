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
    public Animator characterAnimator;
    
    private bool paused;
    void Start()
    {
        paused = false;
        player.loop = false;
        player2.loop = true;
        player.clip = intro;
        player2.clip = body;
        player.Play();
        player2.PlayDelayed(player.clip.length);
    }
    private void Update()
    {
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("splat"))
        {
            player2.Pause();
            player3.clip = trackFxRec;
            //dwplayer3.Play();
            paused = true;
        }
        if (paused && !characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("splat"))
        {
            player3.clip = trackFxstop;
            //player3.Play();
            //player2.PlayDelayed(player3.clip.length);
            player2.Play();
            paused = false;
        }
    }
}

    