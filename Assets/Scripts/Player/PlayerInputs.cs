using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    // controller script reference
    [SerializeField] internal Controller controller;

    // other vars
    internal Vector2 direction;
    internal bool isDashing;
    internal bool hasShot;
    internal float remainingDashDuration;
    internal float nextDashTime;

    void Start()
    {
        nextDashTime = 0f;
        remainingDashDuration = controller.dashDuration;
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (isDashing)
        {
            if (remainingDashDuration > 0f)
            {
                remainingDashDuration -= Time.deltaTime;
            }
            else
            {
                isDashing = false;
            }
        }
        else
        {
            if (Time.time >= nextDashTime)
            {
                if (Input.GetKeyDown("left shift"))
                {
                    isDashing = true;
                    remainingDashDuration = controller.dashDuration;
                    nextDashTime = Time.time + controller.dashCooldown;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            hasShot = true;
        }
    }
}
