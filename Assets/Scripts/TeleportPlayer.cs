using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    public GameObject player;
    public Transform teleport;
    private Vector3 initPosition;
    public GameObject centerCamera;
    private OVRGrabbable ovrGrabbable;
    private CharacterController cc;

    private void Start()
    {
        initPosition = transform.position;
        ovrGrabbable = GetComponent<OVRGrabbable>();
        cc = player.GetComponent<CharacterController>();
    }



    void OnTriggerEnter(Collider other)
    {

        // TODO: only for cupboard
        if (other.gameObject == centerCamera)
        {
            cc.enabled = false;
            cc.transform.position = teleport.position;
            cc.enabled = true;
            ovrGrabbable.Release();
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            transform.position = initPosition;
        }
    }
}
