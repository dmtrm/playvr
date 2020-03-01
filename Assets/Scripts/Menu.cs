using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    bool inMenu;
    public GameObject player;
    public Transform platformTeleport0;
    public Transform platformTeleport1;
    public Transform platformTeleport2;
    public Transform platformTeleport3;
    public Transform platformTeleport4;
    public Transform currentPlatform;


    // Start is called before the first frame update
    void Start()
    {
        Teleport(currentPlatform);
        DebugUIBuilder.instance.AddButton("Platform 0", Platform0Pressed);
        DebugUIBuilder.instance.AddButton("Platform 1", Platform1Pressed);
        DebugUIBuilder.instance.AddButton("Platform 2", Platform2Pressed);
        DebugUIBuilder.instance.AddButton("Platform 3", Platform3Pressed);
        DebugUIBuilder.instance.AddButton("Platform 4", Platform4Pressed);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (inMenu) DebugUIBuilder.instance.Hide();
            else DebugUIBuilder.instance.Show();
            inMenu = !inMenu;
        }
    }

    void Platform0Pressed()
    {
        Teleport(platformTeleport0);
    }

    void Platform1Pressed()
    {
        Teleport(platformTeleport1);
    }

    void Platform2Pressed()
    {
        Teleport(platformTeleport2);
    }

    void Platform3Pressed()
    {
        Teleport(platformTeleport3);
    }

    void Platform4Pressed()
    {
        Teleport(platformTeleport4);
    }

    void Teleport(Transform teleportPlatform)
    {
        CharacterController cc = player.GetComponent<CharacterController>();
        cc.enabled = false;
        cc.transform.position = teleportPlatform.position;
        cc.enabled = true;
    }
}
