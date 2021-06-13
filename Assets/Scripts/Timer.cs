using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float timerStart; // стартовое время
    int timeInSec; // время в сек
    int minutes; // всего мин
    int seconds; // всего сек
    public TextMeshProUGUI timerText; // ссылка на текст

    void Update()
    {
        timerStart += Time.deltaTime; // начинаем отсчет времени
        
        minutes = (int)timerStart / 60; // находим минуты
        seconds = (int)timerStart - minutes * 60; // находим секунды
        timerText.text = minutes.ToString("D2") + "." + seconds.ToString("D2"); // выводим
    }
}
