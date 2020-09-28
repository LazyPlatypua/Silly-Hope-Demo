using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialSlider : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public TutorialManager tutorialManager;
    public Slider m_slider;         //ссылка на слайдер
    public Image background_image;  //ссылка на фон слайдера
    public Color color_left;        //цвет левой части слайдера
    public Color color_right;       //цвет правой части слайдера

    public void OnBeginDrag(PointerEventData eventData)
    {
        background_image.color = new Color()
        {
            a = 1f
        };
    }

    //Функция срабатывает при перемещении слайдера
    public void OnDrag(PointerEventData eventData)
    {
        background_image.color = Color.Lerp(color_left, color_right, m_slider.value);
        tutorialManager.tutorialEnemy.ShowHealth();
    }

    //Функция срабатывает при окончании перемещения слайдера
    public void OnEndDrag(PointerEventData data)
    {
        if (!(m_slider.value <= 0.25 || m_slider.value >= 0.75f))
        {
            ToDefault();
            tutorialManager.tutorialEnemy.HideHealth();

            return;
        }

        if(m_slider.value <= 0.25f || m_slider.value >= 0.75f)
        {
            bool attack = true;
            if (m_slider.value <= 0.25f)
            {
                attack = true;  //зеленый
            }
            if (m_slider.value >= 0.75f)
            {
                attack = false; //красный
            }
            tutorialManager.ActivateSlider(attack);
        }

        ToDefault();
    }

    //Функция обнуляет положение рукоятки
    public void ToDefault()
    {
        m_slider.value = 0.5f;
        background_image.color = new Color()
        {
            a = 0f
        };
    }
}
