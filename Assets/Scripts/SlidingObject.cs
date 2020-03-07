using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingObject : MonoBehaviour
{

    public GameObject slider;
    public GameObject toggle;
    private Collider sliderCollider;
    private Collider toggleCollider;
    public enum PostitionMovement { X, Y, Z };

    [SerializeField]
    public PostitionMovement movement;

    private bool isActive;


    // Start is called before the first frame update
    void Start()
    {
        sliderCollider = slider.GetComponent<Collider>();
        toggleCollider = toggle.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (movement == PostitionMovement.X)
        {
            // mirroring position of the toggle inside the slider to the position of the current object inside the immediate parent
            float togglePosX = toggle.transform.localPosition.x + toggle.transform.localScale.x / 2;
            float objPosX = togglePosX - transform.localScale.x / 2;
            transform.localPosition = new Vector3(
                objPosX,
                transform.localPosition.y,
                transform.localPosition.z
            );
        }

        if (movement == PostitionMovement.Y)
        {
            float togglePosY = toggle.transform.localPosition.y + toggle.transform.localScale.y / 2;
            float objPosY = togglePosY - transform.localScale.y / 2;

            transform.localPosition = new Vector3(
                transform.localPosition.x,
                objPosY,
                transform.localPosition.z
            );
        }

        if (movement == PostitionMovement.Z)
        {

            float togglePosZ = toggle.transform.localPosition.z + toggle.transform.localScale.z / 2;
            float objPosZ = togglePosZ - transform.localScale.z / 2;

            transform.localPosition = new Vector3(
                transform.localPosition.x,
                transform.localPosition.y,
                objPosZ
            );
        }

    }
}