using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject textLevel; // надпись с названием уровня
    Vector3 textFromPosition; // перемещаем название от сюда
    Vector3 textToPosition; // перемещаем название сюда
    float step; // скорость перемещения

    Vector3 fromPosition; // перемещаем камеру от сюда
    Vector3 toPosition; // перемещаем камеру сюда
    public float time; // скорость перемещения
    public bool delay; // задержка перемещения

    public float mouseSencitivity = 10f; // чувствительность мыши
    public Transform target; // точка, вокруг которой вращается камера
    public float dstFromTarget; // расстояние от камеры до таргета
    public Vector2 pitchMinMax = new Vector2(-7, 85); // макс и мин поворот камеры относительно таргета по Х

    public float rotationSmoothTime = 0.3f; // плавность остановки камеры при вращении
    Vector3 rotationSmoothVelocity; // текущая скорость
    Vector3 currentRotation; // текущее положение камеры

    float rotationX; // поворот камеры по X
    float rotationY; // поворот камеры по Y

    private void Start()
    {
        textFromPosition = new Vector3(0f, -13f, -28f); // задаем координаты
        textToPosition = new Vector3(0f, -18f, -21f); // задаем координаты
        fromPosition = new Vector3(0f, 50f, 0f); // задаем координаты
        toPosition = new Vector3(0f, 0f, -35f); // задаем координаты
        StartCoroutine(CameraZoom()); // запускаем корутину
    }

    private void LateUpdate()
    {
        CameraStartPosition(delay);
        if(!delay)
        {
            rotationX += Input.GetAxis("Mouse X") * mouseSencitivity; // меняем положение камеры вокруг таргета при движении мышкой по Х
            rotationY -= Input.GetAxis("Mouse Y") * mouseSencitivity; // меняем положение камеры вокруг таргета при движении мышкой по Y
            rotationY = Mathf.Clamp(rotationY, pitchMinMax.x, pitchMinMax.y); // ограничение обзора камеры сверху и снизу

            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(rotationY, rotationX), ref rotationSmoothVelocity, rotationSmoothTime);
            // определяем положение камеры
            transform.eulerAngles = currentRotation; // положение камеры равно текущему положению
            transform.position = target.position - transform.forward * dstFromTarget; // расстояние от камеры до таргета
        }
    }
    /// <summary>
    /// Определяем поведение камеры при старте
    /// </summary>
    /// <returns></returns>
    IEnumerator CameraZoom()
    {
        delay = true;
        yield return new WaitForSeconds(4f);
        textLevel.SetActive(false);
        delay = false;
    }

    void CameraStartPosition(bool status)
    {
        if (!status) return;
        time += 0.3f * Time.deltaTime;
        transform.position = Vector3.Lerp(fromPosition, target.transform.position + toPosition, time); // описываем положение камеры
        var look = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, look, time); // описываем поворот камеры
        step += 3.3f * Time.deltaTime;
        textLevel.transform.localPosition = Vector3.MoveTowards(textFromPosition, textToPosition, step); // описываем положение названия уровня
    }
}
