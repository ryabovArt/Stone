using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceen : MonoBehaviour
{
    public string loadLevel; // название загружаемой сцены

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player")) // при соприкосновении с игроком
            SceneManager.LoadScene(loadLevel); // загружаем сцену
    }
}
