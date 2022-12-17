using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller: MonoBehaviour
{
    // player properties
    [Header("Player Properties")]
    [SerializeField] internal float moveSpeed = 15f;
    [SerializeField] internal float dashSpeed = 65f;
    [SerializeField] internal float dashDuration = 0.075f;
    [SerializeField] internal float dashCooldown = 0.75f;
    [SerializeField] internal float rotationOffset = 90f;
    [SerializeField] internal float trailWidth = 0.05f;
    [SerializeField] internal float trailTime = 0.5f;

    // component references
    [Header("References")]
    [SerializeField] internal PlayerInputs inputs;
    [SerializeField] internal PlayerMovement movement;
    [SerializeField] internal PlayerRotation rotation;
    [SerializeField] internal PlayerFire fire;
    [SerializeField] internal Rigidbody2D rigidBody;

    // other vars
    [SerializeField] internal GameObject trailSpawn;
}
