//Класс отвечает за необходимые для переноса в следующую сцену/игровую сессию данные

using Level.Load_and_Manager;
using UnityEngine;

[System.Serializable]
public class GameData
{
    [Header("Current Equipment")]   //Текущее снаряжение рыцаря, катсцены и другое
    public byte currentScene;     //Текущая сцена
    public byte currentWeapon;    //текущиее оружее
    public byte currentArmor;     //Текущая броня
    public byte currentCharm0;   //текущий первый талисман
    public byte currentCharm1;   //текущий второй талисман
    public byte currentCharm2;   //текущий третий талисман
    public byte combometerSize;   //Текущий размер комбометра
    public bool comboSplitIsAvailable;               //Доступно ли комбо разрыва
    public bool comboFouriousAttackIsAvailable;     //Доступно ли комбо яростной атаки
    public bool comboMasterStunIsAvailable;         //Доступно ли комбо мастерское оглушение
    public bool comboHorizontalCutIsAvailable;      //Доступно ли комбо горизонтального разреза
    public bool comboShuffleIsAvailable;             //Доступно ли комбо перетасовки
    public bool comboFlorescenceIsAvailable;         //Доступно ли комбо расцвета
    public bool comboSublimeDissectionIsAvailable;  //Доступно ли комбо грандиозного рассчения

    [Header("Purchased items")]         //Приобретеные вещи
    public bool prologIsCompleted;    //Пройден ли пролог
    public bool scene1IsPurchased;    //Первая сцена приобретена 
    public bool scene1IsCompleted;    //Первая cцена пройдена один раз
    public bool scene2IsPurchased;    //Вторая сцена приобретена 
    public bool scene2IsCompleted;    //Вторая cцена пройдена один раз
    public bool scene3IsPurchased;    //Третья сцена приобретена 
    public bool scene3IsCompleted;    //Третья cцена пройдена один раз
    public bool scene4IsPurchased;    //Четвертая сцена приобретена 
    public bool scene4IsCompleted;    //Четвертая cцена пройдена один раз
    public bool scene5IsPurchased;    //Пятая сцена приобретена 
    public bool scene5IsCompleted;    //Пятая cцена пройдена один раз
    public bool scene6IsPurchased;    //Шестая сцена приобретена 
    public bool scene6IsCompleted;    //Шестая cцена пройдена один раз
    public bool scene7IsPurchased;    //Седьмая сцена приобретена 
    public bool scene7IsCompleted;    //Седьмая cцена пройдена один раз
    public bool scene8IsPurchased;    //Восьмая сцена приобретена 
    public bool scene8IsCompleted;    //Восьмая cцена пройдена один раз
    public bool scene9IsPurchased;    //Девятая сцена приобретена 
    public bool scene9IsCompleted;    //Девятая cцена пройдена один раз
    public bool scene10IsPurchased;   //Десятая сцена приобретена 
    public bool scene10IsCompleted;   //Десятая cцена пройдена один раз
    public bool scene11IsPurchased;   //Одиннадцатая сцена приобретена 
    public bool scene11IsCompleted;   //Одиннадцатая cцена пройдена один раз
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
    public short bestScore;    //Лучший результат
    public short blackInk;     //Количество чернил

    [Header("Settings")]        //Настройки игры
    public byte language;      //Текущий язык
    public byte graphicsTier; //Уровень графики
    public float masterVolume; //Общая громкость игры
    public float musicVolume;  //Громкость музыки
    public float sfxVolume;    //Громкость звуковых эффектов

