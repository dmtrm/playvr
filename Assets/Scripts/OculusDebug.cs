using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OculusDebug : MonoBehaviour
{
    public static OculusDebug Instance;

    bool inMenu;
    Text logText;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DebugUIBuilder.instance.AddLabel("Debug Info");
        var rt = DebugUIBuilder.instance.AddLabel("Debug");
        logText = rt.GetComponent<Text>();
    }

    // Update is called once per frame
    /*void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            if (inMenu) DebugUIBuilder.instance.Hide();
            else DebugUIBuilder.instance.Show();
            inMenu = !inMenu;
        }
    }*/

    public void Log(string msg)
    {
        logText.text = msg;
    }
}
