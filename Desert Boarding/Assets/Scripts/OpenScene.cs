using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public float delay;

    public void LoadNextScene(string sceneName)
    {
        StartCoroutine(OnLoadNextScene(sceneName));
    }

    public IEnumerator OnLoadNextScene(string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
