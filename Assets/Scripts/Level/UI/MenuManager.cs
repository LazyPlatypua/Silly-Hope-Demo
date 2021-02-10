//Класс с настройками меню паузы уровня

using System.Collections;
using System.Collections.Generic;
using Level.FightGame;
using Level.Load_and_Manager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//подключить классы TextMeshPro (улучшенное отображение текстов на экране)

namespace Level.UI
{
    public class MenuManager : MonoBehaviour
    {
        public static MenuManager instance;     //Ссылка на экземпляр меню на сцене
        
        [Header("Scene Links")] //Главные ссылки сцены
        public SceneLoader sceneLoader;        //Ссылка на загрузчик уровня
        public CameraManager cameraManager;    //Ссылка на менеджер камеры
        public PointSpawner pointSpawner;
        public RhythmManager rhythmManager;
        public Animator menuAnimator;          //Ссылка на аниматор меню
        public Animator mainLineAnimator;
        public GameManager gameManager;        //Ссылка на игровой менджер
        public GameObject lineButtons;         //Ссылка на кнопки линий
        public AttackButton[] attackButtons;              //Ссылка слайдеры

        [Header("Positions")]   //Позиции меню
        public Vector3 startPosition;  //Стартовая позиция
        public Vector3 lastPosition;   //Конечная позиция

        [Header("Header Links")]    //Ссылки заголовка
        public GameObject headerGameObject;   //Ссылка на игровой объект заголовка
        public TextMeshProUGUI headerText;     //Ссылка на тест заголовка
        private readonly List<string> header_strings = new List<string>();   //Массив текстов заголовка

        [Header("Continue Links")]  //Ссылки кнопки продолжить
        public GameObject continueButtonGameObject;  //Ссылка на игровой объект кнопки продолжить
        public TextMeshProUGUI continueButtonText;    //Ссылка на текст кнопки продолжить
        private readonly List<string> continue_strings = new List<string>(); //Массив текстов кнопки продолжить

        [Header("Restart Links")]   //Ссылки кнопки рестарт
        public GameObject restartButtonGameObject;   //Ссылка на игровой объект кнопки рестарт
        public TextMeshProUGUI restartButtonText;     //Ссылка на текст кнопки рестарт
        private readonly List<string> restart_strings = new List<string>();  //Массив текстов кнопки рестарт

        [Header("Exit Links")]  //Ссылки кнопки выход
        public GameObject exitButtonGameObject;  //Ссылка на игровой объект кнопки выход
        public TextMeshProUGUI exitButtonText;    //Ссылка на текст кнопки выход

        [Header("Score Links")] //Ссылки счета
        public GameObject scoreGameObject;        //Ссылка на игровой объект счета
        public TextMeshProUGUI scoreText;          //Ссылка на текст счета

        [Header("Ink Links")]   //Ссылки чернил
        public GameObject blackInkGameObject;    //Ссылка на игровой объект чернил
        public TextMeshProUGUI blackInkText;      //Ссылка на текст чернил

        [Header("Confirmation Links")]  //Ссылки на поле потдверждения
        public GameObject confirmationField;                   //Ссылка на поле, в котором находятся кнопки и текст
        public GameObject confirmationHeaderGameObject;      //Ссылка на заголовок поля подтверждения
        public TextMeshProUGUI confirmationHeaderText;        //Ссылка на текст заголовока поля подтверждения
        public GameObject confirmationYesButtonGameObject;  //Ссылка на кнопку "ДА" поля подтверждения
        public TextMeshProUGUI confirmationYesButtonText;    //Ссылка на текст кнопки "ДА" поля подтверждения
        public GameObject confirmationNoButtonGameObject;   //Ссылка на кнопку "НЕТ" поля подтверждения
        public TextMeshProUGUI confirmationNoButtonText;     //Ссылка на текст кнопки "НЕТ" поля подтверждения

        [Header("State")]   //Состояние меню
        public bool gameIsPaused = false;                     //Игра на паузе?
        private bool menu_is_loaded = false;                    //Меню загружено?
        //Перечисление состояния меню
        public enum State
        {
            Pause,
            Victory,
            Defeat
        }
        public State currentState = State.Pause;               //Текущее состояние меню
        private bool is_pause_on_cooldown = false;              //Меню на кулдауне?

        private void Awake()
        {
            instance = this;
        }

        //Функция срабатывает каждый фрейм
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !is_pause_on_cooldown)
            {
                if (!gameIsPaused && currentState == State.Pause)
                {
                    Pause();
                }
                else
                {
                    if(currentState == State.Pause)
                    {
                        Resume();
                    }
                }
            }

