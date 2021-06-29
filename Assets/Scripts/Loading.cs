using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private GameObject loadingObjects;
    [SerializeField] private Slider slider;
    
    public void Load(string scene)
    {
        StartCoroutine(LoadASync(scene));
    }

    IEnumerator LoadASync(string scene)
    {
        SoundManager.PlaySound("click");
        
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
