//Класс отвечает за комбометры врагов. 
//using System.Collections;   //Подключить базовые классы с#
//using UnityEngine;  //Подключить классы unity

//public class ComboMeter : MonoBehaviour
//{
//    [Range(2, 6)]                           //размер комбометра больше 2 и не превышает 6
//    public int size = 2;                    //размер комбометра

//    public EnemyBehaviour enemy_behaviour;  //ссылка на поведение врага
//    public GameObject[] cells_2;            //ссылка на ячейки комбометра с количеством ячеек 2
//    public GameObject[] cells_3;            //ссылка на ячейки комбометра с количеством ячеек 3
//    public GameObject[] cells_4;            //ссылка на ячейки комбометра с количеством ячеек 4
//    public GameObject[] cells_5;            //ссылка на ячейки комбометра с количеством ячеек 5
//    public GameObject[] cells_6;            //ссылка на ячейки комбометра с количеством ячеек 6

//    private GameObject[] cells;             //переменная для хранения ячеек
//    public int currently_filled = 0;        //количество заполненных ячеек

//    //Функция выполняется при запуске сцены
//    private void Start() 
//    {
//        if (enemy_behaviour == null)    //проверка на наличие ссылки на поведение врага
//        {
//            Debug.LogError("ComboMeter.Start():EnemyBehaviour is missing!");
//        }
//        else
//        {
//            enemy_behaviour.combo_meter = this; //если найдено, передать ему ссылку на этот объект
//        }
        
//        foreach(GameObject cell in cells_2)
//        {
//            cell.SetActive(false);
//        }
//        foreach(GameObject cell in cells_3)
//        {
//            cell.SetActive(false);
//        }
//        foreach(GameObject cell in cells_4)
//        {
//            cell.SetActive(false);
//        }
//        foreach(GameObject cell in cells_5)
//        {
//            cell.SetActive(false);
//        }
//        foreach(GameObject cell in cells_6)
//        {
//            cell.SetActive(false);
//        }

//        UpdateCells();
//    }

//    //функция устанавливает настройки комбометра.
//    public void SetCombometer(int t_size)
//    {
//        size = t_size;
        
//        switch (size)
//        {
//            case 2:
//                cells = cells_2;
//            break;

//            case 3:
//                cells = cells_3;
//            break;

//            case 4:
//                cells = cells_4;
//            break;

//            case 5:
//                cells = cells_5;
//            break;

//            case 6:
//                cells = cells_6;
//            break;

//            default:
//                Debug.LogError("ComboMeter.Awake(): unknown size variable!");
//            break;
//        }

//        Deactivate();
//        UpdateCells();
//    }

//    //функция добавляет очки к комбометру
//    public void Add()
//    {
//        currently_filled ++;
//        UpdateCells();
//    }

//    //функция убирает очки из комбометра
//    public void Remove()
//    {
//        if (currently_filled <= 1)
//        {
//            currently_filled = 0;
//        }
//        else
//        {
//            currently_filled --;
//        }
        
//        cells[currently_filled - 1].SetActive(false);
//        UpdateCells();
//    }

//    //функция обнуляет комбометр
//    public void Deactivate()
//    {
//        foreach (GameObject cell in cells)
//        {
//            cell.SetActive(false);
//        }

//        currently_filled = 0;
//        UpdateCells();
//    }

//    //Обновить зображения комбометра
//    public bool UpdateCells()
//    {
//        if (currently_filled > 0)
//        {
//            for(int i = 0; i < currently_filled; i++)
//            {
//                cells[i].SetActive(true);
//            }
//        }
//        if (currently_filled >= size)
//        {
//            return true;
//        }
//        return false;
//    }
//}