    public GameData()
        //Конструктор для пустого объекта. Нужен для первого запуска игры, когда игрок еще ничего не сделал
    {
        currentScene = 0;     //Текущая сцена
        currentWeapon = 0;    //текущиее оружее
        currentArmor = 0;     //Текущая броня
        currentCharm0 = 0;   //текущий первый талисман
        currentCharm1 = 0;   //текущий второй талисман
        currentCharm2 = 0;   //текущий третий талисман
        combometerSize = 1;   //Текущий размер комбометра
        comboSplitIsAvailable = false;               //Доступно ли комбо разрыва
        comboFouriousAttackIsAvailable = false;     //Доступно ли комбо яростной атаки
        comboMasterStunIsAvailable = false;         //Доступно ли комбо мастерское оглушение
        comboHorizontalCutIsAvailable = false;      //Доступно ли комбо горизонтального разреза
        comboShuffleIsAvailable = false;             //Доступно ли комбо перетасовки
        comboFlorescenceIsAvailable = false;         //Доступно ли комбо расцвета
        comboSublimeDissectionIsAvailable = false;  //Доступно ли комбо грандиозного рассчения

        prologIsCompleted = false;    //Пройден ли пролог
        scene1IsPurchased = false;    //Первая сцена приобретена 
        scene1IsCompleted = false;    //Первая cцена пройдена один раз
        scene2IsPurchased = false;    //Вторая сцена приобретена 
        scene2IsCompleted = false;    //Вторая cцена пройдена один раз
        scene3IsPurchased = false;    //Третья сцена приобретена 
        scene3IsCompleted = false;    //Третья cцена пройдена один раз
        scene4IsPurchased = false;    //Четвертая сцена приобретена 
        scene4IsCompleted = false;    //Четвертая cцена пройдена один раз
        scene5IsPurchased = false;    //Пятая сцена приобретена 
        scene5IsCompleted = false;    //Пятая cцена пройдена один раз
        scene6IsPurchased = false;    //Шестая сцена приобретена 
        scene6IsCompleted = false;    //Шестая cцена пройдена один раз
        scene7IsPurchased = false;    //Седьмая сцена приобретена 
        scene7IsCompleted = false;    //Седьмая cцена пройдена один раз
        scene8IsPurchased = false;    //Восьмая сцена приобретена 
        scene8IsCompleted = false;    //Восьмая cцена пройдена один раз
        scene9IsPurchased = false;    //Девятая сцена приобретена 
        scene9IsCompleted = false;    //Девятая cцена пройдена один раз
        scene10IsPurchased = false;   //Десятая сцена приобретена 
        scene10IsCompleted = false;   //Десятая cцена пройдена один раз
        scene11IsPurchased = false;   //Одиннадцатая сцена приобретена 
        scene11IsCompleted = false;   //Одиннадцатая cцена пройдена один раз
        brokenSwordIsPurchased = false;  //Сломанный меч приобретен
        falchionIsPurchased = false;      //Фальшион приобретен
        zweihanderIsPurchased = false;    //Двуручник приобретен
        peterSwordIsPurchased = false;   //Меч святого Петра приобретен
        januarDaggerIsPurchased = false; //Кинжал святого Януария приобретен
        vienneseSpearIsPurchased = false;//Венское копье приобретено
        russianSwordIsPurchased = false; //Русский меч приобретен
        chainMailIsPurchased = false;            //Кольчуга приобретена
        hardenedChainMailIsPurchased = false;   //Урепленная кольчуга приобретена
        heavyArmorIsPurchased = false;           //Тяжелая броня приобретена
        welfareCharmIsPurchased = false;     //Талисман благоденствия приобретен
        hereticCharmIsPurchased = false;     //Талисман еритика приобретен
        orderCharmIsPurchased = false;       //Талисман ордена приобретен
        crossCharmIsPurchased = false;       //Талисман нагрудный крест приобретен
        pommelCharmIsPurchased = false;      //Талисман навершие из слоновой кости приобретен
        papaCharmIsPurchased = false;        //Талисман печать папы приобретен
        traitorCharmIsPurchased = false;     //Талисман предателя приобретен

        bestScore = 0;  //Лучший результат
        blackInk = 0;   //Количество чернил

        language = 1;      //Текущий язык
        graphicsTier = 0; //Уровень графики
        masterVolume = 0.5f; //Общая громкость игры
        musicVolume = 0.5f;  //Громкость музыки
        sfxVolume = 0.5f;    //Громкость звуковых эффектов
    }

