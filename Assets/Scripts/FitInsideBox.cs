using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FitInsideBox : MonoBehaviour
{
    public GameObject fitToParent;
    public List<GameObject> triggers;
    public Text notifyMessage;
    private bool hitted;
    private bool inside;
    Vector3 newPos;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log("outside!!! " + fitToParent.GetComponent<MeshFilter>().mesh.bounds.Contains(gameObject.transform.position));
        if (hitted && !inside)
        {
            // Debug.Log("inside!!!! " + fitToParent.transform + " test " + gameObject.transform.parent);
            transform.SetParent(fitToParent.transform);
            transform.localPosition = new Vector3(0, 0, 0);
            // gameObject.GetComponent<DistanceGrabbable>().enabled = false;
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
            //newPos = fitToParent.transform.InverseTransformPoint(transform.position);
        }
    }
}
