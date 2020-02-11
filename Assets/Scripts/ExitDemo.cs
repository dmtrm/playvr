using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDemo : MonoBehaviour
{

    public void Quit()
    {
        OculusDebug.Instance.Log("Quit");
        Application.Quit();
    }
}