    public GameData(LevelLoader levelLoader)
        //Конструктор для сохранения игры после завершения уровня
    {
        GameData temp = SaveSystem.LoadData();
        currentScene = temp.currentScene;     //Текущая сцена
        currentWeapon = temp.currentWeapon;    //текущиее оружее
        currentArmor = temp.currentArmor;     //Текущая броня
        currentCharm0 = temp.currentCharm0;   //текущий первый талисман
        currentCharm1 = temp.currentCharm1;   //текущий второй талисман
        currentCharm2 = temp.currentCharm2;   //текущий третий талисман
        combometerSize = temp.combometerSize;   //Текущий размер комбометра
        comboFouriousAttackIsAvailable = temp.comboFouriousAttackIsAvailable;     //Доступно ли комбо яростной атаки
        comboMasterStunIsAvailable = temp.comboMasterStunIsAvailable;         //Доступно ли комбо мастерское оглушение
        comboHorizontalCutIsAvailable = temp.comboHorizontalCutIsAvailable;      //Доступно ли комбо горизонтального разреза
        comboShuffleIsAvailable = temp.comboShuffleIsAvailable;             //Доступно ли комбо перетасовки
        comboFlorescenceIsAvailable = temp.comboFlorescenceIsAvailable;         //Доступно ли комбо расцвета
        comboSublimeDissectionIsAvailable = temp.comboSublimeDissectionIsAvailable;  //Доступно ли комбо грандиозного рассчения

        prologIsCompleted = temp.prologIsCompleted;     //Пролог завершен
        scene1IsPurchased = temp.scene1IsPurchased;    //Первая сцена приобретена 
        scene1IsCompleted = temp.scene1IsCompleted;    //Первая cцена пройдена один раз
        scene2IsPurchased = temp.scene2IsPurchased;    //Вторая сцена приобретена 
        scene2IsCompleted = temp.scene2IsCompleted;    //Вторая cцена пройдена один раз
        scene3IsPurchased = temp.scene3IsPurchased;    //Третья сцена приобретена 
        scene3IsCompleted = temp.scene3IsCompleted;    //Третья cцена пройдена один раз
        scene4IsPurchased = temp.scene4IsPurchased;    //Четвертая сцена приобретена 
        scene4IsCompleted = temp.scene4IsCompleted;    //Четвертая cцена пройдена один раз
        scene5IsPurchased = temp.scene5IsPurchased;    //Пятая сцена приобретена 
        scene5IsCompleted = temp.scene5IsCompleted;    //Пятая cцена пройдена один раз
        scene6IsPurchased = temp.scene6IsPurchased;    //Шестая сцена приобретена 
        scene6IsCompleted = temp.scene6IsCompleted;    //Шестая cцена пройдена один раз
        scene7IsPurchased = temp.scene7IsPurchased;    //Седьмая сцена приобретена 
        scene7IsCompleted = temp.scene7IsCompleted;    //Седьмая cцена пройдена один раз
        scene8IsPurchased = temp.scene8IsPurchased;    //Восьмая сцена приобретена 
        scene8IsCompleted = temp.scene8IsCompleted;    //Восьмая cцена пройдена один раз
        scene9IsPurchased = temp.scene9IsPurchased;    //Девятая сцена приобретена 
        scene9IsCompleted = temp.scene9IsCompleted;    //Девятая cцена пройдена один раз
        scene10IsPurchased = temp.scene10IsPurchased;   //Десятая сцена приобретена 
        scene10IsCompleted = temp.scene10IsCompleted;   //Десятая cцена пройдена один раз
        scene11IsPurchased = temp.scene11IsPurchased;   //Одиннадцатая сцена приобретена 
        scene11IsCompleted = temp.scene11IsCompleted;   //Одиннадцатая cцена пройдена один раз

        brokenSwordIsPurchased = temp.brokenSwordIsPurchased;  //Сломанный меч приобретен
        falchionIsPurchased = temp.falchionIsPurchased;      //Фальшион приобретен
        zweihanderIsPurchased = temp.zweihanderIsPurchased;    //Двуручник приобретен
        peterSwordIsPurchased = temp.peterSwordIsPurchased;   //Меч святого Петра приобретен
        januarDaggerIsPurchased = temp.januarDaggerIsPurchased; //Кинжал святого Януария приобретен
        vienneseSpearIsPurchased = temp.vienneseSpearIsPurchased;//Венское копье приобретено
        russianSwordIsPurchased = temp.russianSwordIsPurchased; //Русский меч приобретен

        chainMailIsPurchased = temp.chainMailIsPurchased;            //Кольчуга приобретена
        hardenedChainMailIsPurchased = temp.hardenedChainMailIsPurchased;   //Урепленная кольчуга приобретена
        heavyArmorIsPurchased = temp.heavyArmorIsPurchased;           //Тяжелая броня приобретена

        welfareCharmIsPurchased = temp.welfareCharmIsPurchased;     //Талисман благоденствия приобретен
        hereticCharmIsPurchased = temp.hereticCharmIsPurchased;     //Талисман еритика приобретен
        orderCharmIsPurchased = temp.orderCharmIsPurchased;       //Талисман ордена приобретен
        crossCharmIsPurchased = temp.crossCharmIsPurchased;       //Талисман нагрудный крест приобретен
        pommelCharmIsPurchased = temp.pommelCharmIsPurchased;      //Талисман навершие из слоновой кости приобретен
        papaCharmIsPurchased = temp.papaCharmIsPurchased;        //Талисман печать папы приобретен
        traitorCharmIsPurchased = temp.traitorCharmIsPurchased;     //Талисман предателя приобретен
        switch (temp.currentScene)
        {
            case 11:
                scene11IsCompleted = true;
                break;
            case 10:
                scene10IsCompleted = true;
                break;
            case 9:
                scene9IsCompleted = true;
                break;
            case 8:
                scene8IsCompleted = true;
                break;
            case 7:
                scene7IsCompleted = true;
                break;
            case 6:
                scene6IsCompleted = true;
                break;
            case 5:
                scene5IsCompleted = true;
                break;
            case 4:
                scene4IsCompleted = true;
                break;
            case 3:
                scene3IsCompleted = true;
                break;
            case 2:
                scene2IsCompleted = true;
                break;
            case 1:
                scene1IsCompleted = true;
                break;
            case 0:
                prologIsCompleted = true;
                break;
            default:
                break;

        }

        language = temp.language;

        graphicsTier = temp.graphicsTier; //Уровень графики
        masterVolume = temp.masterVolume; //Общая громкость игры
        musicVolume = temp.musicVolume;  //Громкость музыки
        sfxVolume = temp.sfxVolume;    //Громкость звуковых эффектов

        short score = System.Convert.ToInt16(levelLoader.gameManager.score);
        if (score > levelLoader.bestScore)
        {
            bestScore = score;  //Лучший результат
        }
        
        blackInk = levelLoader.blackInk;   //Количество чернил
    }

