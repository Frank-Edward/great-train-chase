using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleAudioController : MonoBehaviour
{
    public AudioClip theme;
    public AudioSource player;

    void Start()
    {
        player.loop = true;
        player.clip = theme;
    }
    private void OnCollisionEnter(Collision collision)
    {

        player.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
