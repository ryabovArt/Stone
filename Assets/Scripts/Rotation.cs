using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Rigidbody rb;
    public float rotation = 1f;

    private void FixedUpdate()
    {
        Quaternion rotationY = Quaternion.AngleAxis(rotation, Vector3.up);
        rb.rotation *= rotationY;
    }
}
