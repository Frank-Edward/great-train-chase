using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroll : MonoBehaviour
{
    public float speed =1f;
    Vector3 pos;
    public Transform _transform;
    void Start()
    {
    }

    void Update()
    {
        if (_transform.position.x < -1610) {
            pos = _transform.position;
            _transform.position = new Vector3(2140, pos.y, pos.z);
        }
            
        _transform.Translate(-speed / 100, 0, 0);
        //GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
