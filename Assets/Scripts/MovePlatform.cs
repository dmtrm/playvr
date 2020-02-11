using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{

    private Animator anim;
    public GameObject platform;
    public GameObject ovrPlayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = platform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnTriggerStay(Collision collision)
    {
        Debug.Log("Stay357");
        ovrPlayer.transform.SetParent(platform.transform);
    }*/ 

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Move platform " + collision.gameObject.tag);
        
        // TODO: only for cupboard
        if (collision.gameObject.tag == "MovePlatform")
        {
            // CharacterController cc = ovrPlayer.GetComponent<CharacterController>();
            // cc.enabled = false;
            // cc.transform.position = platform.transform.position;
            // cc.enabled = true;
            // ovrPlayer.transform.SetParent(platform.transform);
            anim.Play("MovePlatform");
        }
    }
}
