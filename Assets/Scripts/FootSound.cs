using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FootSound : MonoBehaviour
{
    public AudioSource footSound; // ссылка на аудиоисточник
    public AudioSource footScrub; // ссылка на аудиоисточник
    int sceneIndex = 0;

    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        if (sceneIndex == 2)
            footScrub.Play();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Pltf")) // если столкнулись с платформой
            footSound.Play(); // проигрываем звук
    }
}
