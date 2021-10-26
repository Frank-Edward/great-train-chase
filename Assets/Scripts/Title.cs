using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour

{
    public AudioClip theme;
    public AudioSource player;
    private bool playing = false;
    public GameObject startButton;

    void Start()
    {
        player.loop = true;
        player.clip = theme;
        playing = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        if (playing == false)
        {
            if (collision.gameObject.tag == "stand")
            {
                print("IN HERE IN HERE IN HERE");
                player.Play();
                playing = true;
            }
            startButton.SetActive(true);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        return;
    }
}


