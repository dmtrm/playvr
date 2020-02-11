using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject ovrPlayer;
    public Transform teleport;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        // TODO: only for cupboard
        if (other.gameObject.tag == "Teleport")
        {
            CharacterController cc = ovrPlayer.GetComponent<CharacterController>();
            cc.enabled = false;
            cc.transform.position = teleport.position;
            cc.enabled = true;
            Destroy(other.gameObject);
        }
    }
}
