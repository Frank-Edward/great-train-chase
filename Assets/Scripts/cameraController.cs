using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform characterTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (characterTransform.position.x <= -815) {
            cameraTransform.position = new Vector3(-815, characterTransform.position.y, cameraTransform.position.z);
        }
        cameraTransform.position = new Vector3(characterTransform.position.x, characterTransform.position.y, cameraTransform.position.z);
    }
}
