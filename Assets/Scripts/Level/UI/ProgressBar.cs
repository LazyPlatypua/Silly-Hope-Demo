//Класс отвечает за отображения рогресса уровня
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    public Slider progressBar;     //ссылка на слайдер
    
    //Обновить отображение прогресса
    public void UpdateProgressBar(float currentState)
    {
        progressBar.value = currentState;
    }
}
