//Класс загрузки сцены
using System.Collections;   //Подключить базовые классы с#
using UnityEngine;          //Подключить классы unity
using UnityEngine.SceneManagement;  //Подключать менеджер загрузки сцен
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;         //Аниматор с анимацией перехода
    public float transition_time = 1f;  //Время перехода

    public Slider slider;
    //Функция загружает сцену по индексу
    public void SceneLoad(int scene_index)
    {
        StartCoroutine(LoadScene(scene_index));
    }

    //Функция загружает сцену по имени
    public void SceneLoad(string scene_name)
    {
        StartCoroutine(LoadScene(scene_name));
    }

    //Загрузить сцену по имен и ждать окончания работы аниматора
    IEnumerator LoadScene(string scene_name)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transition_time);

        slider.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene_name);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(progress);
            slider.value = progress;
            yield return null;
        }
    }

    //Загрузить сцену по индексу и ждать окончания работы аниматора
    IEnumerator LoadScene (int scene_index)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transition_time);

        slider.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene_index);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(progress);
            slider.value = progress;
            yield return null;
        }
    }
}
