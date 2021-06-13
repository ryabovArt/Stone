using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// при движении игрока, держим одинаковое расстояние до объекта для большей реалистичности
public class LookAtMoon : MonoBehaviour
{
    public GameObject target; // таргет
    Vector3 offset; // расстояние от объекта до таргета

    private void Start()
    {
        offset = transform.position - target.transform.position; // определяем расстояние
    }

    private void Update()
    {
        transform.position = target.transform.position + offset; // держим его неизменным
    }
}
