using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPRotation : MonoBehaviour
{
    public Rigidbody rb; // переменная для Rigidbody объекта
    public float rotation = 1f; // градус вращения
    
    void FixedUpdate()
    {
        Quaternion rotationY = Quaternion.AngleAxis(rotation, Vector3.up); // поворачиваем объект на 1 градус по оси Y каждый FixedUpdate
        Quaternion rotationX = Quaternion.AngleAxis(rotation, Vector3.right); // поворачиваем объект на 1 градус по оси X каждый FixedUpdate
        Quaternion rotationZ = Quaternion.AngleAxis(rotation, Vector3.right); // поворачиваем объект на 1 градус по оси Z каждый FixedUpdate

        rb.rotation *= rotationY; // увеличиваем угол поворота по Y на 1 градус
        rb.rotation *= rotationX; // увеличиваем угол поворота по X на 1 градус
        rb.rotation *= rotationZ; // увеличиваем угол поворота по Z на 1 градус
    }
}
