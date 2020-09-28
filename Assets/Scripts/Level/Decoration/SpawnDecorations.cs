//Класс создает случайно расположенные случайные декорации.
using System.Collections;                       //Подключить базовые классы с#
using System.Collections.Generic;               //Подключить списки
using UnityEngine;                              //Подключить классы unity

public class SpawnDecorations : MonoBehaviour
{
    public static SpawnDecorations instance;
    public Vector3[] points;                    //2 точки, образующие рамки, в которых будут созданы декорации
    public Vector3[] additional_points;         //Дополнительные точки, отвечающие за номер отображения слоя декорации
    [Range(0.1f, 1f)]
    public float density;                       //Плотность спавна декораций
    bool occupied = false;                      //Заполнена ли область декорациями

    private readonly List<List<Vector3>> occupied_polygons = new List<List<Vector3>>();  //список занимаемых полигонов
    private float t_density;                   //Величина, обратная плотности

    private void Awake()
    {
        instance = this;
    }

    //Функция создает декорации. Принимает список создаваемых декораций
    public void Spawn(List<GameObject> decorations)
    {
        if (decorations.Count < 2)
        {
            return;
        }
        occupied_polygons.Clear();

        t_density = 1 / density;
        for (int i = 0; i < 1000; i++)
        {
            Vector3 n_point = new Vector3(Random.Range(points[0].x, points[1].x), Random.Range(points[1].y, points[0].y), 0.0f);
            occupied = false;
            foreach (List<Vector3> occupied_points in occupied_polygons)
            {
                if (n_point.x <= occupied_points[0].x && n_point.y <= occupied_points[0].y && n_point.x >= occupied_points[1].x && n_point.y >= occupied_points[1].y)
                {
                    occupied = true;
                }
            }
            if (!occupied)
            {
                AddToPolygons(n_point);

                GameObject new_decoration = (GameObject) Instantiate(decorations[Random.Range(0, decorations.Count)], n_point, Quaternion.identity);

                float screen_y_axis_threshold = (Mathf.Abs(points[0].y) + Mathf.Abs(points[1].y))/ 3.0f;

                Debug.Log(screen_y_axis_threshold);

                if (n_point.y >= additional_points[0].y)
                {
                    new_decoration.GetComponent<SpriteRenderer>().sortingOrder = 0;
                }
                else
                {
                    if (n_point.y >= additional_points[1].y)
                    {
                        new_decoration.GetComponent<SpriteRenderer>().sortingOrder = 10;
                    }
                    else
                    {
                        if(n_point.y >= additional_points[2].y )
                        {
                            new_decoration.GetComponent<SpriteRenderer>().sortingOrder = 20;
                        }
                        else
                        {
                            new_decoration.GetComponent<SpriteRenderer>().sortingOrder = 30;
                        }
                    }
                    
                }
            }
        }
    }

    //добавляет точку с декорацией к занимаемым полигонам
    private void AddToPolygons(Vector3 point)
    {
        List<Vector3> polygon = new List<Vector3>
        {
            new Vector3(point.x + t_density, point.y + t_density, 0.0f),
            new Vector3(point.x - t_density, point.y - t_density, 0.0f)
        };
        occupied_polygons.Add(polygon);
    }
}
