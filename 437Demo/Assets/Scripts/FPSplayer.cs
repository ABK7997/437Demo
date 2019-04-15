using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSplayer : MonoBehaviour
{
    public float movementSpeedModifier;
    public float rotationSpeedModifier;
    public float diagonalSpeedInhibiter;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false; //turn of mouse cursor
    }

    // Update is called once per frame
    void Update()
    {
        bool twoWay = false;

        //Front and Back
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * movementSpeedModifier;
            twoWay = true;
        }

        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward * movementSpeedModifier;
            twoWay = true;
        }

        //Turn left/right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(new Vector3(0, 1, 0) * rotationSpeedModifier, Space.World);
            if (!twoWay) rb.velocity = transform.right * movementSpeedModifier;
            else rb.velocity += transform.right * movementSpeedModifier * diagonalSpeedInhibiter;
        }

        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(new Vector3(0, -1, 0) * rotationSpeedModifier, Space.World);
            if (!twoWay) rb.velocity = -transform.right * movementSpeedModifier;
            else rb.velocity += -transform.right * movementSpeedModifier * diagonalSpeedInhibiter;
        }

        //Jump
        if (Input.GetKey(KeyCode.Space))
        {
            //if (Math.Abs(transform.position.y) < 2) rb.velocity = transform.up * movementSpeedModifier;
        }
    }

    private Vector3 UnitVector(Vector3 original)
    {
        float length = (float)Math.Sqrt(original.x * original.x + original.y * original.y + original.z * original.z);

        Vector3 unit = original;
        unit.x /= length;
        unit.y /= length;
        unit.z /= length;

        return unit;
    }
}
