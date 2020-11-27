//Класс отвечает за меню атак, за комбометры врагов и рыцаря, за спавн врагов
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Level.Load_and_Manager;
using Save_System;
using UnityEngine;
using UnityEngine.Serialization;

public class AttackMenu : MonoBehaviour
{
    [Header("Links")]
    public static AttackMenu instance;          //ссылка на это меню
    
    public KnightBehaviour knightBehaviour;    //сылка на поведение рыцаря
    public KnightCombometer knightCombometer;  //ссылка на комбометр игрока
    public GameManager gameManager;            //ссылка на игровой менеджер
    [NotNull]public CameraManager cameraManager;         //ссылка на поведение камеры
    public List<Transform> activeLinesTransforms;       //трансформы активных линий
    [NotNull] public List<SliderScript> sliders;          //скрипты слайдеров
    public List<Sprite> enemyPortrets;          //портреты врагов

    [Header("Attack Settings")]
    public int swordDamage;                    //урон меча
    public float timeToDisableHealth = 1f;
    public int dazeTime = 2;                   //Время оглушения врагов
    public float timeOfLatestAttack = 0f;    //Время последней атаки

    [Header("Enemies Settings")]
    public List<GameObject> enemies;            //список врагов
    public List<Vector3> enemiesPosition;      //Позиция врагов на экране
    public float startRunningDelta;           //разница между позицией врага и той, с которой он начинает дфижение

    [FormerlySerializedAs("combometer_needed_points")] [Header("Combometer Settings")]
    public int combometerNeededPoints;            //количество точек, необходимых для заполнения одной ячейки комбометра
    [FormerlySerializedAs("combometer_size")] public int combometerSize;                     //количество ячеек комбометра

    private bool[] green_combometer_cell;           //Какие точки заполнены в одной ячейке зеленого комбметра
    private bool[] green_combometer_cells_number;   //Какие ячейки зеленого комбометра заполнены
    private bool[] red_combometer_cell;             //Какие точки заполнены в одной ячейке красного комбметра  
    private bool[] red_combometer_cells_number;     //Какие ячейки красного комбометра заполнены

    [Header("Combos Settings")]
    public bool comboSplitIsAvailable;               //Доступно ли комбо разрыва
    public bool comboFuriousAttackIsAvailable;     //Доступно ли комбо яростной атаки
    public bool comboMasterStunIsAvailable;         //Доступно ли комбо мастерское оглушение
    public bool comboHorizontalCutIsAvailable;      //Доступно ли комбо горизонтального разреза
    public bool comboShuffleIsAvailable;             //Доступно ли комбо перетасовки
    public bool comboFlorescenceIsAvailable;         //Доступно ли комбо расцвета
    public bool comboSublimeDissectionIsAvailable;  //Доступно ли комбо грандиозного рассчения

    private void Awake()
    {
        instance = this;
    }

