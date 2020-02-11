using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipLine : MonoBehaviour
{
    private Animator anim;
    private GameObject hand;
    public GameObject climber;
    public OVRInput.Controller controller = OVRInput.Controller.Active;
    private Vector3 prevPos;
    public Transform endPoint;
    private bool isMoving;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (hand)
        {
            prevPos = hand.transform.position;
        }
    }

    void Update()
    {

        // Debug.Log("Active " + OVRPlugin.Controller.Active);
        // Debug.Log("GetDown " + OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller));
        // Debug.Log("GetActiveController() " + OVRInput.GetActiveController());
        // Debug.Log("Active7 " + OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller));

        float speed = 3.0f;
        float step = speed * Time.deltaTime;

        // transform.position = Vector3.MoveTowards(transform.position, endPoint.position, step);


        if (hand != null && (
            (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, controller) && hand.tag == "LeftHand") || 
            (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger, controller) && hand.tag == "RightHand")
        )){
            OculusDebug.Instance.Log("Hand " + hand.tag);
            Debug.Log("Moving hand " + hand.ToString());
            Debug.Log("Parent " + transform.ToString());
            isMoving = true;
            // transform.position = Vector3.MoveTowards(transform.position, endPoint.position, step);
            CharacterController cc = climber.GetComponent<CharacterController>();
            cc.enabled = false;
            cc.transform.position += transform.position - hand.transform.position;
            // climber.transform.SetParent(transform);
            // cc.transform.position += (prevPos - hand.transform.position);
        }

        if (isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, step);
        }

        if (hand != null && (
            (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller) && hand.tag == "LeftHand") || 
            (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger, controller) && hand.tag == "RightHand")
        )){
            CharacterController cc = climber.GetComponent<CharacterController>();
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
            // Debug.Log("Other 1 3 " + other.gameObject.tag);
            OculusDebug.Instance.Log("Collision enter");
            Debug.Log("Collision " + hand);
            hand = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "RightHand" || other.gameObject.tag == "LeftHand")
        {
            // Debug.Log("Other 1 3 " + other.gameObject.tag);
            OculusDebug.Instance.Log("Collision exit");
            Debug.Log("Collision " + hand);
            hand = null;
        }
    }

}
