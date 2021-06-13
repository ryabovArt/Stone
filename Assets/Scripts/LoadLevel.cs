using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Висел на объекте ToNextLevel
/// </summary>
public class LoadLevel : MonoBehaviour
{
    public string loadLevel;
    public GameObject loadingScreen;
    public GameObject objOffEnv;
    public GameObject objOffPlayer;
    public GameObject objOffLives;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
            Load();
    }

    public void Load()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceen());
    }

    IEnumerator LoadSceen()
    {
        objOffEnv.SetActive(false);
        objOffPlayer.SetActive(false);
        objOffLives.SetActive(false);
        yield return new WaitForSeconds(3f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadLevel);
        //while (!asyncLoad.isDone)
        //    yield return null;
    }
}
