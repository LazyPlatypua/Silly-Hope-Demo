//Класс с настройками меню паузы уровня
using System.Collections;           //Подключить базовые классы с#
using System.Collections.Generic;   //Подключить списки
using UnityEngine;                  //Подключить классы unity
using UnityEngine.UI;               //Подключить классы пользовательского интерфейса
using TMPro;                        //подключить классы TextMeshPro (улучшенное отображение текстов на экране)

public class MenuManager : MonoBehaviour
{
    [Header("Scene Links")] //Главные ссылки сцены
    public static MenuManager instance;     //Ссылка на экземпляр меню на сцене
    public SceneLoader scene_loader;        //Ссылка на загрузчик уровня
    public CameraManager camera_manager;    //Ссылка на менеджер камеры
    public PointSpawner pointSpawner;
    public RhythmManager rhythmManager;
    public Animator menu_animator;          //Ссылка на аниматор меню
    public Animator mainLineAnimator;
    public GameManager game_manager;        //Ссылка на игровой менджер
    public GameObject line_buttons;         //Ссылка на кнопки линий
    public GameObject sliders;              //Ссылка слайдеры

    [Header("Positions")]   //Позиции меню
    public Vector3 start_position;  //Стартовая позиция
    public Vector3 last_position;   //Конечная позиция

    [Header("Header Links")]    //Ссылки заголовка
    public GameObject header_game_object;   //Ссылка на игровой объект заголовка
    public TextMeshProUGUI header_text;     //Ссылка на тест заголовка
    private readonly List<string> header_strings = new List<string>();   //Массив текстов заголовка

    [Header("Continue Links")]  //Ссылки кнопки продолжить
    public GameObject continue_button_game_object;  //Ссылка на игровой объект кнопки продолжить
    public TextMeshProUGUI continue_button_text;    //Ссылка на текст кнопки продолжить
    private readonly List<string> continue_strings = new List<string>(); //Массив текстов кнопки продолжить

    [Header("Restart Links")]   //Ссылки кнопки рестарт
    public GameObject restart_button_game_object;   //Ссылка на игровой объект кнопки рестарт
    public TextMeshProUGUI restart_button_text;     //Ссылка на текст кнопки рестарт
    private readonly List<string> restart_strings = new List<string>();  //Массив текстов кнопки рестарт

    [Header("Exit Links")]  //Ссылки кнопки выход
    public GameObject exit_button_game_object;  //Ссылка на игровой объект кнопки выход
    public TextMeshProUGUI exit_button_text;    //Ссылка на текст кнопки выход

    [Header("Score Links")] //Ссылки счета
    public GameObject score_game_object;        //Ссылка на игровой объект счета
    public TextMeshProUGUI score_text;          //Ссылка на текст счета

    [Header("Ink Links")]   //Ссылки чернил
    public GameObject black_ink_game_object;    //Ссылка на игровой объект чернил
    public TextMeshProUGUI black_ink_text;      //Ссылка на текст чернил

    [Header("Confirmation Links")]  //Ссылки на поле потдверждения
    public GameObject confirmation_field;                   //Ссылка на поле, в котором находятся кнопки и текст
    public GameObject confirmation_header_game_object;      //Ссылка на заголовок поля подтверждения
    public TextMeshProUGUI confirmation_header_text;        //Ссылка на текст заголовока поля подтверждения
    public GameObject confirmation_yes_button_game_object;  //Ссылка на кнопку "ДА" поля подтверждения
    public TextMeshProUGUI confirmation_yes_button_text;    //Ссылка на текст кнопки "ДА" поля подтверждения
    public GameObject confirmation_no_button_game_object;   //Ссылка на кнопку "НЕТ" поля подтверждения
    public TextMeshProUGUI confirmation_no_button_text;     //Ссылка на текст кнопки "НЕТ" поля подтверждения

