using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ActivateTriggers : MonoBehaviour
{
    public GameObject fitToParent;
    public List<GameObject> triggers;
    public TMP_Text notifyMessage;
    private bool hitted;
    private bool inside;
    Vector3 newPos;


    void FixedUpdate()
    {
        // if the cube is inside activate the triggers
        if (hitted && !inside)
        {
            transform.SetParent(fitToParent.transform);
            transform.localPosition = new Vector3(0, 0, 0);
            gameObject.layer = LayerMask.NameToLayer("Default");
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            transform.rotation = Quaternion.identity;
            foreach (GameObject trigger in triggers) {
                trigger.SendMessage("ActivateTrigger");
            }
            notifyMessage.text = "Triggers are active";
            inside = true;
        }
        transform.localScale = transform.localScale;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == fitToParent && !hitted)
        {
            hitted = true;
        }
    }
}