    //Запустить меню атак
    public bool StartAttackMenu (SwordData swordData, int size, int neededPoints) 
    {
        if(knightBehaviour == null)
        {
            knightBehaviour = KnightBehaviour.instance;
        }

        {
            swordDamage = swordData.damage;
            Vector3 captureLinesSize =
                new Vector3(activeLinesTransforms[1].localScale.x, activeLinesTransforms[1].localScale.y);
            captureLinesSize *= swordData.captureZoneSize;
            foreach (Transform line in activeLinesTransforms)
            {
                line.localScale = captureLinesSize;
            }
        }

        switch (enemies.Count)
        {
            case 0:
                Debug.LogError("AttackMenu: No Enemies Loaded!");
                break;

            case 1:
                ActivateEnemies(2);
                break;

            case 2:
                for (int i = 1; i < 2; i++)
                    ActivateEnemies(i);
                break;

            case 3:
                for (int i = 0; i < 2; i++)
                    ActivateEnemies(i);
                break;

            default:
                for (int i = 0; i < 3; i++)
                    ActivateEnemies(i);
                break;
        }

        UpdateImages();

        combometerSize = size;
        combometerNeededPoints = neededPoints;

        green_combometer_cell = new bool[combometerNeededPoints];
        red_combometer_cell = new bool[combometerNeededPoints];
        for (int i = 0; i < combometerNeededPoints; i++)
        {
            green_combometer_cell[i] = false;
            red_combometer_cell[i] = false;
        }

        green_combometer_cells_number = new bool[combometerSize];
        red_combometer_cells_number = new bool[combometerSize];
        for (int i = 0; i < combometerSize; i++)
        {
            green_combometer_cells_number[i] = false;
            red_combometer_cells_number[i] = false;
        }
        
       
        if (combometerSize == 2)
        {
            comboSplitIsAvailable = true;               //Доступно ли комбо разрыва
            comboFuriousAttackIsAvailable = true;     //Доступно ли комбо яростной атаки
            comboMasterStunIsAvailable = true;         //Доступно ли комбо мастерское оглушение
            comboHorizontalCutIsAvailable = true;      //Доступно ли комбо горизонтального разреза
            comboShuffleIsAvailable = true;             //Доступно ли комбо перетасовки
            comboFlorescenceIsAvailable = true;         //Доступно ли комбо расцвета
            comboSublimeDissectionIsAvailable = true;  //Доступно ли комбо грандиозного рассчения
        }
        else
        {
            comboSplitIsAvailable = true;               //Доступно ли комбо разрыва
            comboFuriousAttackIsAvailable = true;     //Доступно ли комбо яростной атаки
            comboMasterStunIsAvailable = true;         //Доступно ли комбо мастерское оглушение
            comboHorizontalCutIsAvailable = false;      //Доступно ли комбо горизонтального разреза
            comboShuffleIsAvailable = false;             //Доступно ли комбо перетасовки
            comboFlorescenceIsAvailable = false;         //Доступно ли комбо расцвета
            comboSublimeDissectionIsAvailable = false;  //Доступно ли комбо грандиозного рассчения
        }
        if (combometerSize == 3)
        {
            comboSplitIsAvailable = true;               //Доступно ли комбо разрыва
            comboFuriousAttackIsAvailable = true;     //Доступно ли комбо яростной атаки
            comboMasterStunIsAvailable = true;         //Доступно ли комбо мастерское оглушение
            comboHorizontalCutIsAvailable = true;      //Доступно ли комбо горизонтального разреза
            comboShuffleIsAvailable = true;             //Доступно ли комбо перетасовки
            comboFlorescenceIsAvailable = true;         //Доступно ли комбо расцвета
            comboSublimeDissectionIsAvailable = true;  //Доступно ли комбо грандиозного рассчения
        }
        return true;
    }

    //Активировать врагов на позиции
    public void ActivateEnemies(int position)
    {
        int deathCountTemp = 100;
        int indexTemp = 0;
        bool changed = false;
        for (int i =0; i < enemies.Count; i ++)
        {
            if (!enemies[i].activeSelf && enemies[i].GetComponent<EnemyBehaviour>().death_count <= deathCountTemp)
            {
                changed = true;
                indexTemp = i;
                deathCountTemp = enemies[indexTemp].GetComponent<EnemyBehaviour>().death_count;
            }
        }
        if(!changed)
        {
            indexTemp = position;
        }
        enemies[indexTemp].GetComponent<EnemyBehaviour>().spawn_point_index = position;
        enemies[indexTemp].GetComponent<EnemyBehaviour>().position = enemiesPosition[position];
        enemies[indexTemp].GetComponent<EnemyBehaviour>().Activate();
    }

