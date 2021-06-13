using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public GameObject player; // ссылка на игрока
    AddCrystal addCrystal; // скрипт, описывающий кол-во собранных монет
    public bool isTaked; // переменная для проверки, собрана ли монета
    

    private void Start()
    {
        addCrystal = player.GetComponent<AddCrystal>(); // записываем в переменную ссылку на скрипт AddCrystal
        isTaked = false; // монета не собрана
    }
    /// <summary>
    /// Действия при соприкосновениями с коллайдерами
    /// </summary>
    /// <param name="col"> коллайдер объекта, на котором скрипт </param>
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && isTaked == false) 
        {
            isTaked = true; // монета собрана
            addCrystal.crystalCount++; // увеличиваем счетчик пирамид
            addCrystal.textCrystal.SetText(addCrystal.crystalCount.ToString()); // выводим это значение 
            Destroy(gameObject); // удаляем пирамиду
            isTaked = !isTaked; // монета не собрана
        }
    }
}
