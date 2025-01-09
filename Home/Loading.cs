using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject LoadScreen;
    public Slider Loader;

    public void Loading_game(int load)
    {
        StartCoroutine(LoadProgress(load));
    }

    IEnumerator LoadProgress(int load)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(load);
        LoadScreen.SetActive(true);

        while(!operation.isDone)
        {
            Loader.value = operation.progress;
            yield return null;
        }
    }
}
