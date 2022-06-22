using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-15, 0, 0);
        if (this.transform.position.x < -2000){
            Destroy(this);
            Destroy(this.gameObject);
        }
    }
}
