//Класс отвечает за меню атак, за комбометры врагов и рыцаря, за спавн врагов

using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Level.Load_and_Manager;
using Scriptable_Objects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Level.FightGame
{
    public struct CombometerCell
    {
        private bool isFull;
        private bool[] combometerPoints;

        public CombometerCell(int combometerNeededPoints)
        {
            isFull = false;
            combometerPoints = new bool[combometerNeededPoints];
            for (var index = 0; index < combometerPoints.Length; index++)
            {
                combometerPoints[index] = false;
            }
        }

        public bool IsFull()
        {
            return isFull;
        }

        public bool AddPoint()
        {
            for (var index = 0; index < combometerPoints.Length; index++)
            {
                if (!combometerPoints[index])
                {
                    combometerPoints[index] = true;
                    return isFull;
                }
            }
            DeletePoints();
            isFull = true;
            return isFull;
        }

        private void DeletePoints()
        {
            for (var index = 0; index < combometerPoints.Length; index++)
            {
                combometerPoints[index] = false;
            }
        }

        public void SetFalse()
        {
            isFull = false;
        }
    }

    [RequireComponent(typeof(GameManager))]
    [RequireComponent(typeof(CameraManager))]
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
        public int  hitChance = 100;
        public float timeToDisableHealth = 1f;
        public int dazeTime = 2;                   //Время оглушения врагов
        public float timeOfLatestAttack = 0f;    //Время последней атаки

        [Header("Enemies Settings")]
        public List<GameObject> enemies;            //список врагов
        public List<Vector3> enemiesPosition;      //Позиция врагов на экране
        public float startRunningDelta;           //разница между позицией врага и той, с которой он начинает дфижение

        [FormerlySerializedAs("combometer_needed_points")] [Header("Combometer Settings")]
        public int combometerNeededPoints;            //количество точек, необходимых для заполнения одной ячейки комбометра

        private List<CombometerCell> greenCombometerCell;           //Какие точки заполнены в одной ячейке зеленого комбметра
        private List<CombometerCell> redCombometerCell;             //Какие точки заполнены в одной ячейке красного комбметра  

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
        public bool StartAttackMenu (SwordData swordData, int combometersSize)
        {
            greenCombometerCell = new List<CombometerCell>();
            redCombometerCell = new List<CombometerCell>();
            
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

            for (var index = 0; index < combometersSize; index++)
            {
                greenCombometerCell.Add(new CombometerCell(combometerNeededPoints));
                redCombometerCell.Add(new CombometerCell(combometerNeededPoints));
            }

            switch (combometersSize)
            {
                case 2:
                    comboSplitIsAvailable = true;               //Доступно ли комбо разрыва
                    comboFuriousAttackIsAvailable = true;     //Доступно ли комбо яростной атаки
                    comboMasterStunIsAvailable = true;         //Доступно ли комбо мастерское оглушение
                    comboHorizontalCutIsAvailable = true;      //Доступно ли комбо горизонтального разреза
                    comboShuffleIsAvailable = true;             //Доступно ли комбо перетасовки
                    comboFlorescenceIsAvailable = true;         //Доступно ли комбо расцвета
                    comboSublimeDissectionIsAvailable = true;  //Доступно ли комбо грандиозного рассчения
                    break;
                case 3: 
                    comboSplitIsAvailable = true;               //Доступно ли комбо разрыва
                    comboFuriousAttackIsAvailable = true;     //Доступно ли комбо яростной атаки
                    comboMasterStunIsAvailable = true;         //Доступно ли комбо мастерское оглушение
                    comboHorizontalCutIsAvailable = false;      //Доступно ли комбо горизонтального разреза
                    comboShuffleIsAvailable = false;             //Доступно ли комбо перетасовки
                    comboFlorescenceIsAvailable = false;         //Доступно ли комбо расцвета
                    comboSublimeDissectionIsAvailable = false;  //Доступно ли комбо грандиозного рассчения
                    break;
                default:
                    comboSplitIsAvailable = true;               //Доступно ли комбо разрыва
                    comboFuriousAttackIsAvailable = true;     //Доступно ли комбо яростной атаки
                    comboMasterStunIsAvailable = true;         //Доступно ли комбо мастерское оглушение
                    comboHorizontalCutIsAvailable = true;      //Доступно ли комбо горизонтального разреза
                    comboShuffleIsAvailable = true;             //Доступно ли комбо перетасовки
                    comboFlorescenceIsAvailable = true;         //Доступно ли комбо расцвета
                    comboSublimeDissectionIsAvailable = true;  //Доступно ли комбо грандиозного рассчения
                    break;
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
                if (!enemies[i].activeSelf && enemies[i].GetComponent<EnemyBehaviour>().deathCount <= deathCountTemp)
                {
                    changed = true;
                    indexTemp = i;
                    deathCountTemp = enemies[indexTemp].GetComponent<EnemyBehaviour>().deathCount;
                }
            }
            if(!changed)
            {
                indexTemp = position;
            }
            enemies[indexTemp].GetComponent<EnemyBehaviour>().spawnPointIndex = position;
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
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 0);
                            activatedSliders[index] = true;
                            break;

                        case "peasant_green(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 1);
                            activatedSliders[index] = true;
                            break;

                        case "peasant_blue(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 2);
                            activatedSliders[index] = true;
                            break;

                        case "peasant_yellow(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 3);
                            activatedSliders[index] = true;
                            break;

                        case "hog(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 4);
                            activatedSliders[index] = true;
                            break;

                        case "hare(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 5);
                            activatedSliders[index] = true;
                            break;

                        case "manticore(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 6);
                            activatedSliders[index] = true;
                            break;

                        case "dryad(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 7);
                            activatedSliders[index] = true;
                            break;

                        case "warrior_1(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 8);
                            activatedSliders[index] = true;
                            break;

                        case "warrior_2(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 9);
                            activatedSliders[index] = true;
                            break;

                        case "warrior_3(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 10);
                            activatedSliders[index] = true;
                            break;

                        case "ent(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 11);
                            activatedSliders[index] = true;
                            break;

                        case "skeleton_1(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 12);
                            activatedSliders[index] = true;
                            break;

                        case "skeleton_2(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 13);
                            activatedSliders[index] = true;
                            break;

                        case "mutant_1(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index, 14);
                            activatedSliders[index] = true;
                            break;

                        case "mutant_2(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
                            ChangeImage(index,15);
                            activatedSliders[index] = true;
                            break;

                        case "necromancer(Clone)":
                            index = enemy.GetComponent<EnemyBehaviour>().spawnPointIndex;
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
                if (enemy.activeSelf && enemy.GetComponent<EnemyBehaviour>().spawnPointIndex == sliderID)
                {
                    current.receiver = enemy.name;
                    break;
                }
            }

            if (current.receiver != null && ( greenCombometerCell[0].IsFull() || redCombometerCell[0].IsFull()))
            {
                switch (attack)
                {
                    case 0:
                        if (greenCombometerCell[0].IsFull())
                        {
                            RemoveFromCombometer(0);
                            current.attackName = "attack";
                            StartCoroutine(WaitToDeactivateEnemyHealth(sliderID));
                        }
                        else
                        {
                            Debug.Log("ActivateSlider");
                            DeactivateEnemyHealth(sliderID);
                        }
                        break;

                    case 1:
                        if (redCombometerCell[0].IsFull())
                        {
                            RemoveFromCombometer(1);
                            current.attackName = "heavy_attack";
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
                if (enemy.activeSelf && enemy.GetComponent<EnemyBehaviour>().spawnPointIndex == sliderID)
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
                if (enemy.activeSelf && enemy.GetComponent<EnemyBehaviour>().spawnPointIndex == sliderID)
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
            knightCombometer.Add(!isRed);
            switch (isRed)
            {
                case true:
                    if (redCombometerCell != null)
                    {
                        switch (redCombometerCell.Count)
                        {
                            case 1:
                                redCombometerCell[0].AddPoint();
                                break;

                            case 2:
                                if (redCombometerCell[0].IsFull())
                                {
                                    redCombometerCell[1].AddPoint();
                                }
                                else
                                {
                                    redCombometerCell[0].AddPoint();
                                }

                                break;

                            case 3:
                                if (redCombometerCell[0].IsFull())
                                {
                                    if (redCombometerCell[1].IsFull())
                                    {
                                        redCombometerCell[2].AddPoint();
                                    }
                                    else
                                    {
                                        redCombometerCell[1].AddPoint();
                                    }
                                }
                                else
                                {
                                    redCombometerCell[0].AddPoint();
                                }
                                break;
                        }

                        if (redCombometerCell[0].IsFull())
                        {
                            knightCombometer.Deactivate(true);
                            knightCombometer.ActivateLight(true, true);
                            foreach (SliderScript slider in sliders)
                            {
                                slider.SliderImageAppear();
                            }
                            return;
                        }
                    }
                    break;
                
                case false:
                    if (greenCombometerCell != null)
                    {
                        switch (greenCombometerCell.Count)
                        {
                            case 1:
                                greenCombometerCell[0].AddPoint();
                                break;

                            case 2:
                                if (greenCombometerCell[0].IsFull())
                                {
                                    greenCombometerCell[1].AddPoint();
                                }
                                else
                                {
                                    greenCombometerCell[0].AddPoint();
                                }

                                break;

                            case 3:
                                if (greenCombometerCell[0].IsFull())
                                {
                                    if (greenCombometerCell[1].IsFull())
                                    {
                                        greenCombometerCell[2].AddPoint();
                                    }
                                    else
                                    {
                                        greenCombometerCell[1].AddPoint();
                                    }
                                }
                                else
                                {
                                    greenCombometerCell[0].AddPoint();
                                }
                                break;
                        }

                        if (greenCombometerCell[0].IsFull())
                        {
                            knightCombometer.Deactivate(false);
                            knightCombometer.ActivateLight(false, true);
                            foreach (SliderScript slider in sliders)
                            {
                                slider.SliderImageAppear();
                            }
                            return;
                        }
                    }

                    break;
            }
        }

        //Убрать очко из комбометра
        private bool RemoveFromCombometer(int point)
        {
            point++;
            Debug.Log("RemoveFromCombometer(" + point + ")");
            int size = greenCombometerCell.Count;
            switch (point)
            {
                case 1:
                    if (!greenCombometerCell[0].IsFull())
                    {
                        return false;
                    }

                    switch (size)
                    {
                        case 1:
                            greenCombometerCell[0].SetFalse();
                            knightCombometer.ActivateLight(false, false);
                            break;
                        
                        case 2:
                            if (greenCombometerCell[2].IsFull())
                            {
                                greenCombometerCell[1].SetFalse();
                            }
                            break;
                        case 3:
                            if (greenCombometerCell[size - 1].IsFull())
                            {
                                greenCombometerCell[size - 1].SetFalse();
                            }
                            else
                            {
                                if (greenCombometerCell[2].IsFull())
                                {
                                    greenCombometerCell[1].SetFalse();
                                }
                                else
                                {
                                    greenCombometerCell[0].SetFalse();
                                    knightCombometer.ActivateLight(false, false);
                                }
                            }
                            break;
                    }

                    break;

                case 2:
                    if (!redCombometerCell[0].IsFull())
                    {
                        return false;
                    }

                    switch (size)
                    {
                        case 1:
                            redCombometerCell[0].SetFalse();
                            knightCombometer.ActivateLight(true, false);
                            break;
                        
                        case 2:
                            if (redCombometerCell[2].IsFull())
                            {
                                redCombometerCell[1].SetFalse();
                            }
                            break;
                        case 3:
                            if (redCombometerCell[size - 1].IsFull())
                            {
                                redCombometerCell[size - 1].SetFalse();
                            }
                            else
                            {
                                if (redCombometerCell[2].IsFull())
                                {
                                    redCombometerCell[1].SetFalse();
                                }
                                else
                                {
                                    redCombometerCell[0].SetFalse();
                                    knightCombometer.ActivateLight(true, false);
                                }
                            }
                            break;
                    }

                    break;

                default:
                    Debug.Log("RemoveFromCombometer(" + point + "): Undefined point!");
                    break;
            }

            if (redCombometerCell[0].IsFull() || greenCombometerCell[0].IsFull()) return false;
            foreach (SliderScript slider in sliders)
            {
                slider.SliderImageDisappear();
            }
            return true;
        }

        //Наснести урон врагу
        public bool DealDamageToEnemy(Attack attack)
        {
            int damage;
            cameraManager.JiggleRight();
            if (attack.attackName == "daze")
            {
                damage = dazeTime;
            }
            else
            {
                damage = swordDamage;
            }
            GameObject.Find(attack.receiver).GetComponent<EnemyBehaviour>().TakeDamage(damage, attack.attackName);
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
}