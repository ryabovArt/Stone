using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallWall : MonoBehaviour
{
    public GameObject topBorder; // верхняя граница
    public GameObject bottomBorder; // нижняя граница
    public bool isUpperDirection; // направление движения объекта
    public float speed = 0.8f; // скорость движения объекта
    public float step; // задержка между падением стен


    private void FixedUpdate()
    {
        StartCoroutine(BehaviorWall()); // запускаем корутину
    }
    IEnumerator BehaviorWall()
    {
        yield return new WaitForSeconds(step); // определяем задержку для каждой стены
        if (isUpperDirection) // если направление движения вверх
        {
            //speed = 0.3f;
            transform.Translate(Vector3.left * speed); // двигаем объект вверх
            if (transform.position.y > topBorder.transform.position.y) // до верхней границы
                isUpperDirection = !isUpperDirection; // меняем направление
        }
        else
        {
            //speed = 1.5f;
            transform.Translate(Vector3.right * speed); // двигаем вниз
            if (transform.position.y < bottomBorder.transform.position.y) // до нижней границы
                isUpperDirection = !isUpperDirection; // меняем направление
        }
    }

}
