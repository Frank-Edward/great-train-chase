using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class c_mod : MonoBehaviour
{
    public Transform crosshair;
     public Animator crosshairAnimator;
    public Camera mainCamera;
    public float rotationSpeed = 1.0f;
    public float rotationSpeedFast = 1.8f;
    public float cameraDistance = 110.0f;

    private float scale;
    private float ratio;
    private float x;
    private float y;
    private bool pressed;
    //private bool inWall;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;

        crosshairAnimator.SetBool("isDefault", true);
        crosshairAnimator.SetBool("isReady", false);
        crosshairAnimator.SetBool("isGrabbed", false);
        pressed = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.tag == "start") || (other.gameObject.tag == "continue"))
        {
            crosshairAnimator.SetBool("isReady", true);
            crosshairAnimator.SetBool("isDefault", false);
            //inWall = true;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if ((other.gameObject.tag == "start") || (other.gameObject.tag == "wall"))
        {
            crosshairAnimator.SetBool("isReady", true);
            crosshairAnimator.SetBool("isDefault", false);

        }
        if (pressed&&(other.gameObject.tag =="start"))
        {
            print("here");
            SceneManager.LoadScene("L_OMEGALUL_RE");
        }

    }

    private void OnCollisionExit(Collision other)
    {
        if ((crosshairAnimator.GetCurrentAnimatorStateInfo(0).IsName("ready")))
        {
            crosshairAnimator.SetBool("isDefault", true);
            crosshairAnimator.SetBool("isReady", false);
            //inWall = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (crosshairAnimator.GetCurrentAnimatorStateInfo(0).IsName("default")){
            crosshair.eulerAngles += new Vector3(0, 0, rotationSpeed);
        }
        else if (crosshairAnimator.GetCurrentAnimatorStateInfo(0).IsName("ready")){
            crosshair.eulerAngles += new Vector3(0, 0, rotationSpeedFast);
        }
        
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDistance);
        crosshair.position = Camera.main.ScreenToWorldPoint(mousePosition);

        
        if (Input.GetKeyDown(KeyCode.Mouse0)&&crosshairAnimator.GetCurrentAnimatorStateInfo(0).IsName("ready"))
        {
            pressed = true;

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            pressed = false;
        }

    }

    //private void FixedUpdate()
    //{
    //    if (characterAnimator.GetBool("canLasso"))
    //    {
    //        crosshairAnimator.SetTrigger("isDefault");
    //    }
    //}
}
