using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public TutorialManager instance;
    public GameObject pointPrefab;
    public TextMeshProUGUI instructionsField;
    public TutorialKnight tutorialKnight;
    public TutorialSlider tutorialSlider;
    public KnightCombometer knightCombometer;
    public TutorialEnemy tutorialEnemy;
    public Animator animator;
    public TextMeshProUGUI exitButtonText;
    public GameObject exitButton;
    public SceneLoader sceneLoader;
    public float[] linesXCoord;
    public string[] instructions = new string[5];
    public int timeBetweenPoints = 2;
    public float startPoint = 4f;
    public float endPoint = -2f;
    public int catchedGreenPoints = 0;
    public int catchedRedPoints = 0;
    public bool canGenerate = true;
    public bool redAttackActivated = false;
    public bool greenAttackActivated = false;

    public int combometer_needed_points = 3;            //количество точек, необходимых для заполнения одной ячейки комбометра

    private bool[] green_combometer_cell;           //Какие точки заполнены в одной ячейке зеленого комбметра
    private bool green_combometer_cells_number;   //Какие ячейки зеленого комбометра заполнены
    private bool[] red_combometer_cell;             //Какие точки заполнены в одной ячейке красного комбметра  
    private bool red_combometer_cells_number;     //Какие ячейки красного комбометра заполнены

    public enum State
    {
        points,
        combometer,
        attack,
        enemy,
        exit
    }
    public State current_state;

    private void Awake()
    {
        instance = this;
        canGenerate = false;
        current_state = 0;
        StringSettings temp = new StringSettings(DataHolder.language);
        instructions[0] = temp.tutorial_points;
        instructions[1] = temp.tutorial_combometer;
        instructions[2] = temp.tutorial_attack;
        instructions[3] = temp.tutorial_enemy;
        instructions[4] = temp.tutorial_exit;
        exitButtonText.text = temp.tutorial_end;
        instructionsField.text = instructions[(int)current_state];
        tutorialKnight.gameObject.SetActive(false);
        tutorialEnemy.gameObject.SetActive(false);
        tutorialSlider.gameObject.SetActive(false);
        exitButton.SetActive(false);
        green_combometer_cell = new bool[combometer_needed_points];
        red_combometer_cell = new bool[combometer_needed_points];
        for (int i = 0; i < combometer_needed_points; i++)
        {
            green_combometer_cell[i] = false;
            red_combometer_cell[i] = false;
        }

        green_combometer_cells_number = false; 
        red_combometer_cells_number = false;
        canGenerate = true;
    }

    private void Update()
    {
        if(canGenerate && current_state != State.exit)
        {
            GeneratePoint();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && current_state == State.exit && !exitButton.activeSelf)
        {
            exitButton.SetActive(true);
        }
    }

    private void GeneratePoint()
    {
        GameObject newgo = Instantiate(pointPrefab);
        TutorialPoint newgo_tp = newgo.GetComponent<TutorialPoint>();
        int line= UnityEngine.Random.Range(0, 4);

        newgo.transform.position = new Vector3(linesXCoord[line], startPoint, 0.0f);
        newgo_tp.SetTutorialPoint(this, line >= 2, line, endPoint);
        StartCoroutine(WaitToGenerateNewPoint());
    }

    IEnumerator WaitToGenerateNewPoint()
    {
        canGenerate = false;
        yield return new WaitForSecondsRealtime(timeBetweenPoints);
        canGenerate = true;
    }

    public void AddPoints(bool isRed)
    {
        if (isRed)
        {
            catchedRedPoints++;
        }
        else
        {
            catchedGreenPoints++;
        }
        int catchedPoints = catchedGreenPoints + catchedRedPoints;

        if(current_state == State.points && catchedPoints >= 3)
        {
            catchedRedPoints = 0;
            catchedRedPoints = 0;
            ChangeState();
            return;
        }

        if (current_state == State.combometer && catchedRedPoints >3 && catchedGreenPoints > 3)
        {
            ChangeState();
        }

        if(!(current_state == State.points || current_state == State.exit))
        {
            if (!isRed)
            {
                if (green_combometer_cell[combometer_needed_points - 1] == true)
                {
                    for (int y = 0; y < combometer_needed_points; y++)
                    {
                        green_combometer_cell[y] = false;
                    }
                    knightCombometer.Deactivate(!isRed);
                    knightCombometer.ActivateLight(!isRed, true);

                    if (green_combometer_cells_number)
                    {
                        return;
                    }

                    if (!green_combometer_cells_number)
                    {
                        green_combometer_cells_number = true;
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
                        knightCombometer.Add(!isRed);
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
                        knightCombometer.Deactivate(!isRed);
                    }
                    knightCombometer.Deactivate(!isRed);
                    knightCombometer.ActivateLight(!isRed, true);

                    if (red_combometer_cells_number)
                    {
                        return;
                    }

                    if (!red_combometer_cells_number)
                    {
                        red_combometer_cells_number = true;
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
                        knightCombometer.Add(!isRed);
                        break;
                    }
                }
                return;
            }

        }
    }

    public void AddToEnemy()
    {
        if (current_state == State.enemy)
        {
            tutorialEnemy.AddToCombometer();
        }
    }

    public event Action<int> onRhytmButtonPress;
    public void RhytmButtonPress(int line)
    {
        onRhytmButtonPress?.Invoke(line);
    }

    public void ChangeState()
    {
        current_state++;
        animator.SetTrigger("animate");
        switch (current_state)
        {
            case State.combometer:
                animator.SetBool("knight", true);
                tutorialKnight.gameObject.SetActive(true);
                break;

            case State.attack:
                animator.SetBool("slider", true);
                tutorialSlider.gameObject.SetActive(true);
                break;

            case State.enemy:
                animator.SetBool("enemy", true);
                tutorialEnemy.gameObject.SetActive(true);
                break;

            case State.exit:
                tutorialEnemy.gameObject.SetActive(false);
                tutorialSlider.gameObject.SetActive(false);
                tutorialKnight.animator.speed = 0.1f;
                canGenerate = false;
                break;

        }
    }

    public void ChangeText()
    {
        instructionsField.text = instructions[(int)current_state];
    }

    public void DealDamageToKnight()
    {
        tutorialKnight.TakeDamage();
    }

    public void DealDamageToEnemy(string name)
    {
        tutorialEnemy.TakeDamage(1, name);
    }

    public void ActivateSlider(bool attack)
    {
        switch (current_state)
        {
            case State.attack:
                switch (attack)
                {
                    case true:
                        greenAttackActivated = true;
                        break;

                    case false:
                        redAttackActivated = true;
                        break;                    

                    default:
                        break;
                }
                if (greenAttackActivated && redAttackActivated)
                {
                    ChangeState();
                }
                break;

            case State.enemy:
                switch (attack)
                {
                    case true:
                        if (green_combometer_cells_number)
                        {
                            RemoveFromCombometer(0);
                            tutorialKnight.Attack("attack");
                            knightCombometer.Deactivate(true);
                        }
                        break;

                    case false:
                        if (red_combometer_cells_number)
                        {
                            RemoveFromCombometer(1);
                            tutorialKnight.Attack("heavy_attack");
                            knightCombometer.Deactivate(false);
                        }
                        break;

                    default:
                        break;
                }

                knightCombometer.Deactivate(attack);

                break;

            default:
                break;
        }
    }

    private bool RemoveFromCombometer(int point)
    {
        point++;
        Debug.Log("RemoveFromCombometer(" + point + ")");

        switch (point)
        {
            case 1:
                if (!green_combometer_cells_number)
                {
                    return false;
                }

                if (green_combometer_cells_number)
                {
                    Debug.Log("RemoveFromCombometer(" + point + ");");
                    green_combometer_cells_number = false;
                    knightCombometer.ActivateLight(true, false);
                    break;
                }
                return false;

            case 2:
                if (!red_combometer_cells_number)
                {
                    return false;
                }

                if (red_combometer_cells_number)
                {
                    red_combometer_cells_number = false;
                    knightCombometer.ActivateLight(false, false);
                    return true;
                }
                return false;

            default:
                Debug.Log("RemoveFromCombometer(" + point + "): Undefined point!");
                break;
        }
        return false;
    }

    public void EndTutorial()
    {
        DataHolder.current_scene = 0;     //Текущая сцена
        DataHolder.current_weapon = 0;    //текущиее оружее
        DataHolder.current_armor = 0;     //Текущая броня
        DataHolder.current_charm_0 = 0;   //текущий первый талисман
        DataHolder.current_charm_1 = 0;   //текущий второй талисман
        DataHolder.current_charm_2 = 0;   //текущий третий талисман
        DataHolder.combometer_size = 1;   //Текущий размер комбометра
        DataHolder.best_score = 0;    //Лучший результат
        DataHolder.black_ink = 0;     //Количество чернил
        DataHolder.language = 0;      //Текущий язык
        DataHolder.graphics_tier = 0; //Уровень графики
        DataHolder.master_volume = 0.5f; //Общая громкость игры
        DataHolder.music_volume = 0.5f;  //Громкость музыки
        DataHolder.sfx_volume = 0.5f;    //Громкость звуковых эффектов
        DataHolder.from_level = false;  //это данные с уровня?
        sceneLoader.SceneLoad("Level");
    }
}
