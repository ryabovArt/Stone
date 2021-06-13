using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddCrystal : MonoBehaviour
{
    public int crystalCount; // сколько пирамид
    public TextMeshProUGUI textCrystal; // ссылка на текстовое поле с собраными пирамидами

    void Start()
    {
        crystalCount = 0; // при старте кол-во пирамид = 0
        textCrystal.SetText(crystalCount.ToString()); // отображаем кол-во собранных пирамид
    }
}
