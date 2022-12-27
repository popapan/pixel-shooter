using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // component references
    [SerializeField] private Camera cam;

    // other variables
    [SerializeField] private float rotationOffset;

    private void Update()
    {
        Vector3 mouseVector = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - rotationOffset);
    }
}
