//Класс отвечает за поведение точек
using TMPro;                        //Подключить TextMeshPro
using UnityEngine;                  //Подключить классы unity
using UnityEngine.UI;               //Подключить классы интерфейса unity

public class RhythmManager : MonoBehaviour
{

    public static RhythmManager instance;               //Ссылка на этот ритм менеджер
    public GameManager game_manager;                    //Ссылка на игровой менеджер
    public Image[] button_images = new Image[4];        //Изображения кнопок
    public TextMeshProUGUI combo_text;                  //Текст комбосчетчика
    public float song_time;                             //Время композиции
    public float deactivation_time;

    public int combo_count = 0;                         //Комбосчетчик

    private void Awake()
    {
        instance = this;
    }

    //Начинает работу менежджера ритм игры
    public bool StartRhytmManager()
    {
        if (game_manager == null)
        {
            game_manager = GameManager.instance;
        }

        song_time = game_manager.audio_source.time;

        ComboToZero();
        return true;
    }

    //Включить точки
    public bool TriggerPoints(bool trigger)
    {
        PointBehaviour.is_started = trigger;
        return trigger;
    }

    //Поймать указанную точку
    public void CatchPoint(PointBehaviour point)
    {

        point.DeactivatePoint();
        AddToCombo();
        game_manager.AddScore(point.is_red_point);

    }

    public void OnMissPoint()
    {
        ComboToZero();
        game_manager.AddToEnemy();
    }

    //Активировать линию
    public void ActivateLine(int line)
    {
        RhytmEvent.instance.RhytmButtonPress(line);
    }

    //Добавить к комбосчетчику
    public void AddToCombo()
    {
        combo_count++;
        if (combo_count >=2)
        {
            combo_text.text = "x" + combo_count;
            combo_text.GetComponent<Animator>().speed = PointBehaviour.beat_tempo / 60;
        }
    }

    //Обнулить комбосчетчик
    public void ComboToZero()
    {
        combo_count = 0;
        combo_text.text = "";
    }
}
