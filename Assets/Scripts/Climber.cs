using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    public float sensitivity = 45.0f;
    private float FallSpeed = 0.0f;
    private float SimulationRate = 150f;

    public ClimbingHand leftHand;
    public ClimbingHand rightHand;
    private ClimbingHand currentHand;

    // private ClimbingHand currentHand = null;
    private CharacterController controller = null;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // reload the scene if player falls
        if (controller.isGrounded && controller.transform.position.y < 3.9f)
        {
            // if player falls teloport to the closest platform
            controller.enabled = false;
            GameObject closestEntity = Utility.GetNearestPlatform(controller.transform.position, GameObject.FindGameObjectsWithTag("Teleport"));
            controller.transform.position = closestEntity.transform.position;
            controller.enabled = true;
        }
        else
        {
            CalculateMovement();
        }
    }

    private void CalculateMovement()
    {

        bool isGripped = leftHand.isGripped || rightHand.isGripped;
        Vector3 movement = Vector3.zero;

        if (isGripped)
        {
            if (rightHand.isGripped)
            {
                currentHand = rightHand;
            }
            if (leftHand.isGripped)
            {
                currentHand = leftHand;
            }
            movement += currentHand.Delta * sensitivity;
        }

        if (movement == Vector3.zero)
        {
            movement.y += Physics.gravity.y * Time.deltaTime * SimulationRate;
        }

        if (controller.isGrounded && movement.y < 0)
        {
            movement.y = 0f;
        }

        controller.Move(movement * Time.deltaTime);
    }
}

