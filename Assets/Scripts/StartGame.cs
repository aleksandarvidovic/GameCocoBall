using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject loadingObjects;
    [SerializeField] private Slider slider;

    private void Start()
    {
        StartCoroutine(LoadASync("Main"));
    }

    IEnumerator LoadASync(string scene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
        
        loadingObjects.SetActive(true);

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }
}
