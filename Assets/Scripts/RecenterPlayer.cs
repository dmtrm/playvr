using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecenterPlayer : MonoBehaviour
{
    public OVRInput.Controller controller = OVRInput.Controller.Active;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, controller))
        {
            OVRManager.display.RecenterPose();
        }
    }
}
