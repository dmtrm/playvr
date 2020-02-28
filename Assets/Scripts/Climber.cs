using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    // public float gravity = 45.0f;
    public float GravityModifier = 0.379f;
    public float sensitivity = 45.0f;
    private float FallSpeed = 0.0f;
    private float SimulationRate = 300f;

    private Hand currentHand = null;
    private CharacterController controller = null;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // reload the scene if player falls
        // Debug.Log("Respawn " + controller.isGrounded + " " + controller.transform.position.y);
        if (controller.isGrounded && controller.transform.position.y < 3.9f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            CalculateMovement();
        }
    }

    private void CalculateMovement()
    {
        Vector3 movement = Vector3.zero;
        OculusDebug.Instance.Log("Move hand " + currentHand);

        if (currentHand) {
            movement += currentHand.Delta * sensitivity;
        }

        if (movement == Vector3.zero) {
            // movement.y -= gravity * Time.deltaTime;
            movement.y += Physics.gravity.y * Time.deltaTime * SimulationRate;
        }

        // Gravity
        //if (controller.isGrounded && FallSpeed <= 0)
        //    FallSpeed = ((Physics.gravity.y * (GravityModifier * 0.002f)));
        //else
        //    FallSpeed += ((Physics.gravity.y * (GravityModifier * 0.002f)) * SimulationRate * Time.deltaTime);

        // movement.y += FallSpeed * SimulationRate * Time.deltaTime;
        //movement.y += FallSpeed * SimulationRate;

        if (controller.isGrounded && movement.y < 0) {
            movement.y = 0f;
        }

        //controller.Move(movement * Time.deltaTime);
        controller.Move(movement * Time.deltaTime);
    }

    public void SetHand(Hand hand)
    {
        if (currentHand)
        {
            currentHand.ReleasePoint();
        }

        currentHand = hand;
    }

    public void Clearhand()
    {
        currentHand = null;
    }
}

