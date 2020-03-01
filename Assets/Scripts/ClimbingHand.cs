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

    // private GameObject currentPoint = null;
    // private List<GameObject> contactPoints = new List<GameObject>();
    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        // used as helper to test if collision happen
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (canGrip && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller)) {
            // GrabPoint();
            isGripped = true;
            if (debugMode) {
                meshRenderer.enabled = false;
            }
        }
            

        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller)) {
            // ReleasePoint();
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
        // currentPoint = Utility.GetNearest(transform.position, contactPoints);

        //if(currentPoint)
        // if(currentPoint)
        if (canGrip) {
            // climber.SetHand(this);
            if (debugMode) {
                meshRenderer.enabled = false;
            }
        }

    }
    
    public void ReleasePoint()
    {
        // if (canGrip)
        //if(currentPoint)
        //{
        // climber.Clearhand();
        if (debugMode) {
            meshRenderer.enabled = true;
        } 
        //}

        // currentPoint = null;
        canGrip = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ClimbPoint"))
        {
            // currentPoint = other.gameObject;
            canGrip = true;
        }

        // in certain cases like going to the zipline climbing should be prevented 
        /*if (other.gameObject.CompareTag("StopClimbing"))
        {
            Debug.Log("StopClimbing");
            canGrip = false;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ClimbPoint"))
        {
            // OculusDebug.Instance.Log("Exit climb point");
            // currentPoint = null;
            canGrip = false;
        }

    }


   /*private void OnTriggerEnter(Collider other)
    {
        AddPoint(other.gameObject);
    }

    private void AddPoint(GameObject newObject)
    {
        if (newObject.CompareTag("ClimbPoint"))
            contactPoints.Add(newObject);
    }

    private void OnTriggerExit(Collider other)
    {
        RemovePoint(other.gameObject);
    }

    private void RemovePoint(GameObject newObject)
    {
        if (newObject.CompareTag("ClimbPoint"))
            contactPoints.Remove(newObject);
    }*/

}
