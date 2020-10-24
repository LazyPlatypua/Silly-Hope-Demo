//Класс отвечает за необходимые для переноса в следующую сцену/игровую сессию данные
using UnityEngine;

[System.Serializable]
public class GameData
{
    [Header("Current Equipment")]   //Текущее снаряжение рыцаря, катсцены и другое
    public byte current_scene;     //Текущая сцена
    public byte current_weapon;    //текущиее оружее
    public byte current_armor;     //Текущая броня
    public byte current_charm_0;   //текущий первый талисман
    public byte current_charm_1;   //текущий второй талисман
    public byte current_charm_2;   //текущий третий талисман
    public byte combometer_size;   //Текущий размер комбометра
    public bool combo_split_is_available;               //Доступно ли комбо разрыва
    public bool combo_fourious_attack_is_available;     //Доступно ли комбо яростной атаки
    public bool combo_master_stun_is_available;         //Доступно ли комбо мастерское оглушение
    public bool combo_horizontal_cut_is_available;      //Доступно ли комбо горизонтального разреза
    public bool combo_shuffle_is_available;             //Доступно ли комбо перетасовки
    public bool combo_florescence_is_available;         //Доступно ли комбо расцвета
    public bool combo_sublime_dissection_is_available;  //Доступно ли комбо грандиозного рассчения

    [Header("Purchased items")]         //Приобретеные вещи
    public bool prolog_is_completed;    //Пройден ли пролог
    public bool scene1_is_purchased;    //Первая сцена приобретена 
    public bool scene1_is_completed;    //Первая cцена пройдена один раз
    public bool scene2_is_purchased;    //Вторая сцена приобретена 
    public bool scene2_is_completed;    //Вторая cцена пройдена один раз
    public bool scene3_is_purchased;    //Третья сцена приобретена 
    public bool scene3_is_completed;    //Третья cцена пройдена один раз
    public bool scene4_is_purchased;    //Четвертая сцена приобретена 
    public bool scene4_is_completed;    //Четвертая cцена пройдена один раз
    public bool scene5_is_purchased;    //Пятая сцена приобретена 
    public bool scene5_is_completed;    //Пятая cцена пройдена один раз
    public bool scene6_is_purchased;    //Шестая сцена приобретена 
    public bool scene6_is_completed;    //Шестая cцена пройдена один раз
    public bool scene7_is_purchased;    //Седьмая сцена приобретена 
    public bool scene7_is_completed;    //Седьмая cцена пройдена один раз
    public bool scene8_is_purchased;    //Восьмая сцена приобретена 
    public bool scene8_is_completed;    //Восьмая cцена пройдена один раз
    public bool scene9_is_purchased;    //Девятая сцена приобретена 
    public bool scene9_is_completed;    //Девятая cцена пройдена один раз
    public bool scene10_is_purchased;   //Десятая сцена приобретена 
    public bool scene10_is_completed;   //Десятая cцена пройдена один раз
    public bool scene11_is_purchased;   //Одиннадцатая сцена приобретена 
    public bool scene11_is_completed;   //Одиннадцатая cцена пройдена один раз
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
    public short best_score;    //Лучший результат
    public short black_ink;     //Количество чернил

    [Header("Settings")]        //Настройки игры
    public byte language;      //Текущий язык
    public byte graphics_tier; //Уровень графики
    public float master_volume; //Общая громкость игры
    public float music_volume;  //Громкость музыки
    public float sfx_volume;    //Громкость звуковых эффектов

