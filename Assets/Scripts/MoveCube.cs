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
    private Renderer renderer;
    private MaterialPropertyBlock mpb;

    private bool isActive; 

    void Start()
    {
        parent = transform.parent.gameObject;
        parentCollider = parent.GetComponent<Collider>();
        toggleCollider = gameObject.GetComponent<Collider>();

        // adding a block of material to display outline
        mpb = new MaterialPropertyBlock();
        renderer = GetComponent<Renderer>();
        mpb.SetColor("_OutlineColor", Color.white);
        renderer.SetPropertyBlock(mpb);
    }

    void Update()
    {

        // adding outline to active triggers
        if (isActive)
        {
            mpb.SetFloat("_OutlineWidth", 0.005f);
            renderer.SetPropertyBlock(mpb);
        }
        
        if (hand && (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, controller) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger, controller))){

            if (positionMovement == PostitionMovement.Y)
            {
                // cube is moved corresponding to y position of the hand
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
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (isActive && (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand"))
        {
            hand = other.gameObject;
            OculusDebug.Instance.Log("Enter");
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand") {
            hand = null;
            OculusDebug.Instance.Log("Exit");
        }
    }

    public void ActivateTrigger()
    {
        isActive = true;
    }
}
