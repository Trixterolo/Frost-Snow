using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public float rotationSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad2))
        {
            transform.Rotate(Vector3.back * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.Keypad1))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
    }
}
