using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int health; // текущее кол-во жизней
    public int numberOfLives; // общее кол-во жизней

    public Image[] lives; // максимальное кол-во жизней

    public Sprite fullLive; // полная жизнь
    public Sprite emptyLive; // пустая жизно

    void FixedUpdate()
    {
        if (health > numberOfLives)
        {
            health = numberOfLives; // больше общего кол-ва жизней, текущее кол-во жизней быть не может
        }

        for (int i = 0; i < lives.Length; i++) // изменилось ли текущее кол-во жизней
        {
            if (i < health) // если прибавилось
                lives[i].sprite = fullLive; // добавляем "полную жизнь"
            else
                lives[i].sprite = emptyLive; // если уменьшилось, то "пустую жизнь" 

            if (i < numberOfLives) // проверяем, чтобы общее кол-во жизней не превысило установленного значения
                lives[i].enabled = true;
            else
                lives[i].enabled = false;
        }
        if(health == 0) // если текущее кол-во жизней = 0
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // переходим на 1 уровень
    }
}