    public GameData()
        //Конструктор для пустого объекта. Нужен для первого запуска игры, когда игрок еще ничего не сделал
    {
        current_scene = 0;     //Текущая сцена
        current_weapon = 0;    //текущиее оружее
        current_armor = 0;     //Текущая броня
        current_charm_0 = 0;   //текущий первый талисман
        current_charm_1 = 0;   //текущий второй талисман
        current_charm_2 = 0;   //текущий третий талисман
        combometer_size = 1;   //Текущий размер комбометра
        combo_split_is_available = false;               //Доступно ли комбо разрыва
        combo_fourious_attack_is_available = false;     //Доступно ли комбо яростной атаки
        combo_master_stun_is_available = false;         //Доступно ли комбо мастерское оглушение
        combo_horizontal_cut_is_available = false;      //Доступно ли комбо горизонтального разреза
        combo_shuffle_is_available = false;             //Доступно ли комбо перетасовки
        combo_florescence_is_available = false;         //Доступно ли комбо расцвета
        combo_sublime_dissection_is_available = false;  //Доступно ли комбо грандиозного рассчения

        prolog_is_completed = false;    //Пройден ли пролог
        scene1_is_purchased = false;    //Первая сцена приобретена 
        scene1_is_completed = false;    //Первая cцена пройдена один раз
        scene2_is_purchased = false;    //Вторая сцена приобретена 
        scene2_is_completed = false;    //Вторая cцена пройдена один раз
        scene3_is_purchased = false;    //Третья сцена приобретена 
        scene3_is_completed = false;    //Третья cцена пройдена один раз
        scene4_is_purchased = false;    //Четвертая сцена приобретена 
        scene4_is_completed = false;    //Четвертая cцена пройдена один раз
        scene5_is_purchased = false;    //Пятая сцена приобретена 
        scene5_is_completed = false;    //Пятая cцена пройдена один раз
        scene6_is_purchased = false;    //Шестая сцена приобретена 
        scene6_is_completed = false;    //Шестая cцена пройдена один раз
        scene7_is_purchased = false;    //Седьмая сцена приобретена 
        scene7_is_completed = false;    //Седьмая cцена пройдена один раз
        scene8_is_purchased = false;    //Восьмая сцена приобретена 
        scene8_is_completed = false;    //Восьмая cцена пройдена один раз
        scene9_is_purchased = false;    //Девятая сцена приобретена 
        scene9_is_completed = false;    //Девятая cцена пройдена один раз
        scene10_is_purchased = false;   //Десятая сцена приобретена 
        scene10_is_completed = false;   //Десятая cцена пройдена один раз
        scene11_is_purchased = false;   //Одиннадцатая сцена приобретена 
        scene11_is_completed = false;   //Одиннадцатая cцена пройдена один раз
        broken_sword_is_purchased = false;  //Сломанный меч приобретен
        falchion_is_purchased = false;      //Фальшион приобретен
        zweihander_is_purchased = false;    //Двуручник приобретен
        peter_sword_is_purchased = false;   //Меч святого Петра приобретен
        januar_dagger_is_purchased = false; //Кинжал святого Януария приобретен
        viennese_spear_is_purchased = false;//Венское копье приобретено
        russian_sword_is_purchased = false; //Русский меч приобретен
        chain_mail_is_purchased = false;            //Кольчуга приобретена
        hardened_chain_mail_is_purchased = false;   //Урепленная кольчуга приобретена
        heavy_armor_is_purchased = false;           //Тяжелая броня приобретена
        welfare_charm_is_purchased = false;     //Талисман благоденствия приобретен
        heretic_charm_is_purchased = false;     //Талисман еритика приобретен
        order_charm_is_purchased = false;       //Талисман ордена приобретен
        cross_charm_is_purchased = false;       //Талисман нагрудный крест приобретен
        pommel_charm_is_purchased = false;      //Талисман навершие из слоновой кости приобретен
        papa_charm_is_purchased = false;        //Талисман печать папы приобретен
        traitor_charm_is_purchased = false;     //Талисман предателя приобретен

        best_score = 0;  //Лучший результат
        black_ink = 0;   //Количество чернил

        language = 1;      //Текущий язык
        graphics_tier = 0; //Уровень графики
        master_volume = 0.5f; //Общая громкость игры
        music_volume = 0.5f;  //Громкость музыки
        sfx_volume = 0.5f;    //Громкость звуковых эффектов
    }

