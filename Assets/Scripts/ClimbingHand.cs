using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingHand : MonoBehaviour
{
    public Climber climber = null;
    public OVRInput.Controller controller = OVRInput.Controller.None;

    public Vector3 Delta { private set; get; } = Vector3.zero;

    public bool debugMode = false;

    // private bool canGrip;
    private bool canGrip;

    [HideInInspector]
    public bool isGripped;

    private Vector3 lastPosition = Vector3.zero;

    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        // used as helper to test if collision has happened
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller) && canGrip) {
            isGripped = true;
            if (debugMode) {
                meshRenderer.enabled = false;
            }
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller)) {
            isGripped = false;
            if (debugMode) {
                meshRenderer.enabled = true;
            }
        }
    }

    private void FixedUpdate()
    {

        lastPosition = transform.position;
    }

    private void LateUpdate()
    {
        Delta = lastPosition - transform.position;
    }

    private void GrabPoint()
    {
        if (canGrip) {
            if (debugMode) {
                meshRenderer.enabled = false;
            }
        }

    }
    
    public void ReleasePoint()
    {
        if (debugMode) {
            meshRenderer.enabled = true;
        } 
        canGrip = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ClimbPoint"))
        {
            canGrip = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ClimbPoint"))
        {
            canGrip = false;
        }

    }

}
