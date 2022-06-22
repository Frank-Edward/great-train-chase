using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasso : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    //public DistanceJoint2D _distanceJoint;
    public Transform crosshair;
    public Transform body;
    public Transform hand;
    public Rigidbody rb;
    public Animator characterAnimator;
    public Animator crosshairAnimator;
    public float pullScaling = 1.5f;
    private bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer.enabled = false;
            //_distanceJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed) {
            _lineRenderer.SetPosition(0, hand.position);
            _lineRenderer.SetPosition(1, crosshair.position);
            //Vector3 v = crosshair.position-body.position;
            
            //body.rotation = Quaternion.FromToRotation(Vector3.right, v);
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && characterAnimator.GetBool("canLasso") && crosshairAnimator.GetCurrentAnimatorStateInfo(0).IsName("ready"))
        {
            pressed = true;
            _lineRenderer.SetPosition(0, hand.position);
            _lineRenderer.SetPosition(1, crosshair.position);
            // _distanceJoint.connectedAnchor = mousePos;
            //_distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
            characterAnimator.SetBool("canLasso", false);
            crosshairAnimator.SetBool("isReady", false);
            crosshairAnimator.SetBool("isGrabbed", true);
            characterAnimator.SetTrigger("lassoAnimation");
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            pressed = false;
            //_distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
            //abody.eulerAngles = new Vector3(0, 0, 0);

        }
        //if (_distanceJoint.enabled)
        //{
        //    _lineRenderer.SetPosition(1, transform.position);
        //}
        /* SOMETHING HERE TO MAKE THE GROUNDED THINGS WORK*/
        if (characterAnimator.GetBool("isSplat")) {//most recent, this is aight so far
            pressed = false;
            _lineRenderer.enabled = false;
            characterAnimator.SetBool("isCrosshairPressed", false);
        }
    }
    private void FixedUpdate()
    {
        if (_lineRenderer.enabled) {
            rb.velocity += new Vector3(1/pullScaling * (crosshair.position.x - body.position.x), 1/pullScaling * (crosshair.position.y - body.position.y), 0);
        }
    }
}
