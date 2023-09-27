using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedControls : MonoBehaviour
{
    public Vector2 turnSpeed = new Vector2(1, 1);
    //public Vector2 degreeClamp = new Vector2(80, 80);

    Quaternion initialOrientation;
    Vector2 currentAngles;



    // Start is called before the first frame update
    void Start()
    {
        initialOrientation = transform.localRotation;
    }

    void Update()
    {
        Vector2 motion = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        motion = Vector2.Scale(motion, turnSpeed);
        currentAngles += motion;
        //currentAngles = Vector2.Min(currentAngles, degreeClamp);
        //currentAngles = Vector2.Max(currentAngles, -degreeClamp);

        Quaternion look = Quaternion.Euler(-currentAngles.y, currentAngles.x, 0).normalized;

        transform.localRotation = initialOrientation * look;
    }
}
