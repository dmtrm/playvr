using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnFallen : MonoBehaviour
{
    private Vector3 initPosition;
    public float threshold;

    private void Start()
    {
        initPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.rotation = Quaternion.identity;
            transform.position = initPosition;
        } 

    }
}
