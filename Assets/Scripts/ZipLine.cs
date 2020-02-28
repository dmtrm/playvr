using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipLine : MonoBehaviour
{
    private GameObject hand;
    public GameObject player;
    public OVRInput.Controller controller = OVRInput.Controller.Active;
    private Vector3 prevPos;
    public Transform endPoint;
    private bool isMoving;
    public GameObject handle;

    void Start()
    {
        if (hand)
        {
            prevPos = hand.transform.position;
        }
    }

    void Update()
    {

        float speed = 3.0f;
        float step = speed * Time.deltaTime;


        if (hand != null && (
            (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, controller) && hand.tag == "LeftHand") || 
            (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger, controller) && hand.tag == "RightHand")
        )){
            OculusDebug.Instance.Log("Hand " + hand.tag);
            isMoving = true;
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false; 
            cc.transform.position += handle.transform.position - hand.transform.position;
        }

        if (isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, step);
        }

        if (hand != null && (
            (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller) && hand.tag == "LeftHand") || 
            (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger, controller) && hand.tag == "RightHand")
        )){
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = true;
            hand = null;
        }

        if (hand)
        {
            prevPos = hand.transform.position;
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
