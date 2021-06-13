using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBoundaries : MonoBehaviour
{
    public GameObject leftBorder; // левая граница
    public GameObject rightBorder; // правая граница
    bool isRightDirection;  // направление движения объекта
    public float speed; // скорость

    private void Update()
    {
        if(isRightDirection) // если направление движения вправо
        {
            transform.Translate(Vector3.right * speed); // двигаем объект вправо
            if (transform.position.x > rightBorder.transform.position.x) // до правой границы
                isRightDirection = !isRightDirection; // меняем направление
        }
        else
        {
            transform.Translate(Vector3.left * speed); // двигаем объект влево
            if (transform.position.x < leftBorder.transform.position.x) // до левой границы
                isRightDirection = !isRightDirection; // меняем направление
        }
    }
}
