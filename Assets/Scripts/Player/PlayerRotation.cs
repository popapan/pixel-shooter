using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // controller script reference
    [SerializeField] internal Controller controller;

    // other vars
    internal Camera cam;

    void Start() {
        cam = Camera.main;
    }

    void Update() {
        Vector3 mouseVector = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle - controller.rotationOffset);
        transform.rotation = rotation;
    }
}