    public GameData(MainMenuManager mainMenu)
    //Конструктор для сохранения игры после завершения уровня
    {
        currentScene = mainMenu.currentScene;     //Текущая сцена
        currentWeapon = mainMenu.GetCurrentEquipId(EquipSelector.EquipType.Weapon); //текущиее оружее
        currentArmor = mainMenu.GetCurrentEquipId(EquipSelector.EquipType.Armor);   //Текущая броня
        currentCharm0 = mainMenu.GetCurrentEquipId(EquipSelector.EquipType.Talisman1);   //текущий первый талисман
        currentCharm1 = mainMenu.GetCurrentEquipId(EquipSelector.EquipType.Talisman2);   //текущий второй талисман
        currentCharm2 = mainMenu.GetCurrentEquipId(EquipSelector.EquipType.Talisman3);   //текущий третий талисман
        combometerSize = mainMenu.combometerSize;   //Текущий размер комбометра
        comboSplitIsAvailable = mainMenu.comboSplitIsAvailable;               //Доступно ли комбо разрыва
        comboFouriousAttackIsAvailable = mainMenu.comboFouriousAttackIsAvailable;     //Доступно ли комбо яростной атаки
        comboMasterStunIsAvailable = mainMenu.comboMasterStunIsAvailable;         //Доступно ли комбо мастерское оглушение
        comboHorizontalCutIsAvailable = mainMenu.comboHorizontalCutIsAvailable;      //Доступно ли комбо горизонтального разреза
        comboShuffleIsAvailable = mainMenu.comboShuffleIsAvailable;             //Доступно ли комбо перетасовки
        comboFlorescenceIsAvailable = mainMenu.comboFlorescenceIsAvailable;         //Доступно ли комбо расцвета
        comboSublimeDissectionIsAvailable = mainMenu.comboSublimeDissectionIsAvailable;  //Доступно ли комбо грандиозного рассчения

        prologIsCompleted = mainMenu.isPrologCompleted;        //Пройден ли пролог
        scene1IsPurchased = mainMenu.scenes[0].is_purchased;    //Первая сцена приобретена 
        scene1IsCompleted = mainMenu.scenes[0].is_completed;    //Первая cцена пройдена один раз
        scene2IsPurchased = mainMenu.scenes[1].is_purchased;    //Вторая сцена приобретена 
        scene2IsCompleted = mainMenu.scenes[1].is_completed;    //Вторая cцена пройдена один раз
        scene3IsPurchased = mainMenu.scenes[2].is_purchased;    //Третья сцена приобретена 
        scene3IsCompleted = mainMenu.scenes[2].is_completed;    //Третья cцена пройдена один раз
        scene4IsPurchased = mainMenu.scenes[3].is_purchased;    //Четвертая сцена приобретена 
        scene4IsCompleted = mainMenu.scenes[3].is_completed;    //Четвертая cцена пройдена один раз
        scene5IsPurchased = mainMenu.scenes[4].is_purchased;    //Пятая сцена приобретена 
        scene5IsCompleted = mainMenu.scenes[4].is_completed;    //Пятая cцена пройдена один раз
        scene6IsPurchased = mainMenu.scenes[5].is_purchased;    //Шестая сцена приобретена 
        scene6IsCompleted = mainMenu.scenes[5].is_completed;    //Шестая cцена пройдена один раз
        scene7IsPurchased = mainMenu.scenes[6].is_purchased;    //Седьмая сцена приобретена 
        scene7IsCompleted = mainMenu.scenes[6].is_completed;    //Седьмая cцена пройдена один раз
        scene8IsPurchased = mainMenu.scenes[7].is_purchased;    //Восьмая сцена приобретена 
        scene8IsCompleted = mainMenu.scenes[7].is_completed;    //Восьмая cцена пройдена один раз
        scene9IsPurchased = mainMenu.scenes[8].is_purchased;    //Девятая сцена приобретена 
        scene9IsCompleted = mainMenu.scenes[8].is_completed;    //Девятая cцена пройдена один раз
        scene10IsPurchased = mainMenu.scenes[9].is_purchased;   //Десятая сцена приобретена 
        scene10IsCompleted = mainMenu.scenes[9].is_completed;   //Десятая cцена пройдена один раз
        scene11IsPurchased = mainMenu.scenes[10].is_purchased;   //Одиннадцатая сцена приобретена 
        scene11IsCompleted = mainMenu.scenes[10].is_completed;   //Одиннадцатая cцена пройдена один раз
        brokenSwordIsPurchased = mainMenu.brokenSwordIsPurchased;  //Сломанный меч приобретен
        falchionIsPurchased = mainMenu.falchionIsPurchased;      //Фальшион приобретен
        zweihanderIsPurchased = mainMenu.zweihanderIsPurchased;    //Двуручник приобретен
        peterSwordIsPurchased = mainMenu.peterSwordIsPurchased;   //Меч святого Петра приобретен
        januarDaggerIsPurchased = mainMenu.januarDaggerIsPurchased; //Кинжал святого Януария приобретен
        vienneseSpearIsPurchased = mainMenu.vienneseSpearIsPurchased;//Венское копье приобретено
        russianSwordIsPurchased = mainMenu.russianSwordIsPurchased; //Русский меч приобретен
        chainMailIsPurchased = mainMenu.chainMailIsPurchased;            //Кольчуга приобретена
        hardenedChainMailIsPurchased = mainMenu.hardenedChainMailIsPurchased;   //Урепленная кольчуга приобретена
        heavyArmorIsPurchased = mainMenu.heavyArmorIsPurchased;           //Тяжелая броня приобретена
        welfareCharmIsPurchased = mainMenu.welfareCharmIsPurchased;     //Талисман благоденствия приобретен
        hereticCharmIsPurchased = mainMenu.hereticCharmIsPurchased;     //Талисман еритика приобретен
        orderCharmIsPurchased = mainMenu.orderCharmIsPurchased;       //Талисман ордена приобретен
        crossCharmIsPurchased = mainMenu.crossCharmIsPurchased;       //Талисман нагрудный крест приобретен
        pommelCharmIsPurchased = mainMenu.pommelCharmIsPurchased;      //Талисман навершие из слоновой кости приобретен
        papaCharmIsPurchased = mainMenu.papaCharmIsPurchased;        //Талисман печать папы приобретен
        traitorCharmIsPurchased = mainMenu.traitorCharmIsPurchased;     //Талисман предателя приобретен

        Language.LanguageType currentLanguage = mainMenu.languageSettings;
        switch (currentLanguage)
        {
            case Language.LanguageType.English:
                language = 0;
                break;

            case Language.LanguageType.Russian:
                language = 1;
                break;

            case Language.LanguageType.German:
                language = 2;
                break;

            case Language.LanguageType.French:
                language = 3;
                break;

            case Language.LanguageType.Esperanto:
                language = 4;
                break;
        }//Текущий язык

        graphicsTier = mainMenu.graphicsTier; //Уровень графики
        masterVolume = mainMenu.masterVolume; //Общая громкость игры
        musicVolume = mainMenu.musicVolume;  //Громкость музыки
        sfxVolume = mainMenu.sfxVolume;    //Громкость звуковых эффектов

        bestScore = mainMenu.bestScore;  //лучший результат
        blackInk = 0;   //Количество чернил
    }

