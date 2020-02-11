using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapTo : MonoBehaviour
{
    public GameObject snapToParent;
    private bool hitted;
    private bool inside;
    Vector3 newPos;


    void fitToSlider()
    {
        float fixedScale = 0.09719128f;
        transform.SetParent(snapToParent.transform, false);
        transform.localScale = new Vector3(
            fixedScale / snapToParent.transform.localScale.x,
            fixedScale / snapToParent.transform.localScale.y,
            fixedScale / snapToParent.transform.localScale.z
        );
        // gameObject.GetComponent<MoveCube>().enabled = true;
        gameObject.GetComponent<DistanceGrabbable>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float fixedScale = snapToParent.transform.localScale.x;
        // Debug.Log("hitted 1 3 5 " + hitted + " " + snapToParent.GetComponent<Collider>().bounds.Intersects(gameObject.GetComponent<Collider>().bounds));
        // Debug.Log("intersects!!!!! " + hitted + " " + snapToParent.GetComponent<Collider>().bounds.Intersects(gameObject.GetComponent<Collider>().bounds));
        // Debug.Log("Parent " + transform.parent + " Child " + snapToParent.transform);
        // Debug.Log("Parent " + transform.bounds.x + " Child " + snapToParent.transform.bounds.y);


        //if (hitted && !gameObject.GetComponent<Collider>().bounds.Intersects(snapToParent.GetComponent<Collider>().bounds))
        if(hitted && !inside)
        {
            Debug.Log("gameObject " + gameObject  +  "Parent " + snapToParent + " Go back!!!! " + hitted + " Intersects " + snapToParent.GetComponent<Collider>().bounds.Intersects(gameObject.GetComponent<Collider>().bounds));
            fitToSlider();
            transform.localPosition = new Vector3(0, 0, newPos.z);
            inside = true;
        }
        if (inside)
        {
            fitToSlider();
        }

        Debug.Log("Inside ! " + inside);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == snapToParent && !hitted)
        {
            hitted = true;
            newPos = snapToParent.transform.InverseTransformPoint(transform.position);
        }
    }

}
