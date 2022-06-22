using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair_modified : MonoBehaviour
{
    public Transform crosshair;
    public Transform body;
    public Animator characterAnimator;
    public Animator crosshairAnimator;
    public Camera mainCamera;
    public float maxDistance = 50.0f;
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

        characterAnimator.SetBool("isCrosshairPressed", false);
        crosshairAnimator.SetBool("isDefault", true);
        crosshairAnimator.SetBool("isReady", false);
        crosshairAnimator.SetBool("isGrabbed", false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.tag == "floor")||(other.gameObject.tag == "wall"))
        {
            crosshairAnimator.SetBool("isReady", true);
            crosshairAnimator.SetBool("isDefault", false);
            //inWall = true;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if((other.gameObject.tag == "floor") || (other.gameObject.tag == "wall"))
        {
            crosshairAnimator.SetBool("isReady", true);
            crosshairAnimator.SetBool("isDefault", false);

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
        /*
        if (crosshairAnimator.GetCurrentAnimatorStateInfo(0).IsName("default")){
            crosshair.eulerAngles += new Vector3(0, 0, rotationSpeed);
        }
        else if (crosshairAnimator.GetCurrentAnimatorStateInfo(0).IsName("ready")){
            crosshair.eulerAngles += new Vector3(0, 0, rotationSpeedFast);
        }
        
        if (!characterAnimator.GetBool("isCrosshairPressed"))*/
        
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 110);
        crosshair.position = Camera.main.ScreenToWorldPoint(mousePosition);
            
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
    
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
  
        } */   
     
    }

    //private void FixedUpdate()
    //{
    //    if (characterAnimator.GetBool("canLasso"))
    //    {
    //        crosshairAnimator.SetTrigger("isDefault");
    //    }
    //}
}
