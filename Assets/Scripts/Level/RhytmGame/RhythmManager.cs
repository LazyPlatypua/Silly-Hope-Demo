//Класс отвечает за поведение точек

using Level.Load_and_Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Подключить TextMeshPro
//Подключить классы unity

//Подключить классы интерфейса unity

namespace Level.RhytmGame
{
    public class RhythmManager : MonoBehaviour
    {

        public static RhythmManager instance;               //Ссылка на этот ритм менеджер
        public GameManager gameManager;                    //Ссылка на игровой менеджер
        public Animator[] catchLinesAnimators = new Animator[2];
        public string animatorTriggerName = "pop";
        public Image[] buttonImages = new Image[4];        //Изображения кнопок
        public TextMeshProUGUI comboText;                  //Текст комбосчетчика
        public float songTime;                             //Время композиции
        public float deactivationTime;

        public int comboCount = 0;                         //Комбосчетчик

        private void Awake()
        {
            instance = this;
        }

        //Начинает работу менежджера ритм игры
        public bool StartRhytmManager()
        {
            if (gameManager == null)
            {
                gameManager = GameManager.instance;
            }

            songTime = gameManager.audioSource.time;

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
            Debug.Log($"RhytmManager.CatchPoint({point.isRedPoint}: Point caught");
            point.DeactivatePoint();
            AddToCombo();
            gameManager.AddScore(point.isRedPoint);
        }

        public void OnMissPoint()
        {
            ComboToZero();
            gameManager.AddToEnemy();
        }

        //Активировать линию
        public void ActivateLine(int line)
        {
            RhytmEvent.instance.RhytmButtonPress(line);
            catchLinesAnimators[line].SetTrigger(animatorTriggerName);
        }

        //Добавить к комбосчетчику
        public void AddToCombo()
        {
            comboCount++;
            if (comboCount >=2)
            {
                comboText.text = "x" + comboCount;
                comboText.GetComponent<Animator>().speed = PointBehaviour.beat_tempo / 60;
            }
        }

        //Обнулить комбосчетчик
        public void ComboToZero()
        {
            comboCount = 0;
            comboText.text = "";
        }
    }
}
