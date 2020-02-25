using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingObject : MonoBehaviour
{

    public GameObject slider;
    public GameObject toggle;
    private Collider sliderCollider;
    private Collider toggleCollider;
    private bool isMovingEnabled;
    public enum PostitionMovement { X, Y, Z };

    [SerializeField]
    public PostitionMovement movement;


    // Start is called before the first frame update
    void Start()
    {
        sliderCollider = slider.GetComponent<Collider>();
        toggleCollider = toggle.GetComponent<Collider>();
        isMovingEnabled = toggle.GetComponent<MoveCube>().enabled;

    }

    // Update is called once per frame
    void Update()
    {

        // *(parent.transform.localScale.y / transform.localScale.y)
        if (movement == PostitionMovement.X)
        {
            // Debug.Log("Scale local " + transform.localScale.x + " " + toggle.transform.localScale.x);
            if (isMovingEnabled) {
                float togglePosX = toggle.transform.localPosition.x + toggle.transform.localScale.x / 2;
                float objPosX = togglePosX - transform.localScale.x / 2;
                transform.localPosition = new Vector3(
                    objPosX,
                    transform.localPosition.y,
                    transform.localPosition.z
                );
            } else {
                transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
            }
            
        }

        if (movement == PostitionMovement.Y)
        {
            if (isMovingEnabled) {
                float togglePosY = toggle.transform.localPosition.y + toggle.transform.localScale.y / 2;
                float objPosY = togglePosY - transform.localScale.y / 2;

                transform.localPosition = new Vector3(
                    transform.localPosition.x,
                    objPosY,
                    transform.localPosition.z
                );
            } else {
                transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
            }
        }

        // TODO: test
        if (movement == PostitionMovement.Z)
        {

            if (isMovingEnabled)
            {
                float togglePosZ = toggle.transform.localPosition.z + toggle.transform.localScale.z / 2;
                float objPosZ = togglePosZ - transform.localScale.z / 2;

                transform.localPosition = new Vector3(
                    transform.localPosition.x,
                    transform.localPosition.y,
                    objPosZ
                );
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
            }
        }

    }
}
