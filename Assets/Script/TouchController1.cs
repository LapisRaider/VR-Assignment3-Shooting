using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController1 : MonoBehaviour
{
    public OVRInput.Controller Controller;

    void Update()
    {
        transform.localPosition = OVRInput.GetLocalControllerPosition(Controller);
        transform.localRotation = OVRInput.GetLocalControllerRotation(Controller) * Quaternion.Euler(-90, 180, 0);
    }
}
