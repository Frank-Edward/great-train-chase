using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public Rigidbody body;
    public Animator animator;
    public Transform character;
    public Transform crosshair;
    public Animator crosshairAnimator;
    float horizontal;
    float vertical;

    public float runSpeedH = 15.0f;
    public float runSpeedV = 20.0f;
    public float multiplierDown = 1.5f;
    public float multiplierUp = 0.8f;
    public float maxJumpVelocity = 100.0f;
    public float maxRunVelocity = 5.0f;
    public float maxCollisionVelocity = 200.0f;
    private bool jumpHeld = false;
    private bool landing = false;
    private bool onSplatTrack = false;
    private bool onSlope = false;
    private bool touching = false; //trying this out
    private bool walkHeld = false;

    void Start()
    {
        animator.SetBool("isIdle", true);
        animator.SetBool("isGrounded", true);
        animator.SetBool("isFacingRight", true);
        animator.SetBool("isCrosshairPressed", false);

        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);
        animator.SetBool("isLanding", false);
        animator.SetBool("isColliding", false);
        animator.SetBool("isSplat", false);
        animator.SetBool("canLasso", true);
        animator.SetBool("isColliding", false);
        animator.SetBool("isSplat", false);
        onSplatTrack = false;
        onSlope = false;
        //touching = false;
        walkHeld = false;

}

private void Reset()
    {
        animator.SetBool("isIdle", true);
        animator.SetBool("isGrounded", true);
        animator.SetBool("isFacingRight", true);
        //animator.SetBool("isCrosshairPressed", false);

        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isFalling", false);
        animator.SetBool("isLanding", false);
        animator.SetBool("isColliding", false);
        animator.SetBool("isSplat", false);
        animator.SetBool("canLasso", true);
        animator.SetBool("isColliding", false);
        animator.SetBool("isSplat", false);
        landing = false;
        onSplatTrack = false;
        onSlope = false;
        touching = false;
        walkHeld = false;

}

