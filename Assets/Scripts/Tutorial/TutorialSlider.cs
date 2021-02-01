using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialSlider : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public TutorialManager tutorialManager;
    public Slider mSlider;         //ссылка на слайдер
    public Image backgroundImage;  //ссылка на фон слайдера
    public Color colorLeft;        //цвет левой части слайдера
    public Color colorRight;       //цвет правой части слайдера

    public void OnBeginDrag(PointerEventData eventData)
    {
        backgroundImage.color = new Color()
        {
            a = 1f
        };
    }

    //Функция срабатывает при перемещении слайдера
    public void OnDrag(PointerEventData eventData)
    {
        backgroundImage.color = Color.Lerp(colorLeft, colorRight, mSlider.value);
        tutorialManager.tutorialEnemy.ShowHealth();
    }

    //Функция срабатывает при окончании перемещения слайдера
    public void OnEndDrag(PointerEventData data)
    {
        if (!(mSlider.value <= 0.25 || mSlider.value >= 0.75f))
        {
            ToDefault();
            tutorialManager.tutorialEnemy.HideHealth();

            return;
        }

        if(mSlider.value <= 0.25f || mSlider.value >= 0.75f)
        {
            bool attack = true;
            if (mSlider.value <= 0.25f)
            {
                attack = true;  //зеленый
            }
            if (mSlider.value >= 0.75f)
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
        mSlider.value = 0.5f;
        backgroundImage.color = new Color()
        {
            a = 0f
        };
    }
}
