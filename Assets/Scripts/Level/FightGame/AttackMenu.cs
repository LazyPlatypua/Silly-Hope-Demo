//Класс отвечает за меню атак, за комбометры врагов и рыцаря, за спавн врагов

using System;
using System.Collections;
using System.Collections.Generic;
using Level.Load_and_Manager;
using Level.UI;
using Scriptable_Objects;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Level.FightGame
{
    [RequireComponent(typeof(GameManager))]
    [RequireComponent(typeof(CameraManager))]
    public class AttackMenu : MonoBehaviour
    {
        public static AttackMenu instance;    
        
        [Header("Links")]
        [Tooltip("Link to knight's behaviour")]
        public KnightBehaviour knightBehaviour;  
        [Tooltip("Link to knight's combometer")]
        public KnightCombometer knightCombometer; 
        [Tooltip("Link to game manager")]
        public GameManager gameManager;   
        [Tooltip("Link to camera manager")]
        public CameraManager cameraManager;
        [Tooltip("Link to green and rad lines transforms")]
        public List<Transform> activeLinesTransforms; 
        [Tooltip("Link to attack buttons")]
        public List<AttackButton> attackButtons;
        [Tooltip("List of enemy's portrets to change on buttons")]
        public List<Sprite> enemyPortrets;

        [Header("Attack Settings")]
        [Tooltip("Amount of damage dealt to enemy with attack")]
        public int swordDamage;
        [Tooltip("Chance of knight hitting someone")]
        public int  hitChance = 100;
        [Tooltip("Time in which enemy's health will be hidden")]
        public float timeToDisableHealth = 1f;
        [Tooltip("Time in which enemy will be unable to function after stun hit")]
        public int dazeTime = 2;
        [Tooltip("Time of latest attack to calculate combos")]
        public float timeOfLatestAttack;

        [Header("Enemies Settings")]
        [Tooltip("List of enemies")]
        public List<EnemyBehaviour> enemies;
        [Tooltip("List of enemy positions on screen")]
        public List<Vector3> enemiesPosition; 
        [Tooltip("Distance between spawn and end position")]
        public float startRunningDelta;          

        [FormerlySerializedAs("combometer_needed_points")] [Header("Combometer Settings")] [Tooltip("Points needed for one cell too fill")]
        public int combometerNeededPoints; 
        [Tooltip("Green combometer cells")]
        private List<CombometerCell> _greenCombometerCell;
        [Tooltip("Red combometer cells")]
        private List<CombometerCell> _redCombometerCell;

        [Header("Combos Settings")]
        [Tooltip("Combo Split Is Available")]
        public bool comboSplitIsAvailable; 
        [Tooltip("Combo Furious Attack Is Available")]
        public bool comboFuriousAttackIsAvailable;
        [Tooltip("Combo Master Stun Is Available")]
        public bool comboMasterStunIsAvailable;
        [Tooltip("Combo FHorizontal Cut Is Available")]
        public bool comboHorizontalCutIsAvailable;
        [Tooltip("Combo Shuffle Is Available")]
        public bool comboShuffleIsAvailable;     
        [Tooltip("Combo Florescence Is Available")]
        public bool comboFlorescenceIsAvailable;         
        [Tooltip("Combo Sublime Dissection Is Available")]
        public bool comboSublimeDissectionIsAvailable;  
        
        private void Awake()
        {
            instance = this;
        }

        //Запустить меню атак
        public bool StartAttackMenu (SwordData swordData, int combometersSize)
        {
            Debug.Log($"AttackMenu.StartAttackMenu({swordData.id}, {combometersSize})");
            
            CheckComponents();
            SetSword(swordData);
            SetEnemies(enemies.Count);
            UpdateImages();
            SetCombometers(combometersSize);
            SetCombos(combometersSize);
            
            return true;
        }

        private void CheckComponents()
        {
            if(knightBehaviour == null)
            {
                knightBehaviour = KnightBehaviour.instance;
            }
            
            if (cameraManager == null)
            {
                cameraManager = GetComponent<CameraManager>();
                
            }
        }

        // Установить настройки меча
        private void SetSword(SwordData swordData)
        {
            Debug.Log($"AttackMenu.SetSword({swordData.id})");
            swordDamage = swordData.damage;
            Vector3 captureLinesSize =
                new Vector3(activeLinesTransforms[1].localScale.x, activeLinesTransforms[1].localScale.y);
            captureLinesSize *= swordData.captureZoneSize;
            foreach (Transform line in activeLinesTransforms)
            {
                line.localScale = captureLinesSize;
            }
        }
        
        // Установить позиции врагов
        private void SetEnemies(int enemiesNumber)
        {
            Debug.Log($"AttackMenu.SetEnemies({enemiesNumber})");
            switch (enemiesNumber)
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
        }

        //Активировать врагов на позиции
        public void ActivateEnemies(int position)
        {
            var deathCountTemp = 100;
            var indexTemp = 0;
            var changed = false;
            for (var i =0; i < enemies.Count; i ++)
            {
                if (!enemies[i].gameObject.activeSelf && enemies[i].deathCount <= deathCountTemp)
                {
                    changed = true;
                    indexTemp = i;
                    deathCountTemp = enemies[indexTemp].deathCount;
                }
            }
            if(!changed)
            {
                indexTemp = position;
            }
            enemies[indexTemp].spawnPointIndex = position;
            enemies[indexTemp].position = enemiesPosition[position];
            enemies[indexTemp].Activate();
        }

        //Обновить изображения врагов в меню
        public void UpdateImages()
        {
            Debug.Log($"AttackMenu.UpdateImages()");
            foreach (var enemy in enemies)
            {
                if (enemy.gameObject.activeSelf)
                {
                    var sliderNumber = 100;
                    switch (enemy.name)
                    {
                        case "peasant_red(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 0);
                            
                            break;

                        case "peasant_green(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 1);
                            
                            break;

                        case "peasant_blue(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 2);
                            
                            break;

                        case "peasant_yellow(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 3);
                            
                            break;

                        case "hog(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 4);
                            
                            break;

                        case "hare(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 5);
                            
                            break;

                        case "manticore(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 6);
                            
                            break;

                        case "dryad(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 7);
                            
                            break;

                        case "warrior_1(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 8);
                            
                            break;

                        case "warrior_2(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 9);
                            
                            break;

                        case "warrior_3(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 10);
                            
                            break;

                        case "ent(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 11);
                            
                            break;

                        case "skeleton_1(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 12);
                            
                            break;

                        case "skeleton_2(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 13);
                            
                            break;

                        case "mutant_1(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 14);
                            
                            break;

                        case "mutant_2(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber,15);
                            
                            break;

                        case "necromancer(Clone)":
                            sliderNumber = enemy.spawnPointIndex;
                            ChangeImage(sliderNumber, 16);
                            
                            break;

                        default:
                            Debug.LogError("AttackMenu.StartAttackMenu(): Undefined enemy!");
                            break;
                    }
                }
            }
        }

        private void SetCombometers(int combometersSize)
        {
            Debug.Log($"AttackMenu.SetCombometers({combometersSize})");
            
            if (combometersSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(combometersSize));
            }

            if (combometersSize > 3)
            {
                combometersSize = 3;
            }
            
            _greenCombometerCell = new List<CombometerCell>();
            _redCombometerCell = new List<CombometerCell>();
            for (var index = 0; index < combometersSize; index++)
            {
                _greenCombometerCell.Add(new CombometerCell(combometerNeededPoints));
                _redCombometerCell.Add(new CombometerCell(combometerNeededPoints));
            }
        }

        private void SetCombos(int combometersSize)
        {
            Debug.Log($"AttackMenu.SetCombos({combometersSize})");
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
        }

        //Изменить изображения лиц в меню контроля атак
        private void ChangeImage(int buttonNumber, int enemyIndex)
        {
            foreach (var aButton in attackButtons)
            {
                if (buttonNumber == aButton.id)
                {
                    aButton.EditImage(enemyPortrets[enemyIndex]);
                }
            }
        }

        //Активировать функцию кнопки атак
        public void ActivateAttackButtons(int attackButtonID, int attack)
        {
            Debug.Log($"AttackMenu.ActivateAttackButtons({attackButtonID}, {attack})");
            
            ActivateEnemyHealth(attackButtonID);
            
            var current = new Attack();
            foreach (var enemy in enemies)
            {
                if (enemy.gameObject.activeSelf && enemy.spawnPointIndex == attackButtonID)
                {
                    current.receiver = enemy.name;
                    break;
                }
            }

            if (current.receiver != null)
            {
                switch (attack)
                {
                    case 0:
                        RemoveFromCombometer(false);
                        current.attackName = "attack";
                        StartCoroutine(WaitToDeactivateEnemyHealth(attackButtonID));
                        
                        DeactivateAttackButtons(false);
                        break;

                    case 1:
                        RemoveFromCombometer(true);
                        current.attackName = "heavy_attack";
                        StartCoroutine(WaitToDeactivateEnemyHealth(attackButtonID));
                        DeactivateAttackButtons(true);
                        break;

                    default:
                        DeactivateEnemyHealth(attackButtonID);
                        break;
                }

                timeOfLatestAttack = Time.time;
                knightBehaviour.Attack(current);

            }
            else
            {
                DeactivateEnemyHealth(attackButtonID);
            }
        }

        public void ActivateEnemyHealth(int buttonID)
        {
            Debug.Log($"AttackMenu.ActivateEnemyHealth({buttonID})");
            foreach (var enemy in enemies)
            {
                if (enemy.gameObject.activeSelf && enemy.spawnPointIndex == buttonID)
                {
                    enemy.ShowHealth();
                    break;
                }
            }
        }

        public IEnumerator WaitToDeactivateEnemyHealth(int id)
        {
            Debug.Log($"AttackMenu.WaitToDeactivateEnemyHealth({id})");
            yield return new WaitForSecondsRealtime(timeToDisableHealth);
            DeactivateEnemyHealth(id);
        }

        public void DeactivateEnemyHealth(int attackButtonID)
        {
            Debug.Log($"AttackMenu.DeactivateEnemyHealth({attackButtonID})");
            foreach (var enemy in enemies)
            {
                if (enemy.gameObject.activeSelf && enemy.spawnPointIndex == attackButtonID)
                {
                    enemy.HideHealth();
                    break;
                }
            }
        }

        //Выключить кнопки атаки
        private void DeactivateAttackButtons(bool isRed)
        {
            Debug.Log($"AttackMenu.DeactivateAttackButtons()");
            foreach (var attackButton in attackButtons)
            {
                if (attackButton.isRed == isRed)
                {
                    attackButton.Deactivate();
                }
            }
        }

        //Добавить точку к комбометру рыцаря
        public void AddToKnight(bool isRed)
        {
            knightCombometer.Add(isRed);
            switch (isRed)
            {
                case true:
                    if (_redCombometerCell != null)
                    {
                        switch (_redCombometerCell.Count)
                        {
                            case 1:
                                Debug.Log($"AttackMenu.AddToKnight(true): Adding point to first red cell.");
                                if (_redCombometerCell[0].AddPoint())
                                {
                                    ActivateAttack(true);
                                }
                                break;

                            case 2:
                                if (_redCombometerCell[0].IsFull())
                                {
                                    Debug.Log($"AttackMenu.AddToKnight(true): Adding point to second red cell.");
                                    _redCombometerCell[1].AddPoint();
                                }
                                else
                                {
                                    Debug.Log($"AttackMenu.AddToKnight(true): Adding point to first red cell.");
                                    if (_redCombometerCell[0].AddPoint())
                                    {
                                        ActivateAttack(true);
                                    }
                                }

                                break;

                            case 3:
                                if (_redCombometerCell[0].IsFull())
                                {
                                    if (_redCombometerCell[1].IsFull())
                                    {
                                        Debug.Log($"AttackMenu.AddToKnight(true): Adding point to third red cell.");
                                        _redCombometerCell[2].AddPoint();
                                    }
                                    else
                                    {
                                        Debug.Log($"AttackMenu.AddToKnight(true): Adding point to second red cell.");
                                        _redCombometerCell[1].AddPoint();
                                    }
                                }
                                else
                                {
                                    Debug.Log($"AttackMenu.AddToKnight(true): Adding point to first red cell.");
                                    if (_redCombometerCell[0].AddPoint())
                                    {
                                        ActivateAttack(true);
                                    }
                                }
                                break;
                        }
                    }
                    break;
                
                case false:
                    if (_greenCombometerCell != null)
                    {
                        switch (_greenCombometerCell.Count)
                        {
                            case 1:
                                Debug.Log($"AttackMenu.AddToKnight(false): Adding point to first green cell.");
                                if (_greenCombometerCell[0].AddPoint())
                                {
                                    ActivateAttack(false);
                                }
                                break;

                            case 2:
                                if (_greenCombometerCell[0].IsFull())
                                {
                                    Debug.Log($"AttackMenu.AddToKnight(false): Adding point to second green cell.");
                                    _greenCombometerCell[1].AddPoint();
                                }
                                else
                                {
                                    Debug.Log($"AttackMenu.AddToKnight(false): Adding point to first green cell.");
                                    if (_greenCombometerCell[0].AddPoint())
                                    {
                                        ActivateAttack(false);
                                    }
                                }

                                break;

                            case 3:
                                if (_greenCombometerCell[0].IsFull())
                                {
                                    if (_greenCombometerCell[1].IsFull())
                                    {
                                        Debug.Log($"AttackMenu.AddToKnight(false): Adding point to third green cell.");
                                        _greenCombometerCell[2].AddPoint();
                                    }
                                    else
                                    {
                                        Debug.Log($"AttackMenu.AddToKnight(false): Adding point to second green cell.");
                                        _greenCombometerCell[1].AddPoint();
                                    }
                                }
                                else
                                {
                                    Debug.Log($"AttackMenu.AddToKnight(false): Adding point to first green cell.");
                                    if (_greenCombometerCell[0].AddPoint())
                                    {
                                        ActivateAttack(false);
                                    }
                                } 
                                break;
                        }
                    }
                    break;
            }
        }

        //Включить кнопки атак
        private void ActivateAttack(bool isRed)
        {
            Debug.Log($"AttackMenu.ActivateAttack({isRed})");
            switch (isRed)
            {
                case true:
                    Debug.Log("Red cell is full. Attack is available");
                    knightCombometer.Deactivate(true);
                    knightCombometer.ActivateLight(true, true);
                    break;
                
                case false:
                    Debug.Log("Green cell is full. Attack is available");
                    knightCombometer.Deactivate(false);
                    knightCombometer.ActivateLight(false, true);
                    break;
            }
            foreach (var attackButton in attackButtons)
            {
                if (attackButton.isRed == isRed)
                {
                    attackButton.Activate();
                }
            }
        }

        //Убрать очко из комбометра
        private void RemoveFromCombometer(bool isRed)
        {
            Debug.Log($"AttackMenu.RemoveFromCombometer({isRed})");
            int size = _greenCombometerCell.Count;
            switch (isRed)
            {
                case false:
                    switch (size)
                    {
                        case 1:
                            _greenCombometerCell[0].SetFalse();
                            break;
                        
                        case 2:
                            if (_greenCombometerCell[2].IsFull())
                            {
                                _greenCombometerCell[1].SetFalse();
                            }
                            break;
                        case 3:
                            if (_greenCombometerCell[size - 1].IsFull())
                            {
                                _greenCombometerCell[size - 1].SetFalse();
                            }
                            else
                            {
                                if (_greenCombometerCell[2].IsFull())
                                {
                                    _greenCombometerCell[1].SetFalse();
                                }
                                else
                                {
                                    _greenCombometerCell[0].SetFalse();
                                }
                            }
                            break;
                    }
                    if (!_greenCombometerCell[0].IsFull())
                    {
                        knightCombometer.ActivateLight(false, false);
                    }

                    break;

                case true:
                    switch (size)
                    {
                        case 1:
                            _redCombometerCell[0].SetFalse();
                            break;
                        
                        case 2:
                            if (_redCombometerCell[2].IsFull())
                            {
                                _redCombometerCell[1].SetFalse();
                            }
                            break;
                        case 3:
                            if (_redCombometerCell[size - 1].IsFull())
                            {
                                _redCombometerCell[size - 1].SetFalse();
                            }
                            else
                            {
                                if (_redCombometerCell[2].IsFull())
                                {
                                    _redCombometerCell[1].SetFalse();
                                }
                                else
                                {
                                    _redCombometerCell[0].SetFalse();
                                }
                            }
                            break;
                    }
                    if (!_redCombometerCell[0].IsFull())
                    {
                        knightCombometer.ActivateLight(true, false);
                    }
                    break;
            }
            
            if (_redCombometerCell[0].IsFull() || _greenCombometerCell[0].IsFull()) return;
            
            foreach (var aButton in attackButtons)
            {
                aButton.Deactivate();
            }
        }

        //Нанести урон врагу
        public bool DealDamageToEnemy(Attack attack)
        {
            Debug.Log($"AttackMenu.DealDamageToEnemy({attack.attackName})");
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
        public void DealDamageToKnight(string attackName, int damage)
        {
            Debug.Log($"AttackMenu.DealDamageToKnight({attackName}, {damage})");
            cameraManager.JiggleLeft();
            knightBehaviour.TakeDamage(damage, attackName);
        }

        //Добавить точку к вражескому комбометру
        public bool AddToEnemyCombometer()
        {
            Debug.Log($"AttackMenu.AddToEnemyCombometer()");
            foreach(var enemy in enemies)
            {
                if(enemy.IsCombometerFull() && enemy.gameObject.activeSelf)
                {
                    enemy.Attack(new Attack(enemy.name, "attack"));
                    return true;
                }
            }
            while (true)
            {
                int rand = Random.Range(0, enemies.Count);
                if (enemies[rand].gameObject.activeSelf)
                {
                    enemies[rand].AddToCombometer();
                    break;
                }
            }
            return true;
        }

        public void StartEnemiesRunOut()
        {
            Debug.Log($"AttackMenu.StartEnemiesRunOut()");
            foreach(var enemy in enemies)
            {
                enemy.RuningOut();
            }
        }
    }
}