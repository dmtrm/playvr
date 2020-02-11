using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    public GameObject ovrPlayer;

    // Start is called before the first frame update
    void Start()
    {

        // ovrPlayer.transform.position = new Vector3(0.793f, 5.041f, 16.235f);
        Debug.Log("On ovrPlayer " + ovrPlayer.GetInstanceID());
        // ovrPlayer.transform.position = new Vector3(0.793f, 5.041f, 16.235f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {

        // TODO: only for cupboard
        if (collision.gameObject.tag == "Teleport") {
            CharacterController cc = ovrPlayer.GetComponent<CharacterController>();
            cc.enabled = false;
            cc.transform.position = new Vector3(0.793f, 5.041f, 16.235f);
            cc.enabled = true;
        }
    }
}