    [Header("State")]   //Состояние меню
    public bool game_is_paused = false;                     //Игра на паузе?
    private bool menu_is_loaded = false;                    //Меню загружено?
    //Перечисление состояния меню
    public enum State
    {
        pause,
        victory,
        defeat
    }
    public State current_state = State.pause;               //Текущее состояние меню
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
            if (!game_is_paused && current_state == State.pause)
            {
                Pause();
            }
            else
            {
                if(current_state == State.pause)
                {
                    Resume();
                }
            }
        }

        if (menu_is_loaded && (current_state != State.victory || current_state != State.defeat))
        {
            UpdateMenu();
        }
    }

    public void UpdateMenu()
    {
        switch(current_state)
        {
            case State.pause:
                continue_button_game_object.SetActive(true);
                header_text.text = header_strings[0];
                continue_button_text.text = continue_strings[0];
                restart_button_text.text = restart_strings[0];
                break;

            case State.victory:
                continue_button_game_object.SetActive(false);
                header_text.text = header_strings[1];
                continue_button_text.text = continue_strings[1];
                restart_button_text.text = restart_strings[1];
                break;

            case State.defeat:
                continue_button_game_object.SetActive(false);
                header_text.text = header_strings[2];
                continue_button_text.text = continue_strings[2];
                restart_button_text.text = restart_strings[2];
                break;
        }
    }

    //Сделать специальное меню для соответсвующей опции
    public bool SetMenu(StringSettings string_settings_temp)
    {
        instance = this;
        if (game_manager == null)
        {
            game_manager = GameManager.instance;
        }
        if (pointSpawner == null)
        {
            pointSpawner = PointSpawner.instance;
        }

        game_is_paused = false;
        current_state = State.pause;

        header_strings.Clear();
        continue_strings.Clear();
        restart_strings.Clear();

        header_strings.Add(string_settings_temp.pause_header);
        continue_strings.Add(string_settings_temp._continue);
        restart_strings.Add(string_settings_temp.restart);

        header_strings.Add(string_settings_temp.victory_header);
        continue_strings.Add(string_settings_temp._continue);
        restart_strings.Add(string_settings_temp.restart);

        header_strings.Add(string_settings_temp.death_header);
        continue_strings.Add(string_settings_temp._continue);
        restart_strings.Add(string_settings_temp.restart);

        exit_button_text.text = string_settings_temp.exit;
        confirmation_header_text.text = string_settings_temp.confirmation_header;
        confirmation_yes_button_text.text = string_settings_temp.confirmation_yes;
        confirmation_no_button_text.text = string_settings_temp.confirmation_no;

        black_ink_text = black_ink_game_object.GetComponent<TextMeshProUGUI>();
        score_text = score_game_object.GetComponent<TextMeshProUGUI>();

        confirmation_header_text = confirmation_header_game_object.GetComponent<TextMeshProUGUI>();
        confirmation_yes_button_text = confirmation_yes_button_game_object.transform.Find("Yes").gameObject.GetComponent<TextMeshProUGUI>();
        confirmation_no_button_text = confirmation_no_button_game_object.transform.Find("No").gameObject.GetComponent<TextMeshProUGUI>();

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
            header_game_object.SetActive(true);
            continue_button_game_object.SetActive(true);
            restart_button_game_object.SetActive(true);
            exit_button_game_object.SetActive(true);
            black_ink_game_object.SetActive(true);

            UpdateScore();
            UpdateMenu();

            gameObject.SetActive(true);
            camera_manager.ActivateTransition();
            menu_animator.SetBool("ActivateMenu", true);
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
            header_game_object.SetActive(false);
            continue_button_game_object.SetActive(false);
            restart_button_game_object.SetActive(false);
            exit_button_game_object.SetActive(false);
            black_ink_game_object.SetActive(false);

            confirmation_field.SetActive(false);
            confirmation_header_game_object.SetActive(false);
            confirmation_yes_button_game_object.SetActive(false);
            confirmation_no_button_game_object.SetActive(false);

            camera_manager.DeactivateTransition();
            menu_animator.SetBool("DeactivateMenu", true);
            mainLineAnimator.SetTrigger("activate");
        }
    }

    //Обновить счет и количество чернил
    private void UpdateScore()
    {
        if (menu_is_loaded)
        {
            Debug.Log("UIManager.UpdateScore()");

            score_text.text = game_manager.score.ToString();
            black_ink_text.text = game_manager.black_ink.ToString();
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
            game_manager.audio_source.Pause();
            pointSpawner._audioSource.Pause();
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
        menu_animator.SetBool("ActivateMenu", false);
        menu_animator.SetBool("DeactivateMenu", false);
        if(game_is_paused)
        {
           rhythmManager.TriggerPoints(true);
            pointSpawner._audioSource.Play();
            if (pointSpawner.levelIsStarted)
            {
                game_manager.audio_source.Play();
            }
            line_buttons.SetActive(true);
            sliders.SetActive(true);
            game_is_paused = false;
        }
        else
        {
            game_is_paused = true;
            line_buttons.SetActive(false);
            sliders.SetActive(false);
        }
    }

    //Активировать меню победы
    public void ActivateVictoryScreen()
    {
        current_state = State.victory;
        Pause();
    }

    //Активировать меню поражения
    public void ActivateDefeatScreen()
    {
        current_state = State.defeat;
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

        confirmation_field.SetActive(true);
        confirmation_header_game_object.SetActive(true);
        confirmation_yes_button_game_object.SetActive(true);
        confirmation_no_button_game_object.SetActive(true);

        SetConfirm(action);
    }

    //Функция возвращается к предыдущему меню, отменяя подтверждение
    public void ConfirmationReturn()
    {
        Debug.Log("UImanager.ConfirmationReturn()");

        AbleButtons();

        confirmation_field.SetActive(false);
        confirmation_header_game_object.SetActive(false);
        confirmation_yes_button_game_object.SetActive(false);
        confirmation_no_button_game_object.SetActive(false);
    }

    //Функция отключает кнопки меню
    private void DisableButtons()
    {
        Debug.Log("UImanager.DisableButtons()");

        continue_button_game_object.SetActive(false);
        restart_button_game_object.SetActive(false);
        exit_button_game_object.SetActive(false);
    }

    //Функция включает кнопки меню
    private void AbleButtons()
    {
        Debug.Log("UIManager.AbleButtons()");

        continue_button_game_object.SetActive(true);
        restart_button_game_object.SetActive(true);
        exit_button_game_object.SetActive(true);
    }

    //Функция настраивает поддтверждение. action - то, что требует подтверждения
    private void SetConfirm(string action)
    {
        Debug.Log("UIManager.SetConfirm(" + action + ")");

        switch (action)
        {
            case "restart":
                confirmation_yes_button_game_object.GetComponent<Button>().onClick.AddListener(Restart);
                break;

            case "exit":
                if (current_state == State.victory)
                {
                    SaveData();
                }
                confirmation_yes_button_game_object.GetComponent<Button>().onClick.AddListener(ExitLevel);
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
        scene_loader.SceneLoad("MainMenu");   //Загрузить меню
    }

    //Функция перезапускает уровень
    private void Restart()
    {
        Debug.Log("UIManager.Restart()");
        Time.timeScale = 1f;
        scene_loader.SceneLoad("Level"); //Перезагрузить уровень
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
        if (game_manager.score > DataHolder.best_score)
        {
            DataHolder.best_score = (short) game_manager.score;
        }

        DataHolder.black_ink += (short) game_manager.black_ink;
    }
}
