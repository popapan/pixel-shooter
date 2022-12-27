using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // component references
    [SerializeField] internal PlayerData data;
    [SerializeField] private Rigidbody2D rigidBody;

    // other variables
    private float moveSpeed;
    private float dashSpeed;
    private float remainingDashDuration;
    private float nextDashTime;
    private bool isDashing;
    private Vector2 direction;
    private Vector2 dashDirection;

    private void Start()
    {
        moveSpeed = data.playerClass.moveSpeed;
        dashSpeed = data.playerClass.dashSpeed;
        nextDashTime = 0f;

        // subscribe to relevant events from the static instance of the game event manager
        GameEventManager.instance.onLeftShiftPressed += Dash;
    }

    private void OnDestroy()
    {
        // unsubscribe to the event when the game object this script is attached to is deleted
        GameEventManager.instance.onLeftShiftPressed -= Dash;
    }

    private void Update()
    {
        if (Input.GetKeyDown("left shift"))
        {
            GameEventManager.instance.leftShiftPressed();
        }
        if (isDashing)
        {
            if (remainingDashDuration > 0f)
            {
                rigidBody.AddForce(dashDirection * dashSpeed, ForceMode2D.Impulse);
                remainingDashDuration -= Time.deltaTime;
            }
            else
            {
                direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
                rigidBody.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
                isDashing = false;
            }
        }
        else
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            rigidBody.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
        }
    }

    private void Dash(object sender, EventArgs arguments)
    {
        if (Time.time >= nextDashTime)
        {
            isDashing = true;
            remainingDashDuration = 0.075f; // set these values as vars in the scriptable object; remember to not leave these hard-coded
            nextDashTime = Time.time + 0.5f;
            // dash direction constant for the whole length of the dash; player cannot change direction while dashing
            dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
    }
}
