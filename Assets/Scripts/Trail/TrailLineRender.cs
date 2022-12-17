using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailLineRender : MonoBehaviour
{
    [SerializeField] internal LineRenderer trail;
    internal Controller controller;
    internal Camera cam;
    internal float remainingTrailDuration;

    void Start()
    {
        controller = GameObject.FindWithTag("Player").GetComponent<Controller>();
        cam = Camera.main;
        Vector3 mouseVector = 100f * (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        Vector3 trailEndPos = new Vector3(mouseVector.x, mouseVector.y, 0);
        trail.SetPosition(0, transform.position);
        trail.SetPosition(1, trailEndPos);
        trail.startWidth = controller.trailWidth;
        trail.endWidth = controller.trailWidth;
        remainingTrailDuration = controller.trailTime;
    }

    void Update()
    {
        if (remainingTrailDuration <= 0.05f)
        {
            Destroy(gameObject);
        }
        remainingTrailDuration -= Time.deltaTime;

        trail.startWidth = controller.trailWidth * (remainingTrailDuration / controller.trailTime);
        trail.endWidth = controller.trailWidth * (remainingTrailDuration / controller.trailTime);
    }
}
