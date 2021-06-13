using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    public Rigidbody rb; // переменная для Rigidbody объекта
    Vector3 startPos; // координаты изначального положения платформы

    private void Start()
    {
        startPos = transform.position; // присваиваем эти координаты
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("LowestPoint")) // при касании "нижней точки"
        {
            rb.isKinematic = true; // включаем isKinematic
            transform.position = startPos; // возвращаем платформу в изначальное место
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player")) // при касании с игроком
        {
            StartCoroutine(Down()); // запускаем корутину
            rb.isKinematic = true; // включаем isKinematic
        }
    }

    IEnumerator Down()
    {
        yield return new WaitForSeconds(2f); // ждем 2 сек
        rb.isKinematic = false; // выключаем isKinematic
    }
}
