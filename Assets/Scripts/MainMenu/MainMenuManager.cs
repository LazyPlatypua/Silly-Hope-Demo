//Класс отвечает за главное меню
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;
    [Header("Main Links")]              //Ссылки на главные объекты меню
    public SceneLoader scene_loader;    //Ссылка на загрузчик уровня
    public GameObject spread;           //Ссылка на разворот
    public GameObject spread_main;      //Ссылка на главный разворот
    public GameObject content;          //Ссылка на содержание
    public GameObject shop;             //Ссылка на магазин
    public GameObject equip;            //Ссылка на снаряжение
    public EquipSelector equipSelector;    //Ссылка на селектор снаряжения
    public GameObject settings;         //Ссылка на настройки
    public GameObject post_processing;  //Ссылка на объект пост процессинга
    public AudioSource audio_source;    //ССылка на аудиоисточник

    [Header("Pop Up")]
    public PopUpManager popUpManager;   //ссылка на поп ап

    [Header("Current Equipment")]                       //Cнаряжение рыцаря
    public TextMeshProUGUI equip_header_text;           //Заголовок "снаряжение"
    public byte current_scene;                          //Текущая сцена
    public byte current_charm_0;                        //текущий первый талисман
    public byte current_charm_1;                        //текущий второй талисман
    public byte current_charm_2;                        //текущий третий талисман
    public byte combometer_size;                        //Текущий размер комбометра
    public bool combo_split_is_available;               //Доступно ли комбо разрыва
    public bool combo_fourious_attack_is_available;     //Доступно ли комбо яростной атаки
    public bool combo_master_stun_is_available;         //Доступно ли комбо мастерское оглушение
    public bool combo_horizontal_cut_is_available;      //Доступно ли комбо горизонтального разреза
    public bool combo_shuffle_is_available;             //Доступно ли комбо перетасовки
    public bool combo_florescence_is_available;         //Доступно ли комбо расцвета
    public bool combo_sublime_dissection_is_available;  //Доступно ли комбо грандиозного рассчения

    [Header("Purchased items")]         //Приобретеные вещи
    public bool is_prolog_completed;        //Пройден ли пролог
    public bool broken_sword_is_purchased;  //Сломанный меч приобретен
    public bool falchion_is_purchased;      //Фальшион приобретен
    public bool zweihander_is_purchased;    //Двуручник приобретен
    public bool peter_sword_is_purchased;   //Меч святого Петра приобретен
    public bool januar_dagger_is_purchased; //Кинжал святого Януария приобретен
    public bool viennese_spear_is_purchased;//Венское копье приобретено
    public bool russian_sword_is_purchased; //Русский меч приобретен
    public bool chain_mail_is_purchased;            //Кольчуга приобретена
    public bool hardened_chain_mail_is_purchased;   //Урепленная кольчуга приобретена
    public bool heavy_armor_is_purchased;           //Тяжелая броня приобретена
    public bool welfare_charm_is_purchased;     //Талисман благоденствия приобретен
    public bool heretic_charm_is_purchased;     //Талисман еритика приобретен
    public bool order_charm_is_purchased;       //Талисман ордена приобретен
    public bool cross_charm_is_purchased;       //Талисман нагрудный крест приобретен
    public bool pommel_charm_is_purchased;      //Талисман навершие из слоновой кости приобретен
    public bool papa_charm_is_purchased;        //Талисман печать папы приобретен
    public bool traitor_charm_is_purchased;     //Талисман предателя приобретен

    [Header("Score and ink")]   //очки и чернила
    public InkwellsManager inkwells;
    public short best_score;    //Лучший результат
    public short black_ink;     //Количество чернил

    [Header("Settings")]        //Настройки игры
    public Language.LanguageType language_settings;  //Текущий язык
    public byte graphics_tier;                      //Уровень графики
    public float master_volume;                     //Общая громкость игры
    public float music_volume;                      //Громкость музыки
    public float sfx_volume;                        //Громкость звуковых эффектов
    public string state = "spread";                  //Текущее состояние меню
    public Slider volume_slider;                    //Слайдер громкости
    public TextMeshProUGUI settings_back_text;      //Ссылка на текст "Назад"
    public TextMeshProUGUI settings_header_text;    //Ссылка на текст заголовка настроек
    public TextMeshProUGUI graphics_tier_text;      //Ссылка на текст уровня графики
    public TextMeshProUGUI volume_text;             //Ссылка на текст "Громкость"
    public TextMeshProUGUI language_button_text;    //Ссылка на текст "Язык: "
    private string graphics_low;                    //Текст низких настроек
    private string graphics_normal;                 //Текст нормальных настроек

    [Header("Main Spread")] //Главный разворот
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI chapter_text;
    public TextMeshProUGUI continue_text;           //Ссылка на текст "Продолжить"
    public TextMeshProUGUI equipment_text;          //Ссылка на текст "Снаряжение"         
    public TextMeshProUGUI shop_text;               //Ссылка на текст "Лавка"
    public TextMeshProUGUI content_text;            //Ссылка на текст "Продолжить"
    public TextMeshProUGUI settings_text;           //Ссылка на текст "Настройки"
    public TextMeshProUGUI exit_text;               //Ссылка на текст "Выход"
    public TextMeshProUGUI equipment_back_text;     //Ссылка на текст "Назад"

    [Header("Shop")]    //Лавка
    public TextMeshProUGUI black_ink_text;      //Ссылка на текст счета на чернильнице

    [Header("Content")]    //Содержание
    public Sprite default_button;
    public Sprite selected_button;
    public GameObject prolog_button;
    public Button[] chapter_buttons;            //Ссыдка на кнопки сцен
    public TextMeshProUGUI[] chapter_prices_text;       //Ссылка на ценнки сцен
    public GameObject first_act;                //Ссылка на содержание первого акта
    public GameObject second_act;               //Ссылка на содержание второго акта
    public GameObject third_act;                //Ссылка на содержание третьего акта
    public GameObject epilogue;                 //Ссылка на содержание эпилога
    public SpriteRenderer scene_image;          //Ссылка на изображение акта
    public Sprite[] scene_preview;              //Изображения актов
    public TextMeshProUGUI select_scene_text;   //Ссылка на текст "Выбрать"
    public TextMeshProUGUI content_next_text;   //ССылка на текст "Слудющее"
    public TextMeshProUGUI prologue_text;       //Ссылка на текст "Пролог"
    public TextMeshProUGUI epilogue_text;       //Ссылка на текст "Эпилог"
    public TextMeshProUGUI titles_text;         //Ссылка на текст "Титры"
    public TextMeshProUGUI chapter_1_text;      //Ссылка на текст "Глава 1"
    public TextMeshProUGUI chapter_2_text;      //Ссылка на текст "Глава 2"
    public TextMeshProUGUI chapter_3_text;      //Ссылка на текст "Глава 3"
    public TextMeshProUGUI chapter_4_text;      //Ссылка на текст "Глава 4"
    public TextMeshProUGUI chapter_5_text;      //Ссылка на текст "Глава 5"
    public TextMeshProUGUI chapter_6_text;      //Ссылка на текст "Глава 6"
    public TextMeshProUGUI chapter_7_text;      //Ссылка на текст "Глава 7"
    public TextMeshProUGUI chapter_8_text;      //Ссылка на текст "Глава 8"
    public TextMeshProUGUI chapter_9_text;      //Ссылка на текст "Глава 9"
    public TextMeshProUGUI chapter_10_text;     //Ссылка на текст "Глава 10"
    public TextMeshProUGUI chapter_11_text;     //Ссылка на текст "Глава 11"
    //Перечисление Актов
    public enum Act
    {
        first_act,
        second_act,
        third_act,
        epilogue
    }
    //Текущий акт содержания
    public Act current_act;
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
        current_act = Act.first_act;
        ChangeState("spread");
        LoadData();

        audio_source.volume = music_volume;
        volume_slider.value = music_volume;

        switch (graphics_tier)
        {
            case 0:
                graphics_tier_text.text = "graphics: normal";
                post_processing.SetActive(true);
                break;

            case 1:
                graphics_tier_text.text = "graphics: low";
                post_processing.SetActive(false);
                break;
        }
        inkwells.InkUpdate(black_ink);
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
        music_volume = vol;
        audio_source.volume = vol;
        SaveData();
    }

    //Функция загружает сохраненные данные
    private bool LoadData()
    {
        bool return_value = true;
        GameData game_data = SaveSystem.LoadData();

        if (game_data == null)
        {
            game_data = new GameData();
            return_value = false;
        }
        else
        {
            DataHolder.language = game_data.language;
            return_value = true;
        }

        language_settings = Language.IntToLanguage(DataHolder.language);
        SetStrings(DataHolder.language);

        best_score = game_data.best_score;  //Лучший результат
        black_ink = game_data.black_ink;   //Количество чернил
        
        equipSelector.SetCurrentEquipId(EquipSelector.EquipType.Weapon, DataHolder.current_weapon);
        equipSelector.SetCurrentEquipId(EquipSelector.EquipType.Armor, DataHolder.current_armor);
        equipSelector.SetCurrentEquipId(EquipSelector.EquipType.Talisman1, DataHolder.current_charm_0);
        equipSelector.SetCurrentEquipId(EquipSelector.EquipType.Talisman2, DataHolder.current_charm_1);
        equipSelector.SetCurrentEquipId(EquipSelector.EquipType.Talisman3, DataHolder.current_charm_2);

        scenes[0].is_purchased = game_data.scene1_is_purchased;    //Первая сцена приобретена 
        scenes[0].is_completed = game_data.scene1_is_completed;    //Первая cцена пройдена один раз
        scenes[1].is_purchased = game_data.scene2_is_purchased;    //Вторая сцена приобретена 
        scenes[1].is_completed = game_data.scene2_is_completed;    //Вторая cцена пройдена один раз
        scenes[2].is_purchased = game_data.scene3_is_purchased;    //Третья сцена приобретена 
        scenes[2].is_completed = game_data.scene3_is_completed;    //Третья cцена пройдена один раз
        scenes[3].is_purchased = game_data.scene4_is_purchased;    //Четвертая сцена приобретена 
        scenes[3].is_completed = game_data.scene4_is_completed;    //Четвертая cцена пройдена один раз
        scenes[4].is_purchased = game_data.scene5_is_purchased;    //Пятая сцена приобретена 
        scenes[4].is_completed = game_data.scene5_is_completed;    //Пятая cцена пройдена один раз
        scenes[5].is_purchased = game_data.scene6_is_purchased;    //Шестая сцена приобретена 
        scenes[5].is_completed = game_data.scene6_is_completed;    //Шестая cцена пройдена один раз
        scenes[6].is_purchased = game_data.scene7_is_purchased;    //Седьмая сцена приобретена d
        scenes[6].is_completed = game_data.scene7_is_completed;    //Седьмая cцена пройдена один раз
        scenes[7].is_purchased = game_data.scene8_is_purchased;    //Восьмая сцена приобретена 
        scenes[7].is_completed = game_data.scene8_is_completed;    //Восьмая cцена пройдена один раз
        scenes[8].is_purchased = game_data.scene9_is_purchased;    //Девятая сцена приобретена 
        scenes[8].is_completed = game_data.scene9_is_completed;    //Девятая cцена пройдена один раз
        scenes[9].is_purchased = game_data.scene10_is_purchased;   //Десятая сцена приобретена 
        scenes[9].is_completed = game_data.scene10_is_completed;   //Десятая cцена пройдена один раз
        scenes[10].is_purchased = game_data.scene11_is_purchased;   //Одиннадцатая сцена приобретена 
        scenes[10].is_completed = game_data.scene11_is_completed;   //Одиннадцатая cцена пройдена один раз

        broken_sword_is_purchased = game_data.broken_sword_is_purchased;  //Сломанный меч приобретен
        falchion_is_purchased = game_data.falchion_is_purchased;      //Фальшион приобретен
        zweihander_is_purchased = game_data.zweihander_is_purchased;    //Двуручник приобретен
        peter_sword_is_purchased = game_data.peter_sword_is_purchased;   //Меч святого Петра приобретен
        januar_dagger_is_purchased = game_data.januar_dagger_is_purchased; //Кинжал святого Януария приобретен
        viennese_spear_is_purchased = game_data.viennese_spear_is_purchased;//Венское копье приобретено
        russian_sword_is_purchased = game_data.russian_sword_is_purchased; //Русский меч приобретен

        chain_mail_is_purchased = game_data.chain_mail_is_purchased;            //Кольчуга приобретена
        hardened_chain_mail_is_purchased = game_data.hardened_chain_mail_is_purchased;   //Урепленная кольчуга приобретена
        heavy_armor_is_purchased = game_data.heavy_armor_is_purchased;           //Тяжелая броня приобретена

        welfare_charm_is_purchased = game_data.welfare_charm_is_purchased;     //Талисман благоденствия приобретен
        heretic_charm_is_purchased = game_data.heretic_charm_is_purchased;     //Талисман еритика приобретен
        order_charm_is_purchased = game_data.order_charm_is_purchased;       //Талисман ордена приобретен
        cross_charm_is_purchased = game_data.cross_charm_is_purchased;       //Талисман нагрудный крест приобретен
        pommel_charm_is_purchased = game_data.pommel_charm_is_purchased;      //Талисман навершие из слоновой кости приобретен
        papa_charm_is_purchased = game_data.papa_charm_is_purchased;        //Талисман печать папы приобретен
        traitor_charm_is_purchased = game_data.traitor_charm_is_purchased;     //Талисман предателя приобретен
        
        byte size = DataHolder.combometer_size;
        if (current_scene > 2)
        {
            size = 2;
            combometer_size = size;
            combo_split_is_available = true;               //Доступно ли комбо разрыва
            combo_fourious_attack_is_available = true;     //Доступно ли комбо яростной атаки
            combo_master_stun_is_available = true;         //Доступно ли комбо мастерское оглушение
            combo_horizontal_cut_is_available = true;      //Доступно ли комбо горизонтального разреза
            combo_shuffle_is_available = true;             //Доступно ли комбо перетасовки
            combo_florescence_is_available = true;         //Доступно ли комбо расцвета
            combo_sublime_dissection_is_available = true;  //Доступно ли комбо грандиозного рассчения
        }
        else
        {
            combo_split_is_available = true;               //Доступно ли комбо разрыва
            combo_fourious_attack_is_available = true;     //Доступно ли комбо яростной атаки
            combo_master_stun_is_available = true;         //Доступно ли комбо мастерское оглушение
            combo_horizontal_cut_is_available = false;      //Доступно ли комбо горизонтального разреза
            combo_shuffle_is_available = false;             //Доступно ли комбо перетасовки
            combo_florescence_is_available = false;         //Доступно ли комбо расцвета
            combo_sublime_dissection_is_available = false;  //Доступно ли комбо грандиозного рассчения
        }
        if (current_scene > 7)
        {
            size = 3;
            combometer_size = size;
            combo_split_is_available = true;               //Доступно ли комбо разрыва
            combo_fourious_attack_is_available = true;     //Доступно ли комбо яростной атаки
            combo_master_stun_is_available = true;         //Доступно ли комбо мастерское оглушение
            combo_horizontal_cut_is_available = true;      //Доступно ли комбо горизонтального разреза
            combo_shuffle_is_available = true;             //Доступно ли комбо перетасовки
            combo_florescence_is_available = true;         //Доступно ли комбо расцвета
            combo_sublime_dissection_is_available = true;  //Доступно ли комбо грандиозного рассчения
        }

        popUpManager.gameObject.SetActive(false);
        if (DataHolder.from_level)
        {
            black_ink = DataHolder.black_ink;
            best_score = DataHolder.best_score;
            DataHolder.from_level = false;
            if(DataHolder.current_scene == 0)
            {
                is_prolog_completed = true;
            }
            else
            {
                if(!scenes[current_scene - 1].is_completed)
                {
                    popUpManager.gameObject.SetActive(true);
                    switch (current_scene)
                    {
                        case 1:
                            popUpManager.OpenPopUp(chapter_1_text.text);
                            break;

                        case 2:
                            popUpManager.OpenPopUp(chapter_2_text.text);
                            break;

                        case 3:
                            popUpManager.OpenPopUp(chapter_3_text.text, size);
                            SaveData();
                            break;

                        case 4:
                            popUpManager.OpenPopUp(chapter_4_text.text);
                            break;

                        case 5:
                            popUpManager.OpenPopUp(chapter_5_text.text);
                            break;

                        case 6:
                            popUpManager.OpenPopUp(chapter_6_text.text);
                            break;

                        case 7:
                            popUpManager.OpenPopUp(chapter_7_text.text);
                            break;

                        case 8:
                            popUpManager.OpenPopUp(chapter_8_text.text, size);
                            SaveData();
                            break;

                        case 9:
                            popUpManager.OpenPopUp(chapter_9_text.text);
                            break;

                        case 10:
                            popUpManager.OpenPopUp(chapter_10_text.text);
                            break;

                        case 11:
                            popUpManager.OpenPopUp(chapter_11_text.text);
                            break;

                        default:
                            Debug.LogError("MainMenuManager.LoadData: current scene " + current_scene + " will not show pop up text ");
                            break;
                    }
                }
                scenes[current_scene - 1].is_completed = true;
            }
            UpdateContentButtons();
        }
        
        SaveShortData();
        return return_value;
    }

    //Функция обновляет тексты меню согласно языку
    public void SetStrings(int language)
    {
        //Debug.Log("SetStrings: " + language);
        StringSettings temp = new StringSettings(language);
        continue_text.text = temp._continue ;

        equipment_text.text = temp.equipment;
        shop_text.text = temp.shop;
        content_text.text = temp.content;
        settings_text.text = temp.settings;

        equip_header_text.text = temp.equipment;
        settings_header_text.text = temp.settings;

        graphics_low = temp.graphics_low;
        graphics_normal = temp.graphics_normal;
        UpdateGraphicsText();

        volume_text.text = temp.volume;
        language_button_text.text = temp.language_;
        settings_back_text.text = temp.back;

        content_next_text.text = temp.following;
        equipment_back_text.text = temp.back;
        exit_text.text = temp.exit;

        select_scene_text.text = temp.select;
        prologue_text.text = temp.prologue; 
        epilogue_text.text = temp.epilogue;
        titles_text.text = temp.titles;
        chapter_1_text.text = temp.chapter_1;
        chapter_2_text.text = temp.chapter_2;
        chapter_3_text.text = temp.chapter_3;
        chapter_4_text.text = temp.chapter_4;
        chapter_5_text.text = temp.chapter_5;
        chapter_6_text.text = temp.chapter_6;
        chapter_7_text.text = temp.chapter_7;
        chapter_8_text.text = temp.chapter_8;
        chapter_9_text.text = temp.chapter_9;
        chapter_10_text.text = temp.chapter_10;
        chapter_11_text.text = temp.chapter_11;

        equipSelector.SetStrings(temp);

        popUpManager.UpdateStrings(temp);
        UpdateMainSpread(temp);
    }

    public void UpdateMainSpread(StringSettings temp)
    {
        switch(current_scene)
        {
            case 0:
                chapter_text.text = temp.prologue;
                break;
            case 1:
                chapter_text.text = temp.chapter_1;
                break;

            case 2:
                chapter_text.text = temp.chapter_2;
                break;

            case 3:
                chapter_text.text = temp.chapter_3;
                break;

            case 4:
                chapter_text.text = temp.chapter_4;
                break;

            case 5:
                chapter_text.text = temp.chapter_5;
                break;

            case 6:
                chapter_text.text = temp.chapter_6;
                break;

            case 7:
                chapter_text.text = temp.chapter_7;
                break;

            case 8:
                chapter_text.text = temp.chapter_8;
                break;

            case 9:
                chapter_text.text = temp.chapter_9;
                break;

            case 10:
                chapter_text.text = temp.chapter_10;
                break;

            case 11:
                chapter_text.text = temp.chapter_11;
                break;

            case 12:
                chapter_text.text = temp.epilogue;
                break;

            default:
                Debug.Log("MainMenuManager.UpdateMainSpread: Undefined scene, setting up to 1");
                goto case 1;
        }

        score_text.text = $"{temp.best_score}\n{best_score.ToString()}";
    }

    public void UpdateMainSpread()
    {
        switch (current_scene)
        {
            case 0:
                chapter_text.text = prologue_text.text;
                break;
            case 1:
                chapter_text.text = chapter_1_text.text;
                break;

            case 2:
                chapter_text.text = chapter_2_text.text;
                break;

            case 3:
                chapter_text.text = chapter_3_text.text;
                break;

            case 4:
                chapter_text.text = chapter_4_text.text;
                break;

            case 5:
                chapter_text.text = chapter_5_text.text;
                break;

            case 6:
                chapter_text.text = chapter_6_text.text;
                break;

            case 7:
                chapter_text.text = chapter_7_text.text;
                break;

            case 8:
                chapter_text.text = chapter_8_text.text;
                break;

            case 9:
                chapter_text.text = chapter_9_text.text;
                break;

            case 10:
                chapter_text.text = chapter_10_text.text;
                break;

            case 11:
                chapter_text.text = chapter_11_text.text;
                break;

            case 12:
                chapter_text.text = epilogue_text.text;
                break;

            default:
                Debug.Log("MainMenuManager.UpdateMainSpread: Undefined scene, setting up to 1");
                goto case 1;
        }
    }

    //сохраняет данные одной сессии
    public void SaveShortData()
    {
        DataHolder.current_scene = this.current_scene;
        DataHolder.current_weapon = this.equipSelector.GetCurrentEquipId(EquipSelector.EquipType.Weapon);
        DataHolder.current_armor = this.equipSelector.GetCurrentEquipId(EquipSelector.EquipType.Armor);
        DataHolder.current_charm_0 = this.equipSelector.GetCurrentEquipId(EquipSelector.EquipType.Talisman1);
        DataHolder.current_charm_1 = this.equipSelector.GetCurrentEquipId(EquipSelector.EquipType.Talisman2);
        DataHolder.current_charm_2 = this.equipSelector.GetCurrentEquipId(EquipSelector.EquipType.Talisman3);
        DataHolder.combometer_size = this.combometer_size;
        DataHolder.best_score = this.best_score;
        DataHolder.black_ink = this.black_ink;
        DataHolder.language = (byte)Language.LanguageToInt(this.language_settings);
        DataHolder.graphics_tier = this.graphics_tier;
        DataHolder.master_volume = this.master_volume;
        DataHolder.music_volume = this.music_volume;
        DataHolder.sfx_volume = this.sfx_volume;
        DataHolder.from_level = false;
    }

    //Функция сохраняет данные
    private void SaveData()
    {
        SaveShortData();
        SaveSystem.SaveData(this);
    }

    //Функция меняет текущее состояние меню
   public void ChangeState(string change_to)
    {
        state = change_to;
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
                spread_main.SetActive(true);
                shop.SetActive(false);
                equip.SetActive(false);
                equipSelector.SetActive(false);
                settings.SetActive(false);
                UpdateMainSpread();
            break;

            case "content":
                current_act = (Act) 0;
                UpdateContentAct();
                spread.SetActive(true);
                content.SetActive(true);
                spread_main.SetActive(false);
                shop.SetActive(false);
                equip.SetActive(false);
                equipSelector.SetActive(false);
                settings.SetActive(false);
            break;

            case "equip":
                spread.SetActive(true);
                content.SetActive(false);
                spread_main.SetActive(false);
                shop.SetActive(false);
                equip.SetActive(true);
                equipSelector.SetActive(false);
                settings.SetActive(false);
            break;

            case "equipSelector":
                spread.SetActive(true);
                content.SetActive(false);
                spread_main.SetActive(false);
                shop.SetActive(false);
                equip.SetActive(false);
                equipSelector.SetActive(true);
                settings.SetActive(false);
            break;

            case "shopSelector":
                spread.SetActive(true);
                content.SetActive(false);
                spread_main.SetActive(false);
                shop.SetActive(false);
                equip.SetActive(false);
                settings.SetActive(false);
            break;


            case "shop":
                spread.SetActive(true);
                content.SetActive(false);
                spread_main.SetActive(false);
                shop.SetActive(true);
                equip.SetActive(false);
                equipSelector.SetActive(false);
                settings.SetActive(false);
            break;

            case "settings":
                spread.SetActive(true);
                content.SetActive(false);
                spread_main.SetActive(false);
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
        int size = chapter_prices_text.Length;
        is_prolog_completed = true;

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
        black_ink += 300;
        inkwells.InkUpdate(black_ink);
    }

    //Обновить кнопки в содержании
    private void UpdateContentButtons()
    {
        int size = chapter_prices_text.Length;
        foreach (Button b in chapter_buttons)
        {
            b.gameObject.SetActive(false);
            b.interactable = false;
            b.gameObject.GetComponent<Image>().sprite = default_button;
        }
        if (is_prolog_completed)
        {
            if (current_scene < chapter_prices_text.Length)
            {
                if (current_scene > 0)
                {
                    prolog_button.GetComponent<Image>().sprite = default_button;
                    chapter_buttons[current_scene - 1].gameObject.GetComponent<Image>().sprite = selected_button;
                }
                else
                {
                    prolog_button.GetComponent<Image>().sprite = selected_button;
                }
            }
        }
        else
        {
            prolog_button.GetComponent<Image>().sprite = selected_button;
        }

        int t = scenes[0].price;

        if (is_prolog_completed)
        {
            chapter_prices_text[0].text = t.ToString() ;
            if (scenes[0].is_purchased)
            {
                chapter_prices_text[0].text = ""; 
            }
            chapter_buttons[0].interactable = true;
            chapter_buttons[0].gameObject.SetActive(true);
        }

        for (int i = 1; i < size; i++)
        {
            t = scenes[i].price;
            chapter_prices_text[i].text = t.ToString(); ;

            if (scenes[i - 1].is_completed)
            {
                if (scenes[i].is_purchased)
                {
                    chapter_prices_text[i].text = "";
                }
                chapter_buttons[i].interactable = true;
                chapter_buttons[i].gameObject.SetActive(true);
            }
            else
            {
                chapter_buttons[i].interactable = false;
                chapter_buttons[i].gameObject.SetActive(false);
            }

        }

        if (scenes[size - 1].is_completed)
        {
            chapter_buttons[size - 1].gameObject.SetActive(true);
        }
    }

    //Функция обновляет акт содержания
    public void UpdateContentAct()
    {
        first_act.SetActive(false);
        second_act.SetActive(false);
        third_act.SetActive(false);
        epilogue.SetActive(false);
        switch (current_act)
        {
            case Act.first_act:
                scene_image.sprite = scene_preview[0];
                first_act.SetActive(true);
                break;

            case Act.second_act:
                scene_image.sprite = scene_preview[1];
                second_act.SetActive(true);
                break;

            case Act.third_act:
                scene_image.sprite = scene_preview[2];
                third_act.SetActive(true);
                break;

            case Act.epilogue:
                scene_image.sprite = scene_preview[3];
                epilogue.SetActive(true);
                break;
        }
    }

    //Функция переключает состояние содержания на следующий акт
    public void NextContentAct()
    {
        switch (current_act)
        {
            case Act.first_act:
                current_act = Act.second_act;
                break;

            case Act.second_act:
                current_act = Act.third_act;
                break;

            case Act.third_act:
                current_act = Act.epilogue;
                break;

            case Act.epilogue:
                current_act = Act.first_act;
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
                current_scene = (byte)chapter;
            }
        }
        else
        {
            current_scene = (byte)chapter;
        }
        UpdateContentButtons();
        SaveData();
    }

    //Кнопка покупки сцены
    public bool BuyScene(int scene_number)
    {
        if (black_ink >= scenes[scene_number].price)
        {

            if (scenes[scene_number].is_purchased)
            {
                return false;
            }
            black_ink -= System.Convert.ToInt16(scenes[scene_number].price);
            scenes[scene_number].is_purchased = true;
        }
        else
        {
            return false;
        }

        black_ink_text.text = black_ink.ToString();
        inkwells.InkUpdate(black_ink);
        UpdateContentButtons();
        return true;
    }

    //Кнопка загрузки уровня
    public void ToLevel()
    {
        SaveShortData();
        scene_loader.SceneLoad("Level");   //Загрузить уровень
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
        switch (graphics_tier)
        {
            case 0:
                graphics_tier_text.text = graphics_normal;
                break;

            case 1:
                graphics_tier_text.text = graphics_low;
                break;
        }
    }

    //Кнопка изменения уровня графики
    public void ChangeGraphicsTier()
    { 
        switch (graphics_tier)
        {
            case 0:
                graphics_tier = 1;
                graphics_tier_text.text = graphics_normal;
                post_processing.SetActive(false);
                break;

            case 1:
                graphics_tier = 0;
                graphics_tier_text.text = graphics_low;
                post_processing.SetActive(true);
                break;
        }
        UpdateGraphicsText();
        SaveData();
    }

    public void ChangeLanguage()
    {
        switch (language_settings)
        {
            case Language.LanguageType.english:
                language_settings = Language.LanguageType.russian;
                break;

            case Language.LanguageType.russian:
                language_settings = Language.LanguageType.german;
                break;

            case Language.LanguageType.german:
                language_settings = Language.LanguageType.french;
                break;

            case Language.LanguageType.french:
                language_settings = Language.LanguageType.esperanto;
                break;

            case Language.LanguageType.esperanto:
                language_settings = Language.LanguageType.english;
                break;
        }
        SetStrings(Language.LanguageToInt(language_settings));
    }

    //Срабатыввает при сворачивании и разворачивании приложения
    public void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            audio_source.Pause();
        }
        else
        {
            audio_source.Play();
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
        bool temp = equipSelector.onAction();
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