    public GameData (StartScreenManager screenManager)
    //конструктор для сохранения после ервого запуска
    {
        GameData temp = new GameData();
        language = (byte) Language.LanguageToInt(screenManager.currentLanguage);

        currentScene = temp.currentScene;     //Текущая сцена
        currentWeapon = temp.currentWeapon;    //текущиее оружее
        currentArmor = temp.currentArmor;     //Текущая броня
        currentCharm0 = temp.currentCharm0;   //текущий первый талисман
        currentCharm1 = temp.currentCharm1;   //текущий второй талисман
        currentCharm2 = temp.currentCharm2;   //текущий третий талисман
        combometerSize = temp.combometerSize;   //Текущий размер комбометра
        comboSplitIsAvailable = temp.comboSplitIsAvailable;               //Доступно ли комбо разрыва
        comboFouriousAttackIsAvailable = temp.comboFouriousAttackIsAvailable;     //Доступно ли комбо яростной атаки
        comboMasterStunIsAvailable = temp.comboMasterStunIsAvailable;         //Доступно ли комбо мастерское оглушение
        comboHorizontalCutIsAvailable = temp.comboHorizontalCutIsAvailable;      //Доступно ли комбо горизонтального разреза
        comboShuffleIsAvailable = temp.comboShuffleIsAvailable;             //Доступно ли комбо перетасовки
        comboFlorescenceIsAvailable = temp.comboFlorescenceIsAvailable;         //Доступно ли комбо расцвета
        comboSublimeDissectionIsAvailable = temp.comboSublimeDissectionIsAvailable;  //Доступно ли комбо грандиозного рассчения

        prologIsCompleted = temp.prologIsCompleted;     //Пролог завершен
        scene1IsPurchased = temp.scene1IsPurchased;    //Первая сцена приобретена 
        scene1IsCompleted = temp.scene1IsCompleted;    //Первая cцена пройдена один раз
        scene2IsPurchased = temp.scene2IsPurchased;    //Вторая сцена приобретена 
        scene2IsCompleted = temp.scene2IsCompleted;    //Вторая cцена пройдена один раз
        scene3IsPurchased = temp.scene3IsPurchased;    //Третья сцена приобретена 
        scene3IsCompleted = temp.scene3IsCompleted;    //Третья cцена пройдена один раз
        scene4IsPurchased = temp.scene4IsPurchased;    //Четвертая сцена приобретена 
        scene4IsCompleted = temp.scene4IsCompleted;    //Четвертая cцена пройдена один раз
        scene5IsPurchased = temp.scene5IsPurchased;    //Пятая сцена приобретена 
        scene5IsCompleted = temp.scene5IsCompleted;    //Пятая cцена пройдена один раз
        scene6IsPurchased = temp.scene6IsPurchased;    //Шестая сцена приобретена 
        scene6IsCompleted = temp.scene6IsCompleted;    //Шестая cцена пройдена один раз
        scene7IsPurchased = temp.scene7IsPurchased;    //Седьмая сцена приобретена 
        scene7IsCompleted = temp.scene7IsCompleted;    //Седьмая cцена пройдена один раз
        scene8IsPurchased = temp.scene8IsPurchased;    //Восьмая сцена приобретена 
        scene8IsCompleted = temp.scene8IsCompleted;    //Восьмая cцена пройдена один раз
        scene9IsPurchased = temp.scene9IsPurchased;    //Девятая сцена приобретена 
        scene9IsCompleted = temp.scene9IsCompleted;    //Девятая cцена пройдена один раз
        scene10IsPurchased = temp.scene10IsPurchased;   //Десятая сцена приобретена 
        scene10IsCompleted = temp.scene10IsCompleted;   //Десятая cцена пройдена один раз
        scene11IsPurchased = temp.scene11IsPurchased;   //Одиннадцатая сцена приобретена 
        scene11IsCompleted = temp.scene11IsCompleted;   //Одиннадцатая cцена пройдена один раз
        brokenSwordIsPurchased = temp.brokenSwordIsPurchased;  //Сломанный меч приобретен
        falchionIsPurchased = temp.falchionIsPurchased;      //Фальшион приобретен
        zweihanderIsPurchased = temp.zweihanderIsPurchased;    //Двуручник приобретен
        peterSwordIsPurchased = temp.peterSwordIsPurchased;   //Меч святого Петра приобретен
        januarDaggerIsPurchased = temp.januarDaggerIsPurchased; //Кинжал святого Януария приобретен
        vienneseSpearIsPurchased = temp.vienneseSpearIsPurchased;//Венское копье приобретено
        russianSwordIsPurchased = temp.russianSwordIsPurchased; //Русский меч приобретен
        chainMailIsPurchased = temp.chainMailIsPurchased;            //Кольчуга приобретена
        hardenedChainMailIsPurchased = temp.hardenedChainMailIsPurchased;   //Урепленная кольчуга приобретена
        heavyArmorIsPurchased = temp.heavyArmorIsPurchased;           //Тяжелая броня приобретена
        welfareCharmIsPurchased = temp.welfareCharmIsPurchased;     //Талисман благоденствия приобретен
        hereticCharmIsPurchased = temp.hereticCharmIsPurchased;     //Талисман еритика приобретен
        orderCharmIsPurchased = temp.orderCharmIsPurchased;       //Талисман ордена приобретен
        crossCharmIsPurchased = temp.crossCharmIsPurchased;       //Талисман нагрудный крест приобретен
        pommelCharmIsPurchased = temp.pommelCharmIsPurchased;      //Талисман навершие из слоновой кости приобретен
        papaCharmIsPurchased = temp.papaCharmIsPurchased;        //Талисман печать папы приобретен
        traitorCharmIsPurchased = temp.traitorCharmIsPurchased;     //Талисман предателя приобретен

        graphicsTier = temp.graphicsTier; //Уровень графики
        masterVolume = temp.masterVolume; //Общая громкость игры
        musicVolume = temp.musicVolume;  //Громкость музыки
        sfxVolume = temp.sfxVolume;    //Громкость звуковых эффектов
        bestScore = temp.bestScore;  //Лучший результат
        blackInk = temp.blackInk;   //Количество чернил
    }
}
