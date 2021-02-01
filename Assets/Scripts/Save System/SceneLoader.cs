//Класс загрузки сцены
using System.Collections;   //Подключить базовые классы с#
using UnityEngine;          //Подключить классы unity
using UnityEngine.SceneManagement;  //Подключать менеджер загрузки сцен
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;         //Аниматор с анимацией перехода
    public float transitionTime = 1f;  //Время перехода

    public Slider slider;
    //Функция загружает сцену по индексу
    public void SceneLoad(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex));
    }

    //Функция загружает сцену по имени
    public void SceneLoad(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    //Загрузить сцену по имен и ждать окончания работы аниматора
    IEnumerator LoadScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        slider.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(progress);
            slider.value = progress;
            yield return null;
        }
    }

    //Загрузить сцену по индексу и ждать окончания работы аниматора
    IEnumerator LoadScene (int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        slider.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(progress);
            slider.value = progress;
            yield return null;
        }
    }
}
