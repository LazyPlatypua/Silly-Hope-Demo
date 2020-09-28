//Класс отвечает за отображения рогресса уровня
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    public Slider progress_bar;     //ссылка на слайдер
    
    //Обновить отображение прогресса
    public void UpdateProgressBar(float current_state)
    {
        progress_bar.value = current_state;
    }
}