    public GameData(LevelLoader level_loader)
        //Конструктор для сохранения игры после завершения уровня
    {
        GameData temp = SaveSystem.LoadData();
        current_scene = temp.current_scene;     //Текущая сцена
        current_weapon = temp.current_weapon;    //текущиее оружее
        current_armor = temp.current_armor;     //Текущая броня
        current_charm_0 = temp.current_charm_0;   //текущий первый талисман
        current_charm_1 = temp.current_charm_1;   //текущий второй талисман
        current_charm_2 = temp.current_charm_2;   //текущий третий талисман
        combometer_size = temp.combometer_size;   //Текущий размер комбометра
        combo_fourious_attack_is_available = temp.combo_fourious_attack_is_available;     //Доступно ли комбо яростной атаки
        combo_master_stun_is_available = temp.combo_master_stun_is_available;         //Доступно ли комбо мастерское оглушение
        combo_horizontal_cut_is_available = temp.combo_horizontal_cut_is_available;      //Доступно ли комбо горизонтального разреза
        combo_shuffle_is_available = temp.combo_shuffle_is_available;             //Доступно ли комбо перетасовки
        combo_florescence_is_available = temp.combo_florescence_is_available;         //Доступно ли комбо расцвета
        combo_sublime_dissection_is_available = temp.combo_sublime_dissection_is_available;  //Доступно ли комбо грандиозного рассчения

        prolog_is_completed = temp.prolog_is_completed;     //Пролог завершен
        scene1_is_purchased = temp.scene1_is_purchased;    //Первая сцена приобретена 
        scene1_is_completed = temp.scene1_is_completed;    //Первая cцена пройдена один раз
        scene2_is_purchased = temp.scene2_is_purchased;    //Вторая сцена приобретена 
        scene2_is_completed = temp.scene2_is_completed;    //Вторая cцена пройдена один раз
        scene3_is_purchased = temp.scene3_is_purchased;    //Третья сцена приобретена 
        scene3_is_completed = temp.scene3_is_completed;    //Третья cцена пройдена один раз
        scene4_is_purchased = temp.scene4_is_purchased;    //Четвертая сцена приобретена 
        scene4_is_completed = temp.scene4_is_completed;    //Четвертая cцена пройдена один раз
        scene5_is_purchased = temp.scene5_is_purchased;    //Пятая сцена приобретена 
        scene5_is_completed = temp.scene5_is_completed;    //Пятая cцена пройдена один раз
        scene6_is_purchased = temp.scene6_is_purchased;    //Шестая сцена приобретена 
        scene6_is_completed = temp.scene6_is_completed;    //Шестая cцена пройдена один раз
        scene7_is_purchased = temp.scene7_is_purchased;    //Седьмая сцена приобретена 
        scene7_is_completed = temp.scene7_is_completed;    //Седьмая cцена пройдена один раз
        scene8_is_purchased = temp.scene8_is_purchased;    //Восьмая сцена приобретена 
        scene8_is_completed = temp.scene8_is_completed;    //Восьмая cцена пройдена один раз
        scene9_is_purchased = temp.scene9_is_purchased;    //Девятая сцена приобретена 
        scene9_is_completed = temp.scene9_is_completed;    //Девятая cцена пройдена один раз
        scene10_is_purchased = temp.scene10_is_purchased;   //Десятая сцена приобретена 
        scene10_is_completed = temp.scene10_is_completed;   //Десятая cцена пройдена один раз
        scene11_is_purchased = temp.scene11_is_purchased;   //Одиннадцатая сцена приобретена 
        scene11_is_completed = temp.scene11_is_completed;   //Одиннадцатая cцена пройдена один раз

        broken_sword_is_purchased = temp.broken_sword_is_purchased;  //Сломанный меч приобретен
        falchion_is_purchased = temp.falchion_is_purchased;      //Фальшион приобретен
        zweihander_is_purchased = temp.zweihander_is_purchased;    //Двуручник приобретен
        peter_sword_is_purchased = temp.peter_sword_is_purchased;   //Меч святого Петра приобретен
        januar_dagger_is_purchased = temp.januar_dagger_is_purchased; //Кинжал святого Януария приобретен
        viennese_spear_is_purchased = temp.viennese_spear_is_purchased;//Венское копье приобретено
        russian_sword_is_purchased = temp.russian_sword_is_purchased; //Русский меч приобретен

        chain_mail_is_purchased = temp.chain_mail_is_purchased;            //Кольчуга приобретена
        hardened_chain_mail_is_purchased = temp.hardened_chain_mail_is_purchased;   //Урепленная кольчуга приобретена
        heavy_armor_is_purchased = temp.heavy_armor_is_purchased;           //Тяжелая броня приобретена

        welfare_charm_is_purchased = temp.welfare_charm_is_purchased;     //Талисман благоденствия приобретен
        heretic_charm_is_purchased = temp.heretic_charm_is_purchased;     //Талисман еритика приобретен
        order_charm_is_purchased = temp.order_charm_is_purchased;       //Талисман ордена приобретен
        cross_charm_is_purchased = temp.cross_charm_is_purchased;       //Талисман нагрудный крест приобретен
        pommel_charm_is_purchased = temp.pommel_charm_is_purchased;      //Талисман навершие из слоновой кости приобретен
        papa_charm_is_purchased = temp.papa_charm_is_purchased;        //Талисман печать папы приобретен
        traitor_charm_is_purchased = temp.traitor_charm_is_purchased;     //Талисман предателя приобретен
        switch (temp.current_scene)
        {
            case 11:
                scene11_is_completed = true;
                break;
            case 10:
                scene10_is_completed = true;
                break;
            case 9:
                scene9_is_completed = true;
                break;
            case 8:
                scene8_is_completed = true;
                break;
            case 7:
                scene7_is_completed = true;
                break;
            case 6:
                scene6_is_completed = true;
                break;
            case 5:
                scene5_is_completed = true;
                break;
            case 4:
                scene4_is_completed = true;
                break;
            case 3:
                scene3_is_completed = true;
                break;
            case 2:
                scene2_is_completed = true;
                break;
            case 1:
                scene1_is_completed = true;
                break;
            case 0:
                prolog_is_completed = true;
                break;
            default:
                break;

        }

        language = temp.language;

        graphics_tier = temp.graphics_tier; //Уровень графики
        master_volume = temp.master_volume; //Общая громкость игры
        music_volume = temp.music_volume;  //Громкость музыки
        sfx_volume = temp.sfx_volume;    //Громкость звуковых эффектов

        short score = System.Convert.ToInt16(level_loader.game_manager.score);
        if (score > level_loader.best_score)
        {
            best_score = score;  //Лучший результат
        }
        
        black_ink = level_loader.black_ink;   //Количество чернил
    }

