using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrailRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    private void Start()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = (new Vector3(mousePosition.x, mousePosition.y, 0f) - transform.position) * 100f;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, mousePosition);
    }
}
