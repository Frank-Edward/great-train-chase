using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public Transform character;
    public Transform car;
    public Animator characterAnimator;
    public Animator carAnimator;
    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        car.position = new Vector3(character.position.x - 50, car.position.y, car.position.z);
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("splat")) {
            carAnimator.enabled = false;
            paused = true;
        }
        if (paused && !characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("splat")) {
            carAnimator.enabled = true;
            paused = false;
        }

    }
}