    public GameData(MainMenuManager main_menu)
    //Конструктор для сохранения игры после завершения уровня
    {
        current_scene = main_menu.current_scene;     //Текущая сцена
        current_weapon = main_menu.GetCurrentEquipId(EquipSelector.EquipType.Weapon); //текущиее оружее
        current_armor = main_menu.GetCurrentEquipId(EquipSelector.EquipType.Armor);   //Текущая броня
        current_charm_0 = main_menu.GetCurrentEquipId(EquipSelector.EquipType.Talisman1);   //текущий первый талисман
        current_charm_1 = main_menu.GetCurrentEquipId(EquipSelector.EquipType.Talisman2);   //текущий второй талисман
        current_charm_2 = main_menu.GetCurrentEquipId(EquipSelector.EquipType.Talisman3);   //текущий третий талисман
        combometer_size = main_menu.combometer_size;   //Текущий размер комбометра
        combo_split_is_available = main_menu.combo_split_is_available;               //Доступно ли комбо разрыва
        combo_fourious_attack_is_available = main_menu.combo_fourious_attack_is_available;     //Доступно ли комбо яростной атаки
        combo_master_stun_is_available = main_menu.combo_master_stun_is_available;         //Доступно ли комбо мастерское оглушение
        combo_horizontal_cut_is_available = main_menu.combo_horizontal_cut_is_available;      //Доступно ли комбо горизонтального разреза
        combo_shuffle_is_available = main_menu.combo_shuffle_is_available;             //Доступно ли комбо перетасовки
        combo_florescence_is_available = main_menu.combo_florescence_is_available;         //Доступно ли комбо расцвета
        combo_sublime_dissection_is_available = main_menu.combo_sublime_dissection_is_available;  //Доступно ли комбо грандиозного рассчения

        prolog_is_completed = main_menu.is_prolog_completed;        //Пройден ли пролог
        scene1_is_purchased = main_menu.scenes[0].is_purchased;    //Первая сцена приобретена 
        scene1_is_completed = main_menu.scenes[0].is_completed;    //Первая cцена пройдена один раз
        scene2_is_purchased = main_menu.scenes[1].is_purchased;    //Вторая сцена приобретена 
        scene2_is_completed = main_menu.scenes[1].is_completed;    //Вторая cцена пройдена один раз
        scene3_is_purchased = main_menu.scenes[2].is_purchased;    //Третья сцена приобретена 
        scene3_is_completed = main_menu.scenes[2].is_completed;    //Третья cцена пройдена один раз
        scene4_is_purchased = main_menu.scenes[3].is_purchased;    //Четвертая сцена приобретена 
        scene4_is_completed = main_menu.scenes[3].is_completed;    //Четвертая cцена пройдена один раз
        scene5_is_purchased = main_menu.scenes[4].is_purchased;    //Пятая сцена приобретена 
        scene5_is_completed = main_menu.scenes[4].is_completed;    //Пятая cцена пройдена один раз
        scene6_is_purchased = main_menu.scenes[5].is_purchased;    //Шестая сцена приобретена 
        scene6_is_completed = main_menu.scenes[5].is_completed;    //Шестая cцена пройдена один раз
        scene7_is_purchased = main_menu.scenes[6].is_purchased;    //Седьмая сцена приобретена 
        scene7_is_completed = main_menu.scenes[6].is_completed;    //Седьмая cцена пройдена один раз
        scene8_is_purchased = main_menu.scenes[7].is_purchased;    //Восьмая сцена приобретена 
        scene8_is_completed = main_menu.scenes[7].is_completed;    //Восьмая cцена пройдена один раз
        scene9_is_purchased = main_menu.scenes[8].is_purchased;    //Девятая сцена приобретена 
        scene9_is_completed = main_menu.scenes[8].is_completed;    //Девятая cцена пройдена один раз
        scene10_is_purchased = main_menu.scenes[9].is_purchased;   //Десятая сцена приобретена 
        scene10_is_completed = main_menu.scenes[9].is_completed;   //Десятая cцена пройдена один раз
        scene11_is_purchased = main_menu.scenes[10].is_purchased;   //Одиннадцатая сцена приобретена 
        scene11_is_completed = main_menu.scenes[10].is_completed;   //Одиннадцатая cцена пройдена один раз
        broken_sword_is_purchased = main_menu.broken_sword_is_purchased;  //Сломанный меч приобретен
        falchion_is_purchased = main_menu.falchion_is_purchased;      //Фальшион приобретен
        zweihander_is_purchased = main_menu.zweihander_is_purchased;    //Двуручник приобретен
        peter_sword_is_purchased = main_menu.peter_sword_is_purchased;   //Меч святого Петра приобретен
        januar_dagger_is_purchased = main_menu.januar_dagger_is_purchased; //Кинжал святого Януария приобретен
        viennese_spear_is_purchased = main_menu.viennese_spear_is_purchased;//Венское копье приобретено
        russian_sword_is_purchased = main_menu.russian_sword_is_purchased; //Русский меч приобретен
        chain_mail_is_purchased = main_menu.chain_mail_is_purchased;            //Кольчуга приобретена
        hardened_chain_mail_is_purchased = main_menu.hardened_chain_mail_is_purchased;   //Урепленная кольчуга приобретена
        heavy_armor_is_purchased = main_menu.heavy_armor_is_purchased;           //Тяжелая броня приобретена
        welfare_charm_is_purchased = main_menu.welfare_charm_is_purchased;     //Талисман благоденствия приобретен
        heretic_charm_is_purchased = main_menu.heretic_charm_is_purchased;     //Талисман еритика приобретен
        order_charm_is_purchased = main_menu.order_charm_is_purchased;       //Талисман ордена приобретен
        cross_charm_is_purchased = main_menu.cross_charm_is_purchased;       //Талисман нагрудный крест приобретен
        pommel_charm_is_purchased = main_menu.pommel_charm_is_purchased;      //Талисман навершие из слоновой кости приобретен
        papa_charm_is_purchased = main_menu.papa_charm_is_purchased;        //Талисман печать папы приобретен
        traitor_charm_is_purchased = main_menu.traitor_charm_is_purchased;     //Талисман предателя приобретен

        Language.LanguageType current_language = main_menu.language_settings;
        switch (current_language)
        {
            case Language.LanguageType.english:
                language = 0;
                break;

            case Language.LanguageType.russian:
                language = 1;
                break;

            case Language.LanguageType.german:
                language = 2;
                break;

            case Language.LanguageType.french:
                language = 3;
                break;

            case Language.LanguageType.esperanto:
                language = 4;
                break;
        }//Текущий язык

        graphics_tier = main_menu.graphics_tier; //Уровень графики
        master_volume = main_menu.master_volume; //Общая громкость игры
        music_volume = main_menu.music_volume;  //Громкость музыки
        sfx_volume = main_menu.sfx_volume;    //Громкость звуковых эффектов

        best_score = main_menu.best_score;  //лучший результат
        black_ink = 0;   //Количество чернил
    }

