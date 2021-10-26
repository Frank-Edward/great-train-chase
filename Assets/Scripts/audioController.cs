using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip intro;
    public AudioClip body;
    public AudioSource player;
    public AudioSource player2;
    void Start()
    {
        player.loop = false;
        player2.loop = true;
        player.clip = intro;
        player2.clip = body;
        player.Play();
        player2.PlayDelayed(player.clip.length);
    }

}

    