            if (menu_is_loaded && (currentState != State.Victory || currentState != State.Defeat))
            {
                UpdateMenu();
            }
        }

        public void UpdateMenu()
        {
            switch(currentState)
            {
                case State.Pause:
                    continueButtonGameObject.SetActive(true);
                    headerText.text = header_strings[0];
                    continueButtonText.text = continue_strings[0];
                    restartButtonText.text = restart_strings[0];
                    break;

                case State.Victory:
                    continueButtonGameObject.SetActive(false);
                    headerText.text = header_strings[1];
                    continueButtonText.text = continue_strings[1];
                    restartButtonText.text = restart_strings[1];
                    break;

                case State.Defeat:
                    continueButtonGameObject.SetActive(false);
                    headerText.text = header_strings[2];
                    continueButtonText.text = continue_strings[2];
                    restartButtonText.text = restart_strings[2];
                    break;
            }
        }

        //Сделать специальное меню для соответсвующей опции
        public bool SetMenu(StringSettings stringSettingsTemp)
        {
            instance = this;
            if (gameManager == null)
            {
                gameManager = GameManager.instance;
            }
            if (pointSpawner == null)
            {
                pointSpawner = PointSpawner.instance;
            }

            gameIsPaused = false;
            currentState = State.Pause;

            header_strings.Clear();
            continue_strings.Clear();
            restart_strings.Clear();

            header_strings.Add(stringSettingsTemp.pauseHeader);
            continue_strings.Add(stringSettingsTemp.@continue);
            restart_strings.Add(stringSettingsTemp.restart);

            header_strings.Add(stringSettingsTemp.victoryHeader);
            continue_strings.Add(stringSettingsTemp.@continue);
            restart_strings.Add(stringSettingsTemp.restart);

            header_strings.Add(stringSettingsTemp.deathHeader);
            continue_strings.Add(stringSettingsTemp.@continue);
            restart_strings.Add(stringSettingsTemp.restart);

            exitButtonText.text = stringSettingsTemp.exit;
            confirmationHeaderText.text = stringSettingsTemp.confirmationHeader;
            confirmationYesButtonText.text = stringSettingsTemp.confirmationYes;
            confirmationNoButtonText.text = stringSettingsTemp.confirmationNo;

            blackInkText = blackInkGameObject.GetComponent<TextMeshProUGUI>();
            scoreText = scoreGameObject.GetComponent<TextMeshProUGUI>();

            confirmationHeaderText = confirmationHeaderGameObject.GetComponent<TextMeshProUGUI>();
            confirmationYesButtonText = confirmationYesButtonGameObject.transform.Find("Yes").gameObject.GetComponent<TextMeshProUGUI>();
            confirmationNoButtonText = confirmationNoButtonGameObject.transform.Find("No").gameObject.GetComponent<TextMeshProUGUI>();

            UpdateScore();
            DeactivateMenu();
            menu_is_loaded = true;
            return true;
        }

        //Активировать меню
        public void ActivateMenu()
        {
            if (menu_is_loaded)
            {
                Debug.Log("UIManager.ActivateMenu()");
                headerGameObject.SetActive(true);
                continueButtonGameObject.SetActive(true);
                restartButtonGameObject.SetActive(true);
                exitButtonGameObject.SetActive(true);
                blackInkGameObject.SetActive(true);

                UpdateScore();
                UpdateMenu();

                gameObject.SetActive(true);
                cameraManager.ActivateTransition();
                menuAnimator.SetBool("ActivateMenu", true);
                mainLineAnimator.SetTrigger("activate");
            }
        }

        //Деактивировать меню
        public void DeactivateMenu()
        {
            if (menu_is_loaded)
            {
                Debug.Log("UIManager.DeactivateMenu()");

                UpdateMenu();
                headerGameObject.SetActive(false);
                continueButtonGameObject.SetActive(false);
                restartButtonGameObject.SetActive(false);
                exitButtonGameObject.SetActive(false);
                blackInkGameObject.SetActive(false);

                confirmationField.SetActive(false);
                confirmationHeaderGameObject.SetActive(false);
                confirmationYesButtonGameObject.SetActive(false);
                confirmationNoButtonGameObject.SetActive(false);

                cameraManager.DeactivateTransition();
                menuAnimator.SetBool("DeactivateMenu", true);
                mainLineAnimator.SetTrigger("activate");
            }
        }

        //Обновить счет и количество чернил
        private void UpdateScore()
        {
            if (menu_is_loaded)
            {
                Debug.Log("UIManager.UpdateScore()");

                scoreText.text = gameManager.score.ToString();
                blackInkText.text = gameManager.blackInk.ToString();
            }
        }

        //Поставить игру на паузу
        public void Pause()
        {
            if (menu_is_loaded)
            {
                Debug.Log("MenuManager.Pause()");
                ActivateMenu();
                Time.timeScale = 0f;

                rhythmManager.TriggerPoints(false);
                gameManager.audioSource.Pause();
                pointSpawner.audioSource.Pause();
            }

            is_pause_on_cooldown = true;
            StartCoroutine(StartCooldown());
        }

        //Возобновить игру
        private void Resume()
        {
            if (menu_is_loaded)
            {
                Debug.Log("MenuManager.Resume()");
                DeactivateMenu();

                Time.timeScale = 1f;
            }
            is_pause_on_cooldown = true;
            StartCoroutine(StartCooldown());
        }

        //Установить положение меню
        public void SetPosition()
        {
            menuAnimator.SetBool("ActivateMenu", false);
            menuAnimator.SetBool("DeactivateMenu", false);
            if(gameIsPaused)
            {
                rhythmManager.TriggerPoints(true);
                pointSpawner.audioSource.Play();
                if (pointSpawner.levelIsStarted)
                {
                    gameManager.audioSource.Play();
                }
                lineButtons.SetActive(true);
            
                gameIsPaused = false;
            }
            else
            {
                gameIsPaused = true;
                lineButtons.SetActive(false);
            }
        }

        //Активировать меню победы
        public void ActivateVictoryScreen()
        {
            currentState = State.Victory;
            Pause();
        }

        //Активировать меню поражения
        public void ActivateDefeatScreen()
        {
            currentState = State.Defeat;
            Pause();
        }

        //Кнопка "Продолжить"
        public void ContinueButton()
        {
            Resume();
        }

        //Включить подтверждение. Action - то, к какому действию привязана кнопка (рестарт, выход)
        public void ConfirmationFieldButton(string action)
        {
            Debug.Log("UImanager.ConfirmationFieldButton(" + action + ")");

            DisableButtons();

            confirmationField.SetActive(true);
            confirmationHeaderGameObject.SetActive(true);
            confirmationYesButtonGameObject.SetActive(true);
            confirmationNoButtonGameObject.SetActive(true);

            SetConfirm(action);
        }

        //Функция возвращается к предыдущему меню, отменяя подтверждение
        public void ConfirmationReturn()
        {
            Debug.Log("UImanager.ConfirmationReturn()");

            AbleButtons();

            confirmationField.SetActive(false);
            confirmationHeaderGameObject.SetActive(false);
            confirmationYesButtonGameObject.SetActive(false);
            confirmationNoButtonGameObject.SetActive(false);
        }

        //Функция отключает кнопки меню
        private void DisableButtons()
        {
            Debug.Log("UImanager.DisableButtons()");

            continueButtonGameObject.SetActive(false);
            restartButtonGameObject.SetActive(false);
            exitButtonGameObject.SetActive(false);
        }

        //Функция включает кнопки меню
        private void AbleButtons()
        {
            Debug.Log("UIManager.AbleButtons()");

            continueButtonGameObject.SetActive(true);
            restartButtonGameObject.SetActive(true);
            exitButtonGameObject.SetActive(true);
        }

        //Функция настраивает поддтверждение. action - то, что требует подтверждения
        private void SetConfirm(string action)
        {
            Debug.Log("UIManager.SetConfirm(" + action + ")");

            switch (action)
            {
                case "restart":
                    confirmationYesButtonGameObject.GetComponent<Button>().onClick.AddListener(Restart);
                    break;

                case "exit":
                    if (currentState == State.Victory)
                    {
                        SaveData();
                    }
                    confirmationYesButtonGameObject.GetComponent<Button>().onClick.AddListener(ExitLevel);
                    break;

                default:
                    Debug.LogError("UIManager.SetConfirm(" + action + "): undefined action");
                    break;
            }
        }

        //Функция загружает сцену главного меню
        private void ExitLevel()
        {
            Debug.Log("UIManager.ExitLevel()");
            Time.timeScale = 1f;
            sceneLoader.SceneLoad("MainMenu");   //Загрузить меню
        }

        //Функция перезапускает уровень
        private void Restart()
        {
            Debug.Log("UIManager.Restart()");
            Time.timeScale = 1f;
            sceneLoader.SceneLoad("Level"); //Перезагрузить уровень
        }

        //Начать кулдаун
        IEnumerator StartCooldown()
        {
            yield return new WaitForSeconds(1);
            is_pause_on_cooldown = false;
        }

        public void SaveData()
        {
            DataHolder.from_level = true;
            if (gameManager.score > DataHolder.best_score)
            {
                DataHolder.best_score = (short) gameManager.score;
            }

            DataHolder.black_ink += (short) gameManager.blackInk;
        }
    }
}
