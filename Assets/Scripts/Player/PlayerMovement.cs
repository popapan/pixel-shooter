using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // controller script referejce
    [SerializeField] internal Controller controller;

    // other vars
    internal Vector2 velocity;
    internal float speed;
    internal float speedScale;

    void Start()
    {
        speedScale = controller.rigidBody.drag;
    }

    void Update()
    {
        if (controller.inputs.isDashing)
        {
            if (controller.inputs.remainingDashDuration == controller.dashDuration)
            {
                velocity = controller.inputs.direction;
            }
            speed = controller.dashSpeed * speedScale;
        }
        else
        {
            velocity = controller.inputs.direction;
            speed = controller.moveSpeed * speedScale;
        }
        MoveBody(velocity, speed);
    }
    public void MoveBody(Vector2 playerForce, float playerSpeed)
    {
        playerForce *= playerSpeed;
        controller.rigidBody.AddForce(playerForce);
    }
}