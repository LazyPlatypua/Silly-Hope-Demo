//Класс отвечает за комбометр рыцаря
using UnityEngine;

public class KnightCombometer : MonoBehaviour
{
    public GameObject[] cells_green;    //Массив ячеек зеленого цвета
    public GameObject[] cells_red;      //Массив ячеек крсного цвета
    public GameObject light_green;      //Ссылка на свет зеленого цвета
    public GameObject light_red;        //Ссылка на свет красного цвета

    public int currently_filled_green;  //Количество заполненных зеленых ячеек
    public int currently_filled_red;    //Количество заполненных красныч ячеек
    public int size;                    //Размер комбометра

    public KnightBehaviour knight_behaviour;    //Ссылка на поведение рыцаря

    //Устновить комбометр
    public void StartCombometer(int size)
    {
        this.size = size;

        if (knight_behaviour == null)    //проверка на наличие ссылки на поведение врага
        {
            Debug.Log("KnightCombometer.Start(): KnightBehaviour is missing!");
            //knight_behaviour = GameObject.Find("knight(Clone)").GetComponent<KnightBehaviour>();
        }

        foreach (GameObject cell in cells_green)
        {
            cell.SetActive(false);
        }
        foreach (GameObject cell in cells_red)
        {
            cell.SetActive(false);
        }

        light_green.SetActive(false);
        light_red.SetActive(false);
    }

    //Обновить ячейки
    public bool UpdateCells()
    {
        if (currently_filled_red > 0)
        {
            for (int i = 0; i < currently_filled_red; i++)
            {
                cells_red[i].SetActive(true);
            }
        }

        if (currently_filled_green > 0)
        {
            for (int i = 0; i < currently_filled_green; i++)
            {
                cells_green[i].SetActive(true);
            }
        }

        if (currently_filled_red >= size || currently_filled_green >= size)
        {
            return true;
        }
        return false;
    }

    //функция добавляет очки к комбометру
    public void Add(bool is_green)
    {
        if(is_green)
        {
            currently_filled_green++;
        }
        else
        {
            currently_filled_red++;
        }
        
        UpdateCells();
    }

    //функция обнуляет комбометр
    public void Deactivate(bool is_green)
    {
        if(is_green)
        {
            foreach (GameObject cell in cells_green)
            {
                cell.SetActive(false);
            }
            currently_filled_green = 0;
        }
        else
        {
            foreach (GameObject cell in cells_red)
            {
                cell.SetActive(false);
            }
            currently_filled_red = 0;
        }
        UpdateCells();

    }

    //Включить свет из оружия
    public void ActivateLight(bool is_green, bool activate)
    {
        if(is_green)
        {
            light_green.SetActive(activate);
        }
        else
        {
            light_red.SetActive(activate);
        }
    }
}
