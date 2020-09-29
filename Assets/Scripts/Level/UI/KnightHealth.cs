//Класс отвечает за отображение здоровья рыцаря
using System.Collections.Generic;
using UnityEngine;

public class KnightHealth : MonoBehaviour
{
    public List<GameObject> hearts; //отображение сердец
    
    //Функция обновляет отображение здоровья
    public void UpdateHealth(int health)
    {
        int max = hearts.Count;
        if  (health > max)
        {
            health = max; 
        }

        for (int i = 0; i < health; i ++)
        {
            hearts[i].SetActive(true);
        }
        for (int i = hearts.Count - 1; i > health; i --)
        {
            hearts[i].SetActive(false);
        }
    }
}
