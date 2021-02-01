//Класс отвечает за слайдер меню атак

using Level.FightGame;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    static public bool showed = false;
    public Slider slider;         //ссылка на слайдер
    public Image handleImage;      //ссылка на изображение рукоятки
    public Image backgroundImage;  //ссылка на фон слайдера
    public GameObject circle;
    public GameObject waves;
    public Animator animator;
    public AttackMenu attackMenu;  //ссылка на меню атак
    public Color colorLeft;        //цвет левой части слайдера
    public Color colorRight;       //цвет правой части слайдера
    public int id = 0;              //идентификатор слайдера
    public bool isChanged = false;

    //Функция срабатывает при включении сцены раньше Start
    void Awake()
    {
        if(slider == null)
        {
            slider = gameObject.GetComponent<Slider>();
        }

        if (attackMenu == null)
        {
            attackMenu = AttackMenu.instance;
        }
            
        if (!handleImage || !backgroundImage || !attackMenu)
        {
            Debug.LogError("Components are missing!");
        }
        ToDefault();
    }

    public void SliderImageAppear()
    {
        animator.SetBool("activate", true);
        showed = true;
    }

    public void SliderImageDisappear()
    {
        animator.SetBool("activate", false);
        showed = false;
    }

    //Функция срабатывает при начале перемещения слайдера
    public void OnBeginDrag(PointerEventData eventData)
    {
        animator.speed = PointBehaviour.beat_tempo / 60;
        circle.SetActive(true);
        waves.SetActive(true);
        backgroundImage.color = new Color()
        {
            a = 1f
        };
    }

    //Функция срабатывает при перемещении слайдера
    public void OnDrag(PointerEventData eventData)
    {
        backgroundImage.color = Color.Lerp(colorLeft, colorRight, slider.value);
        attackMenu.ActivateEnemyHealth(id);
    }

    //Функция срабатывает при окончании перемещения слайдера
    public void OnEndDrag(PointerEventData data)
    {
        if(!(slider.value <= 0.25 || slider.value >= 0.75f))
        {
            ToDefault();
            attackMenu.DeactivateEnemyHealth(id);
            return;
        }

        int attack = 2;
        if (slider.value <= 0.25f)
        {
            attack = 0;
        }
        if (slider.value >= 0.75f)
        {
            attack = 1;
        }
        attackMenu.ActivateSlider(id, attack);

        ToDefault();
    }

    //Функция обнуляет положение рукоятки
    public void ToDefault()
    {
        slider.value = 0.5f;
        circle.SetActive(false);
        waves.SetActive(false);
        backgroundImage.color = new Color()
        {
            a = 0f
        };
        SliderImageDisappear();
    }

    //Функция меняет изображение рукоятки
    public void EditHandleImage(Sprite newImage)
    {
        if (newImage != null)
        {
            handleImage.sprite = newImage;
            isChanged = true;
        }
        else
        {
            isChanged = false;
        }
    }

    public void Trigger(bool activate)
    {
        gameObject.SetActive(activate);
    }
}
