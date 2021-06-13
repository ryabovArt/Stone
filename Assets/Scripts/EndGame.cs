using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player")) // при соприкосновении с игроком
        {
            SceneManager.LoadScene("Level1"); // загружаем 1 уровень
        }
    }
}
