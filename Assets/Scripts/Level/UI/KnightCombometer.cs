//Класс отвечает за комбометр рыцаря
using UnityEngine;

public class KnightCombometer : MonoBehaviour
{
    public GameObject[] cellsGreen;    //Массив ячеек зеленого цвета
    public GameObject[] cellsRed;      //Массив ячеек крсного цвета
    public GameObject greenFlame;      //Ссылка на свет зеленого цвета
    public GameObject redFlame;        //Ссылка на свет красного цвета

    public int currentlyFilledGreen;  //Количество заполненных зеленых ячеек
    public int currentlyFilledRed;    //Количество заполненных красныч ячеек
    public int size;                    //Размер комбометра

    public KnightBehaviour knightBehaviour;    //Ссылка на поведение рыцаря

    //Устновить комбометр
    public void StartCombometer(int size)
    {
        this.size = size;

        if (knightBehaviour == null)    //проверка на наличие ссылки на поведение врага
        {
            Debug.Log("KnightCombometer.Start(): KnightBehaviour is missing!");
            //knight_behaviour = GameObject.Find("knight(Clone)").GetComponent<KnightBehaviour>();
        }

        foreach (GameObject cell in cellsGreen)
        {
            cell.SetActive(false);
        }
        foreach (GameObject cell in cellsRed)
        {
            cell.SetActive(false);
        }

        greenFlame.SetActive(false);
        redFlame.SetActive(false);
    }

    //Обновить ячейки
    public bool UpdateCells()
    {
        if (currentlyFilledRed > 0)
        {
            for (int i = 0; i < currentlyFilledRed; i++)
            {
                cellsRed[i].SetActive(true);
            }
        }

        if (currentlyFilledGreen > 0)
        {
            for (int i = 0; i < currentlyFilledGreen; i++)
            {
                cellsGreen[i].SetActive(true);
            }
        }

        if (currentlyFilledRed >= size || currentlyFilledGreen >= size)
        {
            return true;
        }
        return false;
    }

    //функция добавляет очки к комбометру
    public void Add(bool isRed)
    {
        if(!isRed)
        {
            currentlyFilledGreen++;
            if (currentlyFilledGreen > size)
                currentlyFilledGreen = size;
        }
        else
        {
            currentlyFilledRed++;
            if (currentlyFilledRed > size)
                currentlyFilledRed = size;
        }
        
        UpdateCells();
    }

    //функция обнуляет комбометр
    public void Deactivate(bool isRed)
    {
        if(!isRed)
        {
            foreach (GameObject cell in cellsGreen)
            {
                cell.SetActive(false);
            }
            currentlyFilledGreen = 0;
        }
        else
        {
            foreach (GameObject cell in cellsRed)
            {
                cell.SetActive(false);
            }
            currentlyFilledRed = 0;
        }
        UpdateCells();

    }

    //Включить свет из оружия
    public void ActivateLight(bool isRed, bool activate)
    {
        if(!isRed)
        {
            greenFlame.SetActive(activate);
        }
        else
        {
            redFlame.SetActive(activate);
        }
    }
}
