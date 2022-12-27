using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingCameraZoom : MonoBehaviour
{
    // component references
    [SerializeField] private Camera cam;

    // other variables
    [SerializeField] private float minimumZoomSize = 15f; // camera effect becomes choppier the lower these two values are set; looking into possible solutions
    [SerializeField] private float zoomTime = 0.075f;
    private bool isZooming;
    private float startingSize;
    private float startingTime;

    private void Start()
    {
        // subscribe to relevant events from the static instance of the game event manager
        GameEventManager.instance.onLeftShiftPressed += Zoom;
    }
    
    private void OnDestroy()
    {
        // unsubscribe to the event when the game object this script is attached to is deleted
        GameEventManager.instance.onLeftMouseButtonPressed -= Zoom;
    }

    private void Update()
    {
        if (isZooming)
        {
            if (Time.time < (startingTime + zoomTime))
            {
                Debug.Log(cam.orthographicSize);
                // linear relatioship where Y is the camera's size and X is time
                cam.orthographicSize = (((startingSize - minimumZoomSize) / zoomTime) * (Time.time - startingTime)) + minimumZoomSize;
            }
            else
            {
                cam.orthographicSize = startingSize;
                isZooming = false;
            }
        }
    }

    private void Zoom(object sender, EventArgs arguments)
    {
        isZooming = true;
        startingTime = Time.time;
        startingSize = cam.orthographicSize;
        cam.orthographicSize = minimumZoomSize;
    }
}
