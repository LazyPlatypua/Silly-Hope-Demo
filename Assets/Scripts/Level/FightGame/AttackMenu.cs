﻿//Класс отвечает за меню атак, за комбометры врагов и рыцаря, за спавн врагов
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMenu : MonoBehaviour
{
    public static AttackMenu instance;          //ссылка на это меню
    public KnightBehaviour knight_behaviour;    //сылка на поведение рыцаря
    public KnightCombometer knight_combometer;  //ссылка на комбометр игрока
    public GameManager game_manager;            //ссылка на игровой менеджер
    public Transform main_line_transform;       //трансформ главной линии
    public List<SliderScript> sliders;          //скрипты слайдеров
    public List<Sprite> enemy_sprites;          //портреты врагов
    public List<Sprite> attack_sprites;         //отображени атак
    public int sword_damage;                    //урон меча
    public float timeToDisableHealth = 1f;
    public int daze_time = 2;                   //Время оглушения врагов
    public float time_of_latest_attack = 0f;    //Время последней атаки

    [Header("Fight and Enemies Settings")]
    public List<GameObject> enemies;            //список врагов
    public List<Vector3> enemies_position;      //Позиция врагов на экране
    public float start_running_delta;           //разница между позицией врага и той, с которой он начинает дфижение

    public Animator combometer_animator_green;      //Ссылка на аниматор рыцаря
    public Animator combometer_animator_red;        //Ссылка на аниматор рыцаря
    public int combometer_needed_points;            //количество точек, необходимых для заполнения одной ячейки комбометра
    public int combometer_size;                     //количество ячеек комбометра

    private bool[] green_combometer_cell;           //Какие точки заполнены в одной ячейке зеленого комбметра
    private bool[] green_combometer_cells_number;   //Какие ячейки зеленого комбометра заполнены
    private bool[] red_combometer_cell;             //Какие точки заполнены в одной ячейке красного комбметра  
    private bool[] red_combometer_cells_number;     //Какие ячейки красного комбометра заполнены

    private void Awake()
    {
        instance = this;
    }

    //Запустить меню атак
    public bool StartAttackMenu (int sword_damage_modificator, int size, int needed_points, int sword) 
    {
        if (game_manager == null)
        {
            game_manager = GameManager.instance;
        }
        if(knight_behaviour == null)
        {
            knight_behaviour = KnightBehaviour.instance;
        }
        sword_damage += sword_damage_modificator;

        switch (enemies.Count)
        {
            case 0:
                Debug.LogError("AttackMenu: No Enemies Loaded!");
                break;

            case 1:
                ActivateEnemies(2);
                break;

            case 2:
                for (int i = 1; i < 3; i++)
                    ActivateEnemies(i);
                break;

            default:
                for (int i = 0; i < 3; i++)
                    ActivateEnemies(i);
                break;
        }

        UpdateImages();

        combometer_size = size;
        combometer_needed_points = needed_points;

        green_combometer_cell = new bool[combometer_needed_points];
        red_combometer_cell = new bool[combometer_needed_points];
        for (int i = 0; i < combometer_needed_points; i++)
        {
            green_combometer_cell[i] = false;
            red_combometer_cell[i] = false;
        }

        green_combometer_cells_number = new bool[combometer_size];
        red_combometer_cells_number = new bool[combometer_size];
        for (int i = 0; i < combometer_size; i++)
        {
            green_combometer_cells_number[i] = false;
            red_combometer_cells_number[i] = false;
        }

        Vector3 s = new Vector3(main_line_transform.localScale.x, 0.4f);
        switch(sword)
        {
            case 0:
                sword_damage += 1;
                s.y *= 1;
                break;

            case 1:
                sword_damage += 1;
                s.y *= 0.3f;
                break;

            case 2:
                sword_damage += 1;
                s.y *= 0.5f;
                break;

            case 3:
                sword_damage += 2;
                s.y *= 1.3f;
                break;

            case 4:
                sword_damage += 1;
                s.y *= 0.6f;
                break;

            case 5:
                sword_damage += 1;
                s.y *= 0.4f;
                break;

            case 6:
                sword_damage += 2;
                s.y *= 1.5f;
                break;

            case 7:
                s.y *= 0.6f;
                break;
        }

        main_line_transform.localScale = s;
        return true;
    }

    //Активировать врагов на позиции
    public void ActivateEnemies(int position)
    {
        int death_count_temp = 100;
        int index_temp = 0;
        bool changed = false;
        for (int i =0; i < enemies.Count; i ++)
        {
            if (!enemies[i].activeSelf && enemies[i].GetComponent<EnemyBehaviour>().death_count <= death_count_temp)
            {
                changed = true;
                index_temp = i;
                death_count_temp = enemies[index_temp].GetComponent<EnemyBehaviour>().death_count;
            }
        }
        if(!changed)
        {
            index_temp = position;
        }
        enemies[index_temp].GetComponent<EnemyBehaviour>().spawn_point_index = position;
        enemies[index_temp].GetComponent<EnemyBehaviour>().position = enemies_position[position];
        enemies[index_temp].GetComponent<EnemyBehaviour>().Activate();
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
                    case "peasant_type_1(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 0);
                        activatedSliders[index] = true;
                        break;

                    case "peasant_type_2(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 1);
                        activatedSliders[index] = true;
                        break;

                    case "peasant_type_3(Clone)":
                        index = enemy.GetComponent<EnemyBehaviour>().spawn_point_index;
                        ChangeImage(index, 2);
                        activatedSliders[index] = true;
                        break;

                    case "peasant_type_4(Clone)":
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
    private void ChangeImage(int slider_number, int enemy_index)
    {
        sliders[slider_number].EditHandleImage(enemy_sprites[enemy_index]);
    }

    //Активировать слайдер
    public void ActivateSlider(int slider_id, int attack)
    {
        Attack current = new Attack();
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf && enemy.GetComponent<EnemyBehaviour>().spawn_point_index == slider_id)
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
                        StartCoroutine(WaitToDeactivateEnemyHealth(slider_id));
                    }
                    else
                    {
                        Debug.Log("ActivateSlider");
                        DeactivateEnemyHealth(slider_id);
                    }
                    break;

                case 1:
                    if (red_combometer_cells_number[0])
                    {
                        RemoveFromCombometer(1);
                        current.attack_name = "heavy_attack";
                        StartCoroutine(WaitToDeactivateEnemyHealth(slider_id));
                    }
                    else
                    {
                        Debug.Log("ActivateSlider");
                        DeactivateEnemyHealth(slider_id);
                    }
                    break;

                default:
                    DeactivateEnemyHealth(slider_id);
                    break;
            }

            time_of_latest_attack = Time.time;
            knight_behaviour.Attack(current);

            SetSliderToDefault();
        }
        else
        {
            DeactivateEnemyHealth(slider_id);
        }
    }

    public void ActivateEnemyHealth(int slider_id)
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf && enemy.GetComponent<EnemyBehaviour>().spawn_point_index == slider_id)
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

    public void DeactivateEnemyHealth(int slider_id)
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf && enemy.GetComponent<EnemyBehaviour>().spawn_point_index == slider_id)
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
    public void AddToKnight(bool is_red)
    {
        if(!is_red)
        {
            if (green_combometer_cell[combometer_needed_points - 1] == true)
            {
                for (int y = 0; y < combometer_needed_points; y++)
                {
                    green_combometer_cell[y] = false;
                }
                knight_combometer.Deactivate(!is_red);
                knight_combometer.ActivateLight(!is_red, true);

                if (green_combometer_cells_number[combometer_size - 1])
                {
                    return;
                }

                if (!green_combometer_cells_number[0])
                {
                    PlayFirstCombometerAnimation(1);
                    green_combometer_cells_number[0] = true;
                    return;
                }

                if (!green_combometer_cells_number[1])
                {
                    PlaySecondCombometerAnimation(1);
                    green_combometer_cells_number[1] = true;
                    return;
                }

                if (!green_combometer_cells_number[2])
                {
                    PlayThirdCombometerAnimation(1);
                    green_combometer_cells_number[2] = true;
                    return;
                }
                return;
            }

            for (int i = 0; i < combometer_needed_points; i++)
            {
                if (green_combometer_cell[i] == true)
                {
                    continue;
                }
                else
                {
                    green_combometer_cell[i] = true;
                    knight_combometer.Add(!is_red);
                    break;
                }
            }
            return;
        }
        else
        {
            if (red_combometer_cell[combometer_needed_points - 1] == true)
            { 
                for (int y = 0; y < combometer_needed_points; y++)
                {
                    red_combometer_cell[y] = false;
                    knight_combometer.Deactivate(!is_red);
                }
                knight_combometer.Deactivate(!is_red);
                knight_combometer.ActivateLight(!is_red, true);

                if (red_combometer_cells_number[combometer_size - 1])
                {
                    return;
                }

                if (!red_combometer_cells_number[0])
                {
                    PlayFirstCombometerAnimation(3);
                    red_combometer_cells_number[0] = true;
                    return;
                }

                if (!red_combometer_cells_number[1])
                {
                    PlaySecondCombometerAnimation(3);
                    red_combometer_cells_number[1] = true;
                    return;
                }

                if (!red_combometer_cells_number[2])
                {
                    PlayThirdCombometerAnimation(3);
                    red_combometer_cells_number[2] = true;
                    return;
                }
                return;
            }

            for (int i = 0; i < combometer_needed_points; i++)
            {
                if (red_combometer_cell[i] == true)
                {
                    continue;
                }
                else
                {
                    red_combometer_cell[i] = true;
                    knight_combometer.Add(!is_red);
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

                if (green_combometer_cells_number.Length == 3 && green_combometer_cells_number[combometer_size - 1])
                {
                    green_combometer_cells_number[combometer_size - 1] = false;
                    RePlayThirdCombometerAnimation(1);
                    return true;
                }

                if (green_combometer_cells_number.Length == 2 && green_combometer_cells_number[1])
                {
                    green_combometer_cells_number[1] = false;
                    RePlaySecondCombometerAnimation(1);
                    return true;
                }

                if (green_combometer_cells_number[0])
                {
                    Debug.Log("RemoveFromCombometer(" + point + ");");
                    green_combometer_cells_number[0] = false;
                    RePlayFirstCombometerAnimation(1);
                    knight_combometer.ActivateLight(true, false);
                    break;
                }
                return false;

            case 2:
                if (!red_combometer_cells_number[0])
                {
                    return false;
                }

                if (red_combometer_cells_number.Length == 3 && red_combometer_cells_number[combometer_size - 1])
                {
                    RePlayThirdCombometerAnimation(3);
                    red_combometer_cells_number[combometer_size - 1] = false;
                    return true;
                }

                if (red_combometer_cells_number.Length == 2 && red_combometer_cells_number[1])
                {
                    RePlaySecondCombometerAnimation(3);
                    red_combometer_cells_number[1] = false;
                    return true;
                }

                if (red_combometer_cells_number[0])
                {
                    RePlayFirstCombometerAnimation(3);
                    red_combometer_cells_number[0] = false;
                    knight_combometer.ActivateLight(false, false);
                    return true;
                }
                return false;

            default:
                Debug.Log("RemoveFromCombometer(" + point + "): Undefined point!");
                break;
        }
        return false;
    }

    //Проиграть анимацию первого комбометра
    private void PlayFirstCombometerAnimation(int point)
    {
        switch (point)
        {
            case 1:
                combometer_animator_green.SetBool("start_green", true);
                break;

            case 3:
                combometer_animator_red.SetBool("start_red", true);
                break;

            default:
                Debug.Log("PlayFirstCombometerAnimation(" + point + "): Undefined point!");
                break;
        }
    }

    //Проиграть анимацию первого комбометра назад
    private void RePlayFirstCombometerAnimation(int point)
    {
        Debug.Log("RePlayFirstCombometerAnimation(" + point + ");");
        switch (point)
        {
            case 1:
                combometer_animator_green.SetBool("start_green", false);
                break;

            case 3:
                combometer_animator_red.SetBool("start_red", false);
                break;

            default:
                Debug.Log("RePlayFirstCombometerAnimation(" + point + "): Undefined point!");
                break;
        }
    }

    //Проиграть анимацию второго комбометра
    private void PlaySecondCombometerAnimation(int point)
    {
        switch (point)
        {
            case 1:
                combometer_animator_green.SetBool("continue_green", true);
                break;

            case 3:
                combometer_animator_red.SetBool("continue_red", true);
                break;

            default:
                Debug.Log("PlaySecondCombometerAnimation(" + point + "): Undefined point!");
                break;
        }
    }

    //Проиграть анимацию первого комбометра назад
    private void RePlaySecondCombometerAnimation(int point)
    {
        switch (point)
        {
            case 1:
                combometer_animator_green.SetBool("continue_green", false);
                break;

            case 3:
                combometer_animator_red.SetBool("continue_red", false);
                break;

            default:
                Debug.Log("RePlaySecondCombometerAnimation(" + point + "): Undefined point!");
                break;
        }
    }

    //Проиграть анимацию третьего комбометра
    private void PlayThirdCombometerAnimation(int point)
    {
        switch (point)
        {
            case 1:
                combometer_animator_green.SetBool("finish_green", true);
                break;

            case 3:
                combometer_animator_red.SetBool("finish_red", true);
                break;

            default:
                Debug.Log("PlayThirdCombometerAnimation(" + point + "): Undefined point!");
                break;
        }
    }

    //Проиграть анимацию третьего комбометра назад
    private void RePlayThirdCombometerAnimation(int point)
    {
        switch (point)
        {
            case 1:
                combometer_animator_green.SetBool("finish_green", false);
                break;

            case 3:
                combometer_animator_red.SetBool("finish_red", false);
                break;

            default:
                Debug.Log("RePlayThirdCombometerAnimation(" + point + "): Undefined point!");
                break;
        }
    }

    //Наснести урон врагу
    public bool DealDamageToEnemy(Attack attack)
    {
        int damage;
        if (attack.attack_name == "daze")
        {
            damage = daze_time;
        }
        else
        {
            damage = sword_damage;
        }
        GameObject.Find(attack.receiver).GetComponent<EnemyBehaviour>().TakeDamage(damage, attack.attack_name);
        return true;
    }

    //Нанести урон рыцарю
    public void DealDamageToKnight(string name, int damage)
    {
        knight_behaviour.TakeDamage(damage, name);
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
