using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingCameraMovement : MonoBehaviour
{
    // component references
    [SerializeField] private GameObject target;
    [SerializeField] private Camera cam;

    // other variables
    [SerializeField] private float mouseLookSensitivity = 0.5f;
    Vector3 cameraOffset;

    private void Start()
    {
        cameraOffset = transform.position - target.transform.position;
    }

    private void Update()
    {
        // create a camera effect where the camera moves slightly toward the cursor's position
        Vector3 mouseVector = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mouseVector = new Vector3(mouseVector.x, mouseVector.y, 0f) * mouseLookSensitivity;
        transform.position = target.transform.position + cameraOffset + mouseVector;
    }
}
