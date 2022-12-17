using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // controller script reference
    [SerializeField] internal Controller controller;

    [SerializeField] internal GameObject line;

    void Update()
    {
        if (controller.inputs.hasShot)
        {
            Instantiate(line, controller.trailSpawn.transform.position, transform.rotation);
            controller.inputs.hasShot = false;
        }
    }
}