    //Обновить изображения врагов в меню
    public void UpdateImages()
    {
        bool[] activatedSliders = new bool[3] {false, false, false };
        int index = 100;
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf)
            {
                switch (enemy.name)
                {
                    case "peasant_red(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 0);
                        activatedSliders[index] = true;
                        break;

                    case "peasant_green(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 1);
                        activatedSliders[index] = true;
                        break;

                    case "peasant_blue(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 2);
                        activatedSliders[index] = true;
                        break;

                    case "peasant_yellow(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 3);
                        activatedSliders[index] = true;
                        break;

                    case "hog(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 4);
                        activatedSliders[index] = true;
                        break;

                    case "hare(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 5);
                        activatedSliders[index] = true;
                        break;

                    case "manticore(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 6);
                        activatedSliders[index] = true;
                        break;

                    case "dryad(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 7);
                        activatedSliders[index] = true;
                        break;

                    case "warrior_1(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 8);
                        activatedSliders[index] = true;
                        break;

                    case "warrior_2(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 9);
                        activatedSliders[index] = true;
                        break;

                    case "warrior_3(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 10);
                        activatedSliders[index] = true;
                        break;

                    case "ent(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 11);
                        activatedSliders[index] = true;
                        break;

                    case "skeleton_1(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 12);
                        activatedSliders[index] = true;
                        break;

                    case "skeleton_2(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 13);
                        activatedSliders[index] = true;
                        break;

                    case "mutant_1(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 14);
                        activatedSliders[index] = true;
                        break;

                    case "mutant_2(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index,15);
                        activatedSliders[index] = true;
                        break;

                    case "necromancer(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 16);
                        activatedSliders[index] = true;
                        break;

                    default:
                        Debug.LogError("AttackMenu.StartAttackMenu(): Undefined enemy!");
                        break;
                }
            }
        }
        for(int i = 0; i< activatedSliders.Length; i ++)
        {
            sliders[i].Trigger(activatedSliders[i]);
        }
    }

    //Изменить изображения лиц в меню
    private void ChangeImage(int sliderNumber, int enemyIndex)
    {
        sliders[sliderNumber].EditHandleImage(enemyPortrets[enemyIndex]);
    }

    //Активировать слайдер
    public void ActivateSlider(int sliderID, int attack)
    {
        Attack current = new Attack();
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf && enemy.GetComponent<EnemyBehaviour>().spawn_point_index == sliderID)
            {
                current.receiver = enemy.name;
                break;
            }
        }

        if (current.receiver != null && ( green_combometer_cells_number[0] || red_combometer_cells_number[0]))
        {
            switch (attack)
            {
                case 0:
                    if (green_combometer_cells_number[0])
                    {
                        RemoveFromCombometer(0);
                        current.attack_name = "attack";
                        StartCoroutine(WaitToDeactivateEnemyHealth(sliderID));
                    }
                    else
                    {
                        Debug.Log("ActivateSlider");
                        DeactivateEnemyHealth(sliderID);
                    }
                    break;

                case 1:
                    if (red_combometer_cells_number[0])
                    {
                        RemoveFromCombometer(1);
                        current.attack_name = "heavy_attack";
                        StartCoroutine(WaitToDeactivateEnemyHealth(sliderID));
                    }
                    else
                    {
                        Debug.Log("ActivateSlider");
                        DeactivateEnemyHealth(sliderID);
                    }
                    break;

                default:
                    DeactivateEnemyHealth(sliderID);
                    break;
            }

            timeOfLatestAttack = Time.time;
            knightBehaviour.Attack(current);

            SetSliderToDefault();
        }
        else
        {
            DeactivateEnemyHealth(sliderID);
        }
    }

    public void ActivateEnemyHealth(int sliderID)
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf && enemy.GetComponent<EnemyBehaviour>().spawn_point_index == sliderID)
            {
                enemy.GetComponent<EnemyBehaviour>().ShowHealth();
                break;
            }
        }
    }

    public IEnumerator WaitToDeactivateEnemyHealth(int id)
    {
        yield return new WaitForSecondsRealtime(timeToDisableHealth);
        DeactivateEnemyHealth(id);
    }

    public void DeactivateEnemyHealth(int sliderID)
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf && enemy.GetComponent<EnemyBehaviour>().spawn_point_index == sliderID)
            {
                enemy.GetComponent<EnemyBehaviour>().HideHealth();
                break;
            }
        }
    }

    //Обнулить слайдер
    private void SetSliderToDefault()
    {
        foreach (SliderScript slider in sliders)
        {
            slider.ToDefault();
        }
    }

    //Добавить точку r комбометру рыцаря
    public void AddToKnight(bool isRed)
    {
        if(!isRed)
        {
            if (green_combometer_cell[combometerNeededPoints - 1] == true)
            {
                for (int y = 0; y < combometerNeededPoints; y++)
                {
                    green_combometer_cell[y] = false;
                }
                knightCombometer.Deactivate(!isRed);
                knightCombometer.ActivateLight(!isRed, true);

                if (green_combometer_cells_number[combometerSize - 1])
                {
                    return;
                }

                if (!green_combometer_cells_number[0])
                {
                    green_combometer_cells_number[0] = true;

                    foreach (SliderScript slider in sliders)
                    {
                        slider.SliderImageAppear();
                    }
                    return;
                }

                if (!green_combometer_cells_number[1])
                {
                    green_combometer_cells_number[1] = true;
                    return;
                }

                if (!green_combometer_cells_number[2])
                {
                    green_combometer_cells_number[2] = true;
                    return;
                }
                return;
            }

            for (int i = 0; i < combometerNeededPoints; i++)
            {
                if (green_combometer_cell[i] == true)
                {
                    continue;
                }
                else
                {
                    green_combometer_cell[i] = true;
                    knightCombometer.Add(!isRed);
                    break;
                }
            }
            return;
        }
        else
        {
            if (red_combometer_cell[combometerNeededPoints - 1] == true)
            { 
                for (int y = 0; y < combometerNeededPoints; y++)
                {
                    red_combometer_cell[y] = false;
                    knightCombometer.Deactivate(!isRed);
                }
                knightCombometer.Deactivate(!isRed);
                knightCombometer.ActivateLight(!isRed, true);

                if (red_combometer_cells_number[combometerSize - 1])
                {
                    return;
                }

                if (!red_combometer_cells_number[0])
                {
                    red_combometer_cells_number[0] = true;

                    foreach (SliderScript slider in sliders)
                    {
                        slider.SliderImageAppear();
                    }
                    return;
                }

                if (!red_combometer_cells_number[1])
                {
                    red_combometer_cells_number[1] = true;
                    return;
                }

                if (!red_combometer_cells_number[2])
                {
                    red_combometer_cells_number[2] = true;
                    return;
                }
                return;
            }

            for (int i = 0; i < combometerNeededPoints; i++)
            {
                if (red_combometer_cell[i] == true)
                {
                    continue;
                }
                else
                {
                    red_combometer_cell[i] = true;
                    knightCombometer.Add(!isRed);
                    break;
                }
            }
            return;
        }
       
    }

    //Убрать очко из комбометра
    private bool RemoveFromCombometer(int point)
    {
        point++;
        Debug.Log("RemoveFromCombometer(" + point + ")");

        switch (point)
        {
            case 1:
                if (!green_combometer_cells_number[0])
                {
                    return false;
                }

                if (green_combometer_cells_number.Length == 3 && green_combometer_cells_number[combometerSize - 1])
                {
                    green_combometer_cells_number[combometerSize - 1] = false;
                    return true;
                }

                if (green_combometer_cells_number.Length == 2 && green_combometer_cells_number[1])
                {
                    green_combometer_cells_number[1] = false;
                    return true;
                }

                if (green_combometer_cells_number[0])
                {
                    Debug.Log("RemoveFromCombometer(" + point + ");");
                    green_combometer_cells_number[0] = false;
                    knightCombometer.ActivateLight(true, false);
                    break;
                }
                return false;

            case 2:
                if (!red_combometer_cells_number[0])
                {
                    return false;
                }

                if (red_combometer_cells_number.Length == 3 && red_combometer_cells_number[combometerSize - 1])
                {
                    red_combometer_cells_number[combometerSize - 1] = false;
                    return true;
                }

                if (red_combometer_cells_number.Length == 2 && red_combometer_cells_number[1])
                {
                    red_combometer_cells_number[1] = false;
                    return true;
                }

                if (red_combometer_cells_number[0])
                {
                    red_combometer_cells_number[0] = false;
                    knightCombometer.ActivateLight(false, false);
                    return true;
                }
                return false;

            default:
                Debug.Log("RemoveFromCombometer(" + point + "): Undefined point!");
                break;
        }
        if (red_combometer_cells_number[0] && green_combometer_cells_number[0])
        {
            foreach (SliderScript slider in sliders)
            {
                slider.SliderImageDisappear();
            }
        }
        return false;
    }

    //Наснести урон врагу
    public bool DealDamageToEnemy(Attack attack)
    {
        int damage;
        cameraManager.JiggleRight();
        if (attack.attack_name == "daze")
        {
            damage = dazeTime;
        }
        else
        {
            damage = swordDamage;
        }
        GameObject.Find(attack.receiver).GetComponent<EnemyBehaviour>().TakeDamage(damage, attack.attack_name);
        return true;
    }

    //Нанести урон рыцарю
    public void DealDamageToKnight(string name, int damage)
    {
        cameraManager.JiggleLeft();
        knightBehaviour.TakeDamage(damage, name);
    }

    //Добавить точку к вражескому комбометру
    public bool AddToEnemyCombometer()
    {
        foreach(GameObject enemy in enemies)
        {
            if(enemy.GetComponent<EnemyBehaviour>().IsCombometerFull() && enemy.activeSelf)
            {
                enemy.GetComponent<EnemyBehaviour>().Attack(new Attack(enemy.name, "attack"));
                return true;
            }
        }
        while (true)
        {
            int rand = Random.Range(0, enemies.Count);
            if (enemies[rand].activeSelf)
            {
                enemies[rand].GetComponent<EnemyBehaviour>().AddToCombometer();
                break;
            }
        }
        return true;
    }

    public void StartEnemiesRunOut()
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyBehaviour>().RuningOut();
        }
    }
}
