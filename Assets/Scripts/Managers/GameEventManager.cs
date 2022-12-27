using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    // create a globally-accessible static instance of the game event manager
    public static GameEventManager instance;

    // delete any duplicate instances of the game event manager
    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // input events
    public event EventHandler onLeftShiftPressed;
    public event EventHandler onLeftMouseButtonPressed;

    public void leftShiftPressed()
    {
        if (onLeftShiftPressed is not null)
        {
            onLeftShiftPressed(this, EventArgs.Empty);
        }
    }

    public void leftMouseButtonPressed()
    {
        if (onLeftMouseButtonPressed is not null)
        {
            onLeftMouseButtonPressed(this, EventArgs.Empty);
        }
    }
}
