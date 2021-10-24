using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
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
        if ((other.gameObject.tag == "floor")||(other.gameObject.tag == "wall") || (other.gameObject.tag == "slope"))
        {
            crosshairAnimator.SetBool("isReady", true);
            crosshairAnimator.SetBool("isDefault", false);
            //inWall = true;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if((other.gameObject.tag == "floor") || (other.gameObject.tag == "wall") || (other.gameObject.tag == "slope"))
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
        if (crosshairAnimator.GetCurrentAnimatorStateInfo(0).IsName("default")){
            crosshair.eulerAngles += new Vector3(0, 0, rotationSpeed);
        }
        else if (crosshairAnimator.GetCurrentAnimatorStateInfo(0).IsName("ready")){
            crosshair.eulerAngles += new Vector3(0, 0, rotationSpeedFast);
        }
        /*if (inWall&& !crosshairAnimator.GetCurrentAnimatorStateInfo(0).IsName("grabbed")) {
            crosshairAnimator.SetBool("isReady", true);
            crosshairAnimator.SetBool("isDefault", false);
        }
        if (characterAnimator.GetBool("isGrounded")&& crosshairAnimator.GetCurrentAnimatorStateInfo(0).IsName("grabbed"))
        {
            crosshairAnimator.SetBool("isDefault", true);
            crosshairAnimator.SetBool("isReady", false);
            crosshairAnimator.SetBool("isGrabbed", false);
        }*/



        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = Camera.main.nearClipPlane;
        //worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        if (!characterAnimator.GetBool("isCrosshairPressed"))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 110);
            crosshair.position = Camera.main.ScreenToWorldPoint(mousePosition);
            scale = Mathf.Sqrt((crosshair.position.x - body.position.x) * (crosshair.position.x - body.position.x) + (crosshair.position.y - body.position.y) * (crosshair.position.y - body.position.y));
            if (scale > maxDistance)
            {
                ratio = maxDistance / scale;
                x = (crosshair.position.x - body.position.x) * ratio;
                y = (crosshair.position.y - body.position.y) * ratio;
                crosshair.position = new Vector3(body.position.x + x, body.position.y + y, crosshair.position.z);
                //crosshairAnimator.SetTrigger("isDefault");
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)&&characterAnimator.GetBool("canLasso"))
        {
            characterAnimator.SetBool("isCrosshairPressed", true);
            //crosshairAnimator.SetTrigger("isReady");
            
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Debug.Log("IN HERE IN HERE IN HERE");
            characterAnimator.SetBool("isCrosshairPressed", false);
            //crosshairAnimator.SetTrigger("isDefault");

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
