using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootMove : MonoBehaviour
{
    public GameObject rightBorder; // верхняя граница
    public GameObject leftBorder; // нижняя граница
    bool isRightDirection; // направление движения объекта
    public float speed = 1; // скорость движения объекта
    public float step; // задержка между падением стен

    private void FixedUpdate()
    {
        StartCoroutine(BehaviorWall()); // запускаем корутину
    }
    IEnumerator BehaviorWall()
    {
        yield return new WaitForSeconds(step); // определяем задержку для каждой стены
        
        if (isRightDirection) // если направление движения вверх
        {
            //speed = 0.1f;
            transform.Translate(Vector3.left * speed); // двигаем объект вверх
            if (transform.position.x > rightBorder.transform.position.x) // до верхней границы
                isRightDirection = !isRightDirection; // меняем направление
        }
        else
        {
            //speed = 1f;
            transform.Translate(Vector3.right * speed); // двигаем вниз
            if (transform.position.x < leftBorder.transform.position.x) // до нижней границы
                isRightDirection = !isRightDirection; // меняем направление
        }
    }
}
