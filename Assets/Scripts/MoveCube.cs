using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{

    public enum PostitionMovement { X, Y, Z };

    [SerializeField]
    public PostitionMovement positionMovement;

    public OVRInput.Controller controller = OVRInput.Controller.Active;
    private GameObject hand;
    private GameObject parent;
    private Collider parentCollider;
    private Collider toggleCollider;
    private bool isActive; 

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        parentCollider = parent.GetComponent<Collider>();
        toggleCollider = gameObject.GetComponent<Collider>();
        Debug.Log("Move Cube ");
    }

    //void OnTriggerStay(Collider other)
    void Update()
    {

        OculusDebug.Instance.Log("Hand " + hand);
        Debug.Log("Hand1 ", hand);
        if (hand && (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, controller) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger, controller))){

            if (positionMovement == PostitionMovement.Y)
            {
                transform.position = new Vector3(
                    parent.transform.position.x,
                    Mathf.Clamp(
                        hand.transform.position.y,
                        parentCollider.bounds.min.y + toggleCollider.bounds.size.y / 2, 
                        parentCollider.bounds.max.y - toggleCollider.bounds.size.y / 2
                    ),
                    parent.transform.position.z
                );
            }

            if (positionMovement == PostitionMovement.X)
            {
                transform.position = new Vector3(
                    Mathf.Clamp(
                        hand.transform.position.x,
                        parentCollider.bounds.min.x + toggleCollider.bounds.size.x / 2,
                        parentCollider.bounds.max.x - toggleCollider.bounds.size.x / 2
                    ),
                    parent.transform.position.y,
                    parent.transform.position.z
                );
            }

            if (positionMovement == PostitionMovement.Z)
            {

                Debug.Log("Move Z " + hand.transform.position.z);
                transform.position = new Vector3(
                    parent.transform.position.x,
                    parent.transform.position.y,
                    Mathf.Clamp(
                        hand.transform.position.z,
                        parentCollider.bounds.min.z + toggleCollider.bounds.size.z / 2,
                        parentCollider.bounds.max.z - toggleCollider.bounds.size.z / 2
                    )
                );
            }
        } else {
            // OculusDebug.Instance.Log("Down object 1 " + hand.ToString() + " " + OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller));
        }

        /*if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            hand = null;
        }*/

        // OculusDebug.Instance.Log("parent " + transform.parent.gameObject.ToString());

    }

    /*void OnTriggerStay(Collider other)
    {

        OculusDebug.Instance.Log("Collide object enter " + other.gameObject);
        Debug.Log("Enter object " + other.gameObject.tag);
        if (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand")
        {
            hand = other.gameObject;
        }
    }*/

    void OnTriggerEnter(Collider other)
    {

        OculusDebug.Instance.Log("Collide object enter " + other.gameObject);
        Debug.Log("Enter object " + other.gameObject.tag);
        if (isActive && (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand"))
        {
            hand = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {

        OculusDebug.Instance.Log("Collide object exit " + other.gameObject.tag);
        Debug.Log("Exit object " + other.gameObject.tag);
        if (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand") {
            hand = null;
        }
    }

    public void ActivateTrigger()
    {
        isActive = true;
    }
}