void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            if (animator.GetBool("isColliding")) { 
                animator.SetBool("isSplat", true);
                animator.SetBool("isColliding", false);
            }
            animator.SetBool("isGrounded", true);
            animator.SetBool("canLasso", true);
            crosshairAnimator.SetBool("isDefault", true);
            crosshairAnimator.SetBool("isReady", false);
            crosshairAnimator.SetBool("isGrabbed", false);

            if (animator.GetBool("isFalling"))
            {
                animator.SetBool("isLanding", true);
                animator.SetBool("isFalling", false);
                landing = true;
            }
            
           
        }

        if (collision.gameObject.tag == "wall")
        {
            //touching = true;
            if (((Mathf.Abs(collision.relativeVelocity.x) > maxCollisionVelocity)&&(animator.GetBool("isGrounded")==false)))
            {/*|| (Mathf.Abs(collision.relativeVelocity.y) > maxCollisionVelocity))*/
                animator.SetBool("isColliding", true);
            }
        }
        if (collision.gameObject.tag == "splat-track")
        {
            Debug.Log("IN HERE");
            animator.SetBool("isSplat", true);
            onSplatTrack = true;
        }
        if (collision.gameObject.tag == "slope") {
            onSlope = true;
            Debug.Log("HERE");
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.tag == "floor")) {
            animator.SetBool("isGrounded", true);
       }
       else
        {
            animator.SetBool("isGrounded", false);
        }
    }
    ///private void OnCollisionStay(Collision collision)
    //{
    //    if ((collision.gameObject.tag == "floor") && animator.GetBool("isGrounded")) {
    //        crosshairAnimator.SetBool("isDefault", true);
    //        crosshairAnimator.SetBool("isReady", false);
    //        crosshairAnimator.SetBool("isGrabbed", false);
    //        animator.SetBool("canLasso", true);
    //   }
    //}


    void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "floor")
        {
            animator.SetBool("isGrounded", false);
            animator.SetBool("isFalling", false);
        }
        if (collision.gameObject.tag == "splat-track")
        {
            
            onSplatTrack = false;
        }
        if (collision.gameObject.tag == "slope")
        {
            onSlope = false;
        }

        //if (collision.gameObject.tag == "wall")
        //{

        //    touching = false;
        //}
    }

    void Update()
    {
        //if (animator.GetBool("isGrounded")&&(!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))) {
        //animator.SetBool("canLasso", true);
        //}
        // Gives a value between -1 and 1
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("splat")){
            if (onSplatTrack) {
                return;
            }
            Reset();
            return;
        }
        if (animator.GetBool("isGrounded")) {

            if (animator.GetBool("isJumping")) {
               // animator.SetBool("isJumping", false);
                //animator.SetBool("isFalling", true);
            }
            //else 
            if (animator.GetBool("isFalling"))
            {
                    animator.SetBool("isLanding", true);
                    animator.SetBool("isFalling", false);
                    landing = true;
            }

            animator.SetBool("canLasso", true);
            if (crosshairAnimator.GetBool("isGrabbed")&&!animator.GetBool("isCrosshairPressed")) {
                crosshairAnimator.SetBool("isDefault", true);
                crosshairAnimator.SetBool("isReady", false);
                crosshairAnimator.SetBool("isGrabbed", false);
                //SET mouse up here to remove the pressed state
            }
        }


        if ( Input.GetButtonDown("Vertical"))
        {
            vertical = 0;
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if ((jumpHeld == false) && (animator.GetBool("isGrounded")))
                {
                    vertical = Input.GetAxisRaw("Vertical"); // -1 is down
                    jumpHeld = true;
                    animator.SetBool("isJumping", true);
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isWalking", false);
                }

            }
            
        }
        if (Input.GetButtonUp("Vertical")) {
            jumpHeld = false;
        }
        if (animator.GetBool("isCrosshairPressed") == true) {
            if ((crosshair.position.x - character.position.x) > 0)
            {

                animator.SetBool("isFacingRight", true);
                character.eulerAngles = new Vector3(0, 0, 0);
            }
            else {
                animator.SetBool("isFacingRight", false);
                character.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            walkHeld = true;
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            walkHeld = false;
            animator.SetBool("isWalking", false);
            
        }
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left

        if ((horizontal != 0) && (animator.GetBool("isJumping")==false) && (animator.GetBool("isFalling") == false)&& (animator.GetBool("isGrounded") == true)&&(animator.GetCurrentAnimatorStateInfo(0).IsName("idle")|| animator.GetCurrentAnimatorStateInfo(0).IsName("walk")))//there is something wrong with the logic, check if a simpler way to set it
        {
            animator.SetBool("isWalking", true);//maybe bug is here
            animator.SetBool("isIdle", false);
            if (horizontal < 0)
            {

                character.eulerAngles = new Vector3(0, 180, 0);
            }
            else {
                character.eulerAngles = new Vector3(0, 0, 0);
            }

        }
        else if ((horizontal == 0) && (animator.GetBool("isJumping") == false) && (animator.GetBool("isFalling") == false) && (animator.GetBool("isGrounded") == true) && (animator.GetCurrentAnimatorStateInfo(0).IsName("idle") || animator.GetCurrentAnimatorStateInfo(0).IsName("walk")) )//there is something wrong with the logic, check if a simpler way to set it
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("landing"))
        {
            horizontal = 0;
            vertical = 0;
            Reset();
        }
        if (landing)
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isLanding", false);
            Reset();///THIS IS THE LAST ADDITION//removed is idle true for landing animation
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                landing = false;
            }
        }
    }

    void FixedUpdate()
    {
        //if ((body.velocity.y > 300)||(!onSplatTrack)) {
        //    body.velocity = new Vector3(body.velocity.x, 300, 0);
        //}
        //if ((body.velocity.x > 300) || (!onSplatTrack))
        //{
        //    body.velocity = new Vector3(300, body.velocity.y, 0);
        //}
        if (onSplatTrack) {
            body.velocity = new Vector3(-400, 1, 0);
            return;
        }
        if (onSlope)
        {//||touching
            body.velocity += new Vector3(0, (Physics.gravity.y) * multiplierDown, 0);
            return;
        }
        if (animator.GetBool("isColliding")||animator.GetCurrentAnimatorStateInfo(0).IsName("splat")){
            body.velocity += new Vector3(0, (Physics.gravity.y) * multiplierDown, 0);
            return;
        }
        if (jumpHeld == false)
        {
            vertical = 0;
        }
        else if (animator.GetBool("isJumping")){
            if ((body.velocity.y > maxJumpVelocity) && (animator.GetBool("isJumping")))
            {
                vertical = 0;
                //animator.SetBool("isJumpingRight", false);
            }
        }     
        if ((body.velocity.y <= 0)&&(animator.GetBool("isGrounded")==false)) {//took out the equals
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
            vertical = 0;

        }
        if (Mathf.Abs(body.velocity.x) > maxJumpVelocity){
            horizontal = 0; 
        }


        if ((horizontal != 0) && (vertical != 0))
        {
            body.velocity += new Vector3(horizontal * runSpeedH, vertical * runSpeedV, 0);
        }
        else if (vertical == 0){
            if (body.velocity.y > 0) {
                body.velocity += new Vector3(horizontal * runSpeedH, (Physics.gravity.y) * multiplierUp, 0);
            }

            else
            {
                body.velocity += new Vector3(horizontal * runSpeedH, (Physics.gravity.y) * multiplierDown, 0);
            }
        }
        else {
            body.velocity += new Vector3(0, vertical * runSpeedV, 0);

        }
    }
}