    public GameData (StartScreenManager screen_manager)
    //конструктор для сохранения после ервого запуска
    {
        GameData temp = new GameData();
        language = (byte) Language.LanguageToInt(screen_manager.current_language);

        current_scene = temp.current_scene;     //Текущая сцена
        current_weapon = temp.current_weapon;    //текущиее оружее
        current_armor = temp.current_armor;     //Текущая броня
        current_charm_0 = temp.current_charm_0;   //текущий первый талисман
        current_charm_1 = temp.current_charm_1;   //текущий второй талисман
        current_charm_2 = temp.current_charm_2;   //текущий третий талисман
        combometer_size = temp.combometer_size;   //Текущий размер комбометра
        combo_split_is_available = temp.combo_split_is_available;               //Доступно ли комбо разрыва
        combo_fourious_attack_is_available = temp.combo_fourious_attack_is_available;     //Доступно ли комбо яростной атаки
        combo_master_stun_is_available = temp.combo_master_stun_is_available;         //Доступно ли комбо мастерское оглушение
        combo_horizontal_cut_is_available = temp.combo_horizontal_cut_is_available;      //Доступно ли комбо горизонтального разреза
        combo_shuffle_is_available = temp.combo_shuffle_is_available;             //Доступно ли комбо перетасовки
        combo_florescence_is_available = temp.combo_florescence_is_available;         //Доступно ли комбо расцвета
        combo_sublime_dissection_is_available = temp.combo_sublime_dissection_is_available;  //Доступно ли комбо грандиозного рассчения

        prolog_is_completed = temp.prolog_is_completed;     //Пролог завершен
        scene1_is_purchased = temp.scene1_is_purchased;    //Первая сцена приобретена 
        scene1_is_completed = temp.scene1_is_completed;    //Первая cцена пройдена один раз
        scene2_is_purchased = temp.scene2_is_purchased;    //Вторая сцена приобретена 
        scene2_is_completed = temp.scene2_is_completed;    //Вторая cцена пройдена один раз
        scene3_is_purchased = temp.scene3_is_purchased;    //Третья сцена приобретена 
        scene3_is_completed = temp.scene3_is_completed;    //Третья cцена пройдена один раз
        scene4_is_purchased = temp.scene4_is_purchased;    //Четвертая сцена приобретена 
        scene4_is_completed = temp.scene4_is_completed;    //Четвертая cцена пройдена один раз
        scene5_is_purchased = temp.scene5_is_purchased;    //Пятая сцена приобретена 
        scene5_is_completed = temp.scene5_is_completed;    //Пятая cцена пройдена один раз
        scene6_is_purchased = temp.scene6_is_purchased;    //Шестая сцена приобретена 
        scene6_is_completed = temp.scene6_is_completed;    //Шестая cцена пройдена один раз
        scene7_is_purchased = temp.scene7_is_purchased;    //Седьмая сцена приобретена 
        scene7_is_completed = temp.scene7_is_completed;    //Седьмая cцена пройдена один раз
        scene8_is_purchased = temp.scene8_is_purchased;    //Восьмая сцена приобретена 
        scene8_is_completed = temp.scene8_is_completed;    //Восьмая cцена пройдена один раз
        scene9_is_purchased = temp.scene9_is_purchased;    //Девятая сцена приобретена 
        scene9_is_completed = temp.scene9_is_completed;    //Девятая cцена пройдена один раз
        scene10_is_purchased = temp.scene10_is_purchased;   //Десятая сцена приобретена 
        scene10_is_completed = temp.scene10_is_completed;   //Десятая cцена пройдена один раз
        scene11_is_purchased = temp.scene11_is_purchased;   //Одиннадцатая сцена приобретена 
        scene11_is_completed = temp.scene11_is_completed;   //Одиннадцатая cцена пройдена один раз
        broken_sword_is_purchased = temp.broken_sword_is_purchased;  //Сломанный меч приобретен
        falchion_is_purchased = temp.falchion_is_purchased;      //Фальшион приобретен
        zweihander_is_purchased = temp.zweihander_is_purchased;    //Двуручник приобретен
        peter_sword_is_purchased = temp.peter_sword_is_purchased;   //Меч святого Петра приобретен
        januar_dagger_is_purchased = temp.januar_dagger_is_purchased; //Кинжал святого Януария приобретен
        viennese_spear_is_purchased = temp.viennese_spear_is_purchased;//Венское копье приобретено
        russian_sword_is_purchased = temp.russian_sword_is_purchased; //Русский меч приобретен
        chain_mail_is_purchased = temp.chain_mail_is_purchased;            //Кольчуга приобретена
        hardened_chain_mail_is_purchased = temp.hardened_chain_mail_is_purchased;   //Урепленная кольчуга приобретена
        heavy_armor_is_purchased = temp.heavy_armor_is_purchased;           //Тяжелая броня приобретена
        welfare_charm_is_purchased = temp.welfare_charm_is_purchased;     //Талисман благоденствия приобретен
        heretic_charm_is_purchased = temp.heretic_charm_is_purchased;     //Талисман еритика приобретен
        order_charm_is_purchased = temp.order_charm_is_purchased;       //Талисман ордена приобретен
        cross_charm_is_purchased = temp.cross_charm_is_purchased;       //Талисман нагрудный крест приобретен
        pommel_charm_is_purchased = temp.pommel_charm_is_purchased;      //Талисман навершие из слоновой кости приобретен
        papa_charm_is_purchased = temp.papa_charm_is_purchased;        //Талисман печать папы приобретен
        traitor_charm_is_purchased = temp.traitor_charm_is_purchased;     //Талисман предателя приобретен

        graphics_tier = temp.graphics_tier; //Уровень графики
        master_volume = temp.master_volume; //Общая громкость игры
        music_volume = temp.music_volume;  //Громкость музыки
        sfx_volume = temp.sfx_volume;    //Громкость звуковых эффектов
        best_score = temp.best_score;  //Лучший результат
        black_ink = temp.black_ink;   //Количество чернил
    }
}
