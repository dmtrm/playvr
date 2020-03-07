using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipLine : MonoBehaviour
{
    private GameObject hand;
    public float speed = 3.0f;
    public GameObject player;
    public OVRInput.Controller controller = OVRInput.Controller.Active;
    public Transform endPoint;
    // handle is used for the hand offset
    public GameObject handle;
    private CharacterController cc;
    private bool isZipLineMoving = false;
    private bool isPlayerMoving = false;

    private void Awake()
    {
        cc = player.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (hand)
        {
            if ((OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, controller) && hand.tag == "LeftHand") ||
                (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger, controller) && hand.tag == "RightHand"))
            {
                isZipLineMoving = true;
                isPlayerMoving = true;
            }

            if ((OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller)) ||
                (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger, controller)))
            {
                isPlayerMoving = false;
            }
        }
    }


    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;

        if (isZipLineMoving) {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, step);
        }

        if (isPlayerMoving) {
            cc.enabled = false;
            cc.transform.position += handle.transform.position - hand.transform.position;
        } else {
            cc.enabled = true;
        }

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand") {
            hand = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "RightHand" || other.gameObject.tag == "LeftHand")
        {
            hand = null;
        }
    }

}
