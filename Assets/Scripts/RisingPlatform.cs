using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    Vector3 targetPoint; // таргет
    private float speed = 0.1f; // скорость

    void Start()
    {
        targetPoint = new Vector3(-31.38f, 19.99f, 375.58f); // координаты таргета
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Player")) // пока игрок на платформе
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed); // двигаем ее к таргету
        }
    }
}
