using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // reference to line renderer
    [SerializeField] private GameObject bulletTrail;

    private void Start()
    {
        // subscribe to relevant events from the static instance of the game event manager
        GameEventManager.instance.onLeftMouseButtonPressed += Fire;
    }

    private void OnDestroy()
    {
        // unsubscribe to the event when the game object this script is attached to is deleted
        GameEventManager.instance.onLeftMouseButtonPressed -= Fire;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameEventManager.instance.leftMouseButtonPressed();
        }
    }

    private void Fire(object sender, EventArgs arguments)
    {
        Instantiate(bulletTrail, transform.position, transform.rotation);
    }
}
