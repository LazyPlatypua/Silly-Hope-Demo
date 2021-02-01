//Класс отвечает за главное меню
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;
    [Header("Main Links")]              //Ссылки на главные объекты меню
    public SceneLoader sceneLoader;    //Ссылка на загрузчик уровня
    public GameObject spread;           //Ссылка на разворот
    public GameObject spreadMain;      //Ссылка на главный разворот
    public GameObject content;          //Ссылка на содержание
    public GameObject shop;             //Ссылка на магазин
    public GameObject equip;            //Ссылка на снаряжение
    public EquipSelector equipSelector;    //Ссылка на селектор снаряжения
    public GameObject settings;         //Ссылка на настройки
    public GameObject postProcessing;  //Ссылка на объект пост процессинга
    public AudioSource audioSource;    //ССылка на аудиоисточник

    [Header("Pop Up")]
    public PopUpManager popUpManager;   //ссылка на поп ап

    [Header("Current Equipment")]                       //Cнаряжение рыцаря
    public TextMeshProUGUI equipHeaderText;           //Заголовок "снаряжение"
    public byte currentScene;                          //Текущая сцена
    public byte currentCharm0;                        //текущий первый талисман
    public byte currentCharm1;                        //текущий второй талисман
    public byte currentCharm2;                        //текущий третий талисман
    public byte combometerSize;                        //Текущий размер комбометра
    public bool comboSplitIsAvailable;               //Доступно ли комбо разрыва
    public bool comboFouriousAttackIsAvailable;     //Доступно ли комбо яростной атаки
    public bool comboMasterStunIsAvailable;         //Доступно ли комбо мастерское оглушение
    public bool comboHorizontalCutIsAvailable;      //Доступно ли комбо горизонтального разреза
    public bool comboShuffleIsAvailable;             //Доступно ли комбо перетасовки
    public bool comboFlorescenceIsAvailable;         //Доступно ли комбо расцвета
    public bool comboSublimeDissectionIsAvailable;  //Доступно ли комбо грандиозного рассчения

    [Header("Purchased items")]         //Приобретеные вещи
    public bool isPrologCompleted;        //Пройден ли пролог
    public bool brokenSwordIsPurchased;  //Сломанный меч приобретен
    public bool falchionIsPurchased;      //Фальшион приобретен
    public bool zweihanderIsPurchased;    //Двуручник приобретен
    public bool peterSwordIsPurchased;   //Меч святого Петра приобретен
    public bool januarDaggerIsPurchased; //Кинжал святого Януария приобретен
    public bool vienneseSpearIsPurchased;//Венское копье приобретено
    public bool russianSwordIsPurchased; //Русский меч приобретен
    public bool chainMailIsPurchased;            //Кольчуга приобретена
    public bool hardenedChainMailIsPurchased;   //Урепленная кольчуга приобретена
    public bool heavyArmorIsPurchased;           //Тяжелая броня приобретена
    public bool welfareCharmIsPurchased;     //Талисман благоденствия приобретен
    public bool hereticCharmIsPurchased;     //Талисман еритика приобретен
    public bool orderCharmIsPurchased;       //Талисман ордена приобретен
    public bool crossCharmIsPurchased;       //Талисман нагрудный крест приобретен
    public bool pommelCharmIsPurchased;      //Талисман навершие из слоновой кости приобретен
    public bool papaCharmIsPurchased;        //Талисман печать папы приобретен
    public bool traitorCharmIsPurchased;     //Талисман предателя приобретен

    [Header("Score and ink")]   //очки и чернила
    public InkwellsManager inkwells;
    public short bestScore;    //Лучший результат
    public short blackInk;     //Количество чернил

    [Header("Settings")]        //Настройки игры
    public Language.LanguageType languageSettings;  //Текущий язык
    public byte graphicsTier;                      //Уровень графики
    public float masterVolume;                     //Общая громкость игры
    public float musicVolume;                      //Громкость музыки
    public float sfxVolume;                        //Громкость звуковых эффектов
    public string state = "spread";                  //Текущее состояние меню
    public Slider volumeSlider;                    //Слайдер громкости
    public TextMeshProUGUI settingsBackText;      //Ссылка на текст "Назад"
    public TextMeshProUGUI settingsHeaderText;    //Ссылка на текст заголовка настроек
    public TextMeshProUGUI graphicsTierText;      //Ссылка на текст уровня графики
    public TextMeshProUGUI volumeText;             //Ссылка на текст "Громкость"
    public TextMeshProUGUI languageButtonText;    //Ссылка на текст "Язык: "
    private string graphics_low;                    //Текст низких настроек
    private string graphics_normal;                 //Текст нормальных настроек

    [Header("Main Spread")] //Главный разворот
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI chapterText;
    public TextMeshProUGUI continueText;           //Ссылка на текст "Продолжить"
    public TextMeshProUGUI equipmentText;          //Ссылка на текст "Снаряжение"         
    public TextMeshProUGUI shopText;               //Ссылка на текст "Лавка"
    public TextMeshProUGUI contentText;            //Ссылка на текст "Продолжить"
    public TextMeshProUGUI settingsText;           //Ссылка на текст "Настройки"
    public TextMeshProUGUI exitText;               //Ссылка на текст "Выход"
    public TextMeshProUGUI equipmentBackText;     //Ссылка на текст "Назад"

    [Header("Shop")]    //Лавка
    public TextMeshProUGUI blackInkText;      //Ссылка на текст счета на чернильнице

    [Header("Content")]    //Содержание
    public Sprite defaultButton;
    public Sprite selectedButton;
    public GameObject prologButton;
    public Button[] chapterButtons;            //Ссыдка на кнопки сцен
    public TextMeshProUGUI[] chapterPricesText;       //Ссылка на ценнки сцен
    public GameObject firstAct;                //Ссылка на содержание первого акта
    public GameObject secondAct;               //Ссылка на содержание второго акта
    public GameObject thirdAct;                //Ссылка на содержание третьего акта
    public GameObject epilogue;                 //Ссылка на содержание эпилога
    public SpriteRenderer sceneImage;          //Ссылка на изображение акта
    public Sprite[] scenePreview;              //Изображения актов
    public TextMeshProUGUI selectSceneText;   //Ссылка на текст "Выбрать"
    public TextMeshProUGUI contentNextText;   //ССылка на текст "Слудющее"
    public TextMeshProUGUI prologueText;       //Ссылка на текст "Пролог"
    public TextMeshProUGUI epilogueText;       //Ссылка на текст "Эпилог"
    public TextMeshProUGUI titlesText;         //Ссылка на текст "Титры"
    public TextMeshProUGUI chapter1Text;      //Ссылка на текст "Глава 1"
    public TextMeshProUGUI chapter2Text;      //Ссылка на текст "Глава 2"
    public TextMeshProUGUI chapter3Text;      //Ссылка на текст "Глава 3"
    public TextMeshProUGUI chapter4Text;      //Ссылка на текст "Глава 4"
    public TextMeshProUGUI chapter5Text;      //Ссылка на текст "Глава 5"
    public TextMeshProUGUI chapter6Text;      //Ссылка на текст "Глава 6"
    public TextMeshProUGUI chapter7Text;      //Ссылка на текст "Глава 7"
    public TextMeshProUGUI chapter8Text;      //Ссылка на текст "Глава 8"
    public TextMeshProUGUI chapter9Text;      //Ссылка на текст "Глава 9"
    public TextMeshProUGUI chapter10Text;     //Ссылка на текст "Глава 10"
    public TextMeshProUGUI chapter11Text;     //Ссылка на текст "Глава 11"
    //Перечисление Актов
    public enum Act
    {
        FirstAct,
        SecondAct,
        ThirdAct,
        Epilogue
    }
    //Текущий акт содержания
    public Act currentAct;
    //Стуктура сцен
    public struct Scene
    {
        public byte index;   //номер сцены
        public short price;   //Цена сцены
        public bool is_purchased;   //приобретена ли сцена
        public bool is_completed;   //пройдена ли сцена
        public Scene(byte index, short price, bool purchased, bool completed)
        {
            this.index = index;
            this.price = price;
            is_purchased = purchased;
            is_completed = completed;
        }
    }
    [HideInInspector]
    //список сцен
    public Scene[] scenes = new Scene[11];

    //Функция срабатывает при старте сцены
    void Awake()
    {
        instance = this;
        equipSelector.Init();

        scenes = new Scene[11]
        {
            new Scene(1, 15, false, false),
            new Scene(2, 25, false, false),
            new Scene(3, 40, false, false),
            new Scene(4, 55, false, false),
            new Scene(5, 80, false, false),
            new Scene(6, 100, false, false),
            new Scene(7, 0, false, false),
            new Scene(8, 0, false, false),
            new Scene(9, 150, false, false),
            new Scene(10, 275, false, false),
            new Scene(11, 0, false, false)
        };
        currentAct = Act.FirstAct;
        ChangeState("spread");
        LoadData();

        audioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;

        switch (graphicsTier)
        {
            case 0:
                graphicsTierText.text = "graphics: normal";
                postProcessing.SetActive(true);
                break;

            case 1:
                graphicsTierText.text = "graphics: low";
                postProcessing.SetActive(false);
                break;
        }
        inkwells.InkUpdate(blackInk);
        UpdateContentButtons();
    }

    //Функция срабатывает каждый фрейм
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            BackButton();
        }
    }
    
    //Функция устанавливает громкость
    public void SetVolume(float vol)
    {
        musicVolume = vol;
        audioSource.volume = vol;
        SaveData();
    }

    //Функция загружает сохраненные данные
    private bool LoadData()
    {
        bool returnValue = true;
        GameData gameData = SaveSystem.LoadData();

        if (gameData == null)
        {
            gameData = new GameData();
            returnValue = false;
        }
        else
        {
            DataHolder.language = gameData.language;
            returnValue = true;
        }

        languageSettings = Language.IntToLanguage(DataHolder.language);
        SetStrings(DataHolder.language);

        bestScore = gameData.bestScore;  //Лучший результат
        blackInk = gameData.blackInk;   //Количество чернил
        
        equipSelector.SetCurrentEquipId(EquipSelector.EquipType.Weapon, DataHolder.current_weapon);
        equipSelector.SetCurrentEquipId(EquipSelector.EquipType.Armor, DataHolder.current_armor);
        equipSelector.SetCurrentEquipId(EquipSelector.EquipType.Talisman1, DataHolder.current_charm_0);
        equipSelector.SetCurrentEquipId(EquipSelector.EquipType.Talisman2, DataHolder.current_charm_1);
        equipSelector.SetCurrentEquipId(EquipSelector.EquipType.Talisman3, DataHolder.current_charm_2);

        scenes[0].is_purchased = gameData.scene1IsPurchased;    //Первая сцена приобретена 
        scenes[0].is_completed = gameData.scene1IsCompleted;    //Первая cцена пройдена один раз
        scenes[1].is_purchased = gameData.scene2IsPurchased;    //Вторая сцена приобретена 
        scenes[1].is_completed = gameData.scene2IsCompleted;    //Вторая cцена пройдена один раз
        scenes[2].is_purchased = gameData.scene3IsPurchased;    //Третья сцена приобретена 
        scenes[2].is_completed = gameData.scene3IsCompleted;    //Третья cцена пройдена один раз
        scenes[3].is_purchased = gameData.scene4IsPurchased;    //Четвертая сцена приобретена 
        scenes[3].is_completed = gameData.scene4IsCompleted;    //Четвертая cцена пройдена один раз
        scenes[4].is_purchased = gameData.scene5IsPurchased;    //Пятая сцена приобретена 
        scenes[4].is_completed = gameData.scene5IsCompleted;    //Пятая cцена пройдена один раз
        scenes[5].is_purchased = gameData.scene6IsPurchased;    //Шестая сцена приобретена 
        scenes[5].is_completed = gameData.scene6IsCompleted;    //Шестая cцена пройдена один раз
        scenes[6].is_purchased = gameData.scene7IsPurchased;    //Седьмая сцена приобретена d
        scenes[6].is_completed = gameData.scene7IsCompleted;    //Седьмая cцена пройдена один раз
        scenes[7].is_purchased = gameData.scene8IsPurchased;    //Восьмая сцена приобретена 
        scenes[7].is_completed = gameData.scene8IsCompleted;    //Восьмая cцена пройдена один раз
        scenes[8].is_purchased = gameData.scene9IsPurchased;    //Девятая сцена приобретена 
        scenes[8].is_completed = gameData.scene9IsCompleted;    //Девятая cцена пройдена один раз
        scenes[9].is_purchased = gameData.scene10IsPurchased;   //Десятая сцена приобретена 
        scenes[9].is_completed = gameData.scene10IsCompleted;   //Десятая cцена пройдена один раз
        scenes[10].is_purchased = gameData.scene11IsPurchased;   //Одиннадцатая сцена приобретена 
        scenes[10].is_completed = gameData.scene11IsCompleted;   //Одиннадцатая cцена пройдена один раз

        brokenSwordIsPurchased = gameData.brokenSwordIsPurchased;  //Сломанный меч приобретен
        falchionIsPurchased = gameData.falchionIsPurchased;      //Фальшион приобретен
        zweihanderIsPurchased = gameData.zweihanderIsPurchased;    //Двуручник приобретен
        peterSwordIsPurchased = gameData.peterSwordIsPurchased;   //Меч святого Петра приобретен
        januarDaggerIsPurchased = gameData.januarDaggerIsPurchased; //Кинжал святого Януария приобретен
        vienneseSpearIsPurchased = gameData.vienneseSpearIsPurchased;//Венское копье приобретено
        russianSwordIsPurchased = gameData.russianSwordIsPurchased; //Русский меч приобретен

        chainMailIsPurchased = gameData.chainMailIsPurchased;            //Кольчуга приобретена
        hardenedChainMailIsPurchased = gameData.hardenedChainMailIsPurchased;   //Урепленная кольчуга приобретена
        heavyArmorIsPurchased = gameData.heavyArmorIsPurchased;           //Тяжелая броня приобретена

        welfareCharmIsPurchased = gameData.welfareCharmIsPurchased;     //Талисман благоденствия приобретен
        hereticCharmIsPurchased = gameData.hereticCharmIsPurchased;     //Талисман еритика приобретен
        orderCharmIsPurchased = gameData.orderCharmIsPurchased;       //Талисман ордена приобретен
        crossCharmIsPurchased = gameData.crossCharmIsPurchased;       //Талисман нагрудный крест приобретен
        pommelCharmIsPurchased = gameData.pommelCharmIsPurchased;      //Талисман навершие из слоновой кости приобретен
        papaCharmIsPurchased = gameData.papaCharmIsPurchased;        //Талисман печать папы приобретен
        traitorCharmIsPurchased = gameData.traitorCharmIsPurchased;     //Талисман предателя приобретен
        
        byte size = DataHolder.combometer_size;
        currentScene = DataHolder.current_scene;
        if (currentScene > 2)
        {
            size = 2;
            combometerSize = size;
            comboSplitIsAvailable = true;               //Доступно ли комбо разрыва
            comboFouriousAttackIsAvailable = true;     //Доступно ли комбо яростной атаки
            comboMasterStunIsAvailable = true;         //Доступно ли комбо мастерское оглушение
            comboHorizontalCutIsAvailable = true;      //Доступно ли комбо горизонтального разреза
            comboShuffleIsAvailable = true;             //Доступно ли комбо перетасовки
            comboFlorescenceIsAvailable = true;         //Доступно ли комбо расцвета
            comboSublimeDissectionIsAvailable = true;  //Доступно ли комбо грандиозного рассчения
        }
        else
        {
            comboSplitIsAvailable = true;               //Доступно ли комбо разрыва
            comboFouriousAttackIsAvailable = true;     //Доступно ли комбо яростной атаки
            comboMasterStunIsAvailable = true;         //Доступно ли комбо мастерское оглушение
            comboHorizontalCutIsAvailable = false;      //Доступно ли комбо горизонтального разреза
            comboShuffleIsAvailable = false;             //Доступно ли комбо перетасовки
            comboFlorescenceIsAvailable = false;         //Доступно ли комбо расцвета
            comboSublimeDissectionIsAvailable = false;  //Доступно ли комбо грандиозного рассчения
        }
        if (currentScene > 7)
        {
            size = 3;
            combometerSize = size;
            comboSplitIsAvailable = true;               //Доступно ли комбо разрыва
            comboFouriousAttackIsAvailable = true;     //Доступно ли комбо яростной атаки
            comboMasterStunIsAvailable = true;         //Доступно ли комбо мастерское оглушение
            comboHorizontalCutIsAvailable = true;      //Доступно ли комбо горизонтального разреза
            comboShuffleIsAvailable = true;             //Доступно ли комбо перетасовки
            comboFlorescenceIsAvailable = true;         //Доступно ли комбо расцвета
            comboSublimeDissectionIsAvailable = true;  //Доступно ли комбо грандиозного рассчения
        }

        popUpManager.gameObject.SetActive(false);
        if (DataHolder.from_level)
        {
            blackInk = DataHolder.black_ink;
            bestScore = DataHolder.best_score;
            DataHolder.from_level = false;
            if(currentScene == 0)
            {
                isPrologCompleted = true;
            }
            else
            {
                if(!scenes[currentScene - 1].is_completed)
                {
                    popUpManager.gameObject.SetActive(true);
                    switch (currentScene)
                    {
                        case 1:
                            popUpManager.OpenPopUp(chapter1Text.text);
                            break;

                        case 2:
                            popUpManager.OpenPopUp(chapter2Text.text);
                            break;

                        case 3:
                            popUpManager.OpenPopUp(chapter3Text.text, size);
                            SaveData();
                            break;

                        case 4:
                            popUpManager.OpenPopUp(chapter4Text.text);
                            break;

                        case 5:
                            popUpManager.OpenPopUp(chapter5Text.text);
                            break;

                        case 6:
                            popUpManager.OpenPopUp(chapter6Text.text);
                            break;

                        case 7:
                            popUpManager.OpenPopUp(chapter7Text.text);
                            break;

                        case 8:
                            popUpManager.OpenPopUp(chapter8Text.text, size);
                            SaveData();
                            break;

                        case 9:
                            popUpManager.OpenPopUp(chapter9Text.text);
                            break;

                        case 10:
                            popUpManager.OpenPopUp(chapter10Text.text);
                            break;

                        case 11:
                            popUpManager.OpenPopUp(chapter11Text.text);
                            break;

                        default:
                            Debug.LogError("MainMenuManager.LoadData: current scene " + currentScene + " will not show pop up text ");
                            break;
                    }
                }
                scenes[currentScene - 1].is_completed = true;
            }
            UpdateContentButtons();
        }
        
        SaveShortData();
        return returnValue;
    }

    //Функция обновляет тексты меню согласно языку
    public void SetStrings(int language)
    {
        //Debug.Log("SetStrings: " + language);
        StringSettings temp = new StringSettings(language);
        continueText.text = temp.@continue ;

        equipmentText.text = temp.equipment;
        shopText.text = temp.shop;
        contentText.text = temp.content;
        settingsText.text = temp.settings;

        equipHeaderText.text = temp.equipment;
        settingsHeaderText.text = temp.settings;

        graphics_low = temp.graphicsLow;
        graphics_normal = temp.graphicsNormal;
        UpdateGraphicsText();

        volumeText.text = temp.volume;
        languageButtonText.text = temp.language;
        settingsBackText.text = temp.back;

        contentNextText.text = temp.following;
        equipmentBackText.text = temp.back;
        exitText.text = temp.exit;

        selectSceneText.text = temp.select;
        prologueText.text = temp.prologue; 
        epilogueText.text = temp.epilogue;
        titlesText.text = temp.titles;
        chapter1Text.text = temp.chapter1;
        chapter2Text.text = temp.chapter2;
        chapter3Text.text = temp.chapter3;
        chapter4Text.text = temp.chapter4;
        chapter5Text.text = temp.chapter5;
        chapter6Text.text = temp.chapter6;
        chapter7Text.text = temp.chapter7;
        chapter8Text.text = temp.chapter8;
        chapter9Text.text = temp.chapter9;
        chapter10Text.text = temp.chapter10;
        chapter11Text.text = temp.chapter11;

        equipSelector.SetStrings(temp);

        popUpManager.UpdateStrings(temp);
        UpdateMainSpread(temp);
    }

    public void UpdateMainSpread(StringSettings temp)
    {
        switch(currentScene)
        {
            case 0:
                chapterText.text = temp.prologue;
                break;
            case 1:
                chapterText.text = temp.chapter1;
                break;

            case 2:
                chapterText.text = temp.chapter2;
                break;

            case 3:
                chapterText.text = temp.chapter3;
                break;

            case 4:
                chapterText.text = temp.chapter4;
                break;

            case 5:
                chapterText.text = temp.chapter5;
                break;

            case 6:
                chapterText.text = temp.chapter6;
                break;

            case 7:
                chapterText.text = temp.chapter7;
                break;

            case 8:
                chapterText.text = temp.chapter8;
                break;

            case 9:
                chapterText.text = temp.chapter9;
                break;

            case 10:
                chapterText.text = temp.chapter10;
                break;

            case 11:
                chapterText.text = temp.chapter11;
                break;

            case 12:
                chapterText.text = temp.epilogue;
                break;

            default:
                Debug.Log("MainMenuManager.UpdateMainSpread: Undefined scene, setting up to 1");
                goto case 1;
        }

        scoreText.text = $"{temp.bestScore}\n{bestScore.ToString()}";
    }

    public void UpdateMainSpread()
    {
        switch (currentScene)
        {
            case 0:
                chapterText.text = prologueText.text;
                break;
            case 1:
                chapterText.text = chapter1Text.text;
                break;

            case 2:
                chapterText.text = chapter2Text.text;
                break;

            case 3:
                chapterText.text = chapter3Text.text;
                break;

            case 4:
                chapterText.text = chapter4Text.text;
                break;

            case 5:
                chapterText.text = chapter5Text.text;
                break;

            case 6:
                chapterText.text = chapter6Text.text;
                break;

            case 7:
                chapterText.text = chapter7Text.text;
                break;

            case 8:
                chapterText.text = chapter8Text.text;
                break;

            case 9:
                chapterText.text = chapter9Text.text;
                break;

            case 10:
                chapterText.text = chapter10Text.text;
                break;

            case 11:
                chapterText.text = chapter11Text.text;
                break;

            case 12:
                chapterText.text = epilogueText.text;
                break;

            default:
                Debug.Log("MainMenuManager.UpdateMainSpread: Undefined scene, setting up to 1");
                goto case 1;
        }
    }

    //сохраняет данные одной сессии
    public void SaveShortData()
    {
        DataHolder.current_scene = this.currentScene;
        DataHolder.current_weapon = this.equipSelector.GetCurrentEquipId(EquipSelector.EquipType.Weapon);
        DataHolder.current_armor = this.equipSelector.GetCurrentEquipId(EquipSelector.EquipType.Armor);
        DataHolder.current_charm_0 = this.equipSelector.GetCurrentEquipId(EquipSelector.EquipType.Talisman1);
        DataHolder.current_charm_1 = this.equipSelector.GetCurrentEquipId(EquipSelector.EquipType.Talisman2);
        DataHolder.current_charm_2 = this.equipSelector.GetCurrentEquipId(EquipSelector.EquipType.Talisman3);
        DataHolder.combometer_size = this.combometerSize;
        DataHolder.best_score = this.bestScore;
        DataHolder.black_ink = this.blackInk;
        DataHolder.language = (byte)Language.LanguageToInt(this.languageSettings);
        DataHolder.graphics_tier = this.graphicsTier;
        DataHolder.master_volume = this.masterVolume;
        DataHolder.music_volume = this.musicVolume;
        DataHolder.sfx_volume = this.sfxVolume;
        DataHolder.from_level = false;
    }

    //Функция сохраняет данные
    private void SaveData()
    {
        SaveShortData();
        SaveSystem.SaveData(this);
    }

    //Функция меняет текущее состояние меню
   public void ChangeState(string changeTo)
    {
        state = changeTo;
        ChangeState();
    }

    //Функция меняет текущее состояние меню
    public void ChangeState()
    {
        switch (state)
        { 
            case "spread":
                spread.SetActive(true);
                content.SetActive(false);
                spreadMain.SetActive(true);
                shop.SetActive(false);
                equip.SetActive(false);
                equipSelector.SetActive(false);
                settings.SetActive(false);
                UpdateMainSpread();
            break;

            case "content":
                currentAct = (Act) 0;
                UpdateContentAct();
                spread.SetActive(true);
                content.SetActive(true);
                spreadMain.SetActive(false);
                shop.SetActive(false);
                equip.SetActive(false);
                equipSelector.SetActive(false);
                settings.SetActive(false);
            break;

            case "equip":
                spread.SetActive(true);
                content.SetActive(false);
                spreadMain.SetActive(false);
                shop.SetActive(false);
                equip.SetActive(true);
                equipSelector.SetActive(false);
                settings.SetActive(false);
            break;

            case "equipSelector":
                spread.SetActive(true);
                content.SetActive(false);
                spreadMain.SetActive(false);
                shop.SetActive(false);
                equip.SetActive(false);
                equipSelector.SetActive(true);
                settings.SetActive(false);
            break;

            case "shopSelector":
                spread.SetActive(true);
                content.SetActive(false);
                spreadMain.SetActive(false);
                shop.SetActive(false);
                equip.SetActive(false);
                settings.SetActive(false);
            break;


            case "shop":
                spread.SetActive(true);
                content.SetActive(false);
                spreadMain.SetActive(false);
                shop.SetActive(true);
                equip.SetActive(false);
                equipSelector.SetActive(false);
                settings.SetActive(false);
            break;

            case "settings":
                spread.SetActive(true);
                content.SetActive(false);
                spreadMain.SetActive(false);
                shop.SetActive(false);
                equip.SetActive(false);
                equipSelector.SetActive(false);
                settings.SetActive(true);
            break;
            
            default:
                Debug.LogError("NewGameManager.ChangeState: State is undefined");
            break;
        }
    }

    public void Addchapter()
    {
        int size = chapterPricesText.Length;
        isPrologCompleted = true;

        for (int i = 1; i < size; i++)
        {
            if(!scenes[i - 1].is_completed)
            {
                scenes[i - 1].is_completed = true;
            }
        }
        UpdateContentButtons();
    }

    public void AddInk()
    {
        blackInk += 300;
        inkwells.InkUpdate(blackInk);
    }

    //Обновить кнопки в содержании
    private void UpdateContentButtons()
    {
        int size = chapterPricesText.Length;
        foreach (Button b in chapterButtons)
        {
            b.gameObject.SetActive(false);
            b.interactable = false;
            b.gameObject.GetComponent<Image>().sprite = defaultButton;
        }
        if (isPrologCompleted)
        {
            if (currentScene < chapterPricesText.Length)
            {
                if (currentScene > 0)
                {
                    prologButton.GetComponent<Image>().sprite = defaultButton;
                    chapterButtons[currentScene - 1].gameObject.GetComponent<Image>().sprite = selectedButton;
                }
                else
                {
                    prologButton.GetComponent<Image>().sprite = selectedButton;
                }
            }
        }
        else
        {
            prologButton.GetComponent<Image>().sprite = selectedButton;
        }

        int t = scenes[0].price;

        if (isPrologCompleted)
        {
            chapterPricesText[0].text = t.ToString() ;
            if (scenes[0].is_purchased)
            {
                chapterPricesText[0].text = ""; 
            }
            chapterButtons[0].interactable = true;
            chapterButtons[0].gameObject.SetActive(true);
        }

        for (int i = 1; i < size; i++)
        {
            t = scenes[i].price;
            chapterPricesText[i].text = t.ToString(); ;

            if (scenes[i - 1].is_completed)
            {
                if (scenes[i].is_purchased)
                {
                    chapterPricesText[i].text = "";
                }
                chapterButtons[i].interactable = true;
                chapterButtons[i].gameObject.SetActive(true);
            }
            else
            {
                chapterButtons[i].interactable = false;
                chapterButtons[i].gameObject.SetActive(false);
            }

        }

        if (scenes[size - 1].is_completed)
        {
            chapterButtons[size - 1].gameObject.SetActive(true);
        }
    }

    //Функция обновляет акт содержания
    public void UpdateContentAct()
    {
        firstAct.SetActive(false);
        secondAct.SetActive(false);
        thirdAct.SetActive(false);
        epilogue.SetActive(false);
        switch (currentAct)
        {
            case Act.FirstAct:
                sceneImage.sprite = scenePreview[0];
                firstAct.SetActive(true);
                break;

            case Act.SecondAct:
                sceneImage.sprite = scenePreview[1];
                secondAct.SetActive(true);
                break;

            case Act.ThirdAct:
                sceneImage.sprite = scenePreview[2];
                thirdAct.SetActive(true);
                break;

            case Act.Epilogue:
                sceneImage.sprite = scenePreview[3];
                epilogue.SetActive(true);
                break;
        }
    }

    //Функция переключает состояние содержания на следующий акт
    public void NextContentAct()
    {
        switch (currentAct)
        {
            case Act.FirstAct:
                currentAct = Act.SecondAct;
                break;

            case Act.SecondAct:
                currentAct = Act.ThirdAct;
                break;

            case Act.ThirdAct:
                currentAct = Act.Epilogue;
                break;

            case Act.Epilogue:
                currentAct = Act.FirstAct;
                break;
        }
        UpdateContentAct();
    }

    //Функция обновляет текущую сцену (главу)
    public void SelectChapter(int chapter)
    {
        if (chapter != 0 && !scenes[chapter - 1].is_purchased)
        {
            if (BuyScene(chapter - 1))
            {
                currentScene = (byte)chapter;
            }
        }
        else
        {
            currentScene = (byte)chapter;
        }
        UpdateContentButtons();
        SaveData();
    }

    //Кнопка покупки сцены
    public bool BuyScene(int sceneNumber)
    {
        if (blackInk >= scenes[sceneNumber].price)
        {

            if (scenes[sceneNumber].is_purchased)
            {
                return false;
            }
            blackInk -= System.Convert.ToInt16(scenes[sceneNumber].price);
            scenes[sceneNumber].is_purchased = true;
        }
        else
        {
            return false;
        }

        blackInkText.text = blackInk.ToString();
        inkwells.InkUpdate(blackInk);
        UpdateContentButtons();
        return true;
    }

    //Кнопка загрузки уровня
    public void ToLevel()
    {
        SaveShortData();
        sceneLoader.SceneLoad("Level");   //Загрузить уровень
    }

    //Кнопка загрузки содержания
    public void ToContent()
    {
        ChangeState("content");
    }

    //Кнопка загрузки снаряжения
    public void ToEquipment()
    {
        ChangeState("equip");;
    }

    //Кнопка загрузки настроек
    public void ToSettings()
    {
        ChangeState("settings");
        UpdateGraphicsText();
    }

    public void UpdateGraphicsText()
    {
        switch (graphicsTier)
        {
            case 0:
                graphicsTierText.text = graphics_normal;
                break;

            case 1:
                graphicsTierText.text = graphics_low;
                break;
        }
    }

    //Кнопка изменения уровня графики
    public void ChangeGraphicsTier()
    { 
        switch (graphicsTier)
        {
            case 0:
                graphicsTier = 1;
                graphicsTierText.text = graphics_normal;
                postProcessing.SetActive(false);
                break;

            case 1:
                graphicsTier = 0;
                graphicsTierText.text = graphics_low;
                postProcessing.SetActive(true);
                break;
        }
        UpdateGraphicsText();
        SaveData();
    }

    public void ChangeLanguage()
    {
        switch (languageSettings)
        {
            case Language.LanguageType.English:
                languageSettings = Language.LanguageType.Russian;
                break;

            case Language.LanguageType.Russian:
                languageSettings = Language.LanguageType.German;
                break;

            case Language.LanguageType.German:
                languageSettings = Language.LanguageType.French;
                break;

            case Language.LanguageType.French:
                languageSettings = Language.LanguageType.Esperanto;
                break;

            case Language.LanguageType.Esperanto:
                languageSettings = Language.LanguageType.English;
                break;
        }
        SetStrings(Language.LanguageToInt(languageSettings));
    }

    //Срабатыввает при сворачивании и разворачивании приложения
    public void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }


    //Кнопка возвращает меню в предыдущее состояние
    public void BackButton()
    {
        switch (state)
        {
            case "spread":
                Exit();
                break;

            case "content":
                ChangeState("spread");
                break;

            case "equip":
                ChangeState("spread");
                break;

            case "equipWeapon":
                ChangeState("spread");
                break;

            case "equipSelector":
                ChangeState("equip");
                break;

            case "shop":
                ChangeState("spread");
                break;

            case "settings":
                ChangeState("spread");
                break;

            default:
                Debug.LogError("On Escape: undefined state:" + state);
                break;
        }
    }

    //Кнопка выхода
    public void Exit()
    {
        Debug.Log("MainMenuManger.Exit()");

        Application.Quit();
    }


    //Переход к селектору оружия
    public void ToEquipWeapon() {
        equipSelector.ChangeEquipType(EquipSelector.EquipType.Weapon);
        equipSelector.UpdateSelectorInfo();
        ChangeState("equipSelector");
    }

    public void ToEquipArmor() {
        equipSelector.ChangeEquipType(EquipSelector.EquipType.Armor);
        equipSelector.UpdateSelectorInfo();
        ChangeState("equipSelector");
    }

    public void ToEquipTalisman1() {
        equipSelector.ChangeEquipType(EquipSelector.EquipType.Talisman1);
        equipSelector.UpdateSelectorInfo();
        ChangeState("equipSelector");
    }

    public void ToEquipTalisman2() {
        equipSelector.ChangeEquipType(EquipSelector.EquipType.Talisman2);
        equipSelector.UpdateSelectorInfo();
        ChangeState("equipSelector");
    }

    public void ToEquipTalisman3() {
        equipSelector.ChangeEquipType(EquipSelector.EquipType.Talisman3);
        equipSelector.UpdateSelectorInfo();
        ChangeState("equipSelector");
    }

    public void SelectEquip() {
        bool temp = equipSelector.ONAction();
        SaveData();
        if (temp)
        {
            ChangeState("equip");
        }
    }

    public byte GetCurrentEquipId(EquipSelector.EquipType equipType) {
        return equipSelector.GetCurrentEquipId(equipType);
    }
}
