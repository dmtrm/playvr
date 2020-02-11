using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterPlayer : MonoBehaviour
{
    // public GameObject player;
    public OVRInput.Controller controller = OVRInput.Controller.Active;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, controller))
        {
            OVRManager.display.RecenterPose();
        }
    }
}
