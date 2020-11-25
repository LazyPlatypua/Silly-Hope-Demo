//Класс отвечает за слайдер меню атак
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderScript : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    static public bool showed = false;
    public Slider m_slider;         //ссылка на слайдер
    public Image handle_image;      //ссылка на изображение рукоятки
    public Image background_image;  //ссылка на фон слайдера
    public GameObject circle;
    public GameObject waves;
    public Animator animator;
    public AttackMenu attack_menu;  //ссылка на меню атак
    public Color color_left;        //цвет левой части слайдера
    public Color color_right;       //цвет правой части слайдера
    public int id = 0;              //идентификатор слайдера
    public bool is_changed = false;

    //Функция срабатывает при включении сцены раньше Start
    void Awake()
    {
        if(m_slider == null)
        {
            m_slider = gameObject.GetComponent<Slider>();
        }

        if (attack_menu == null)
        {
            attack_menu = AttackMenu.instance;
        }
            
        if (!handle_image || !background_image || !attack_menu)
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
        background_image.color = new Color()
        {
            a = 1f
        };
    }

    //Функция срабатывает при перемещении слайдера
    public void OnDrag(PointerEventData eventData)
    {
        background_image.color = Color.Lerp(color_left, color_right, m_slider.value);
        attack_menu.ActivateEnemyHealth(id);
    }

    //Функция срабатывает при окончании перемещения слайдера
    public void OnEndDrag(PointerEventData data)
    {
        if(!(m_slider.value <= 0.25 || m_slider.value >= 0.75f))
        {
            ToDefault();
            attack_menu.DeactivateEnemyHealth(id);
            return;
        }

        int attack = 2;
        if (m_slider.value <= 0.25f)
        {
            attack = 0;
        }
        if (m_slider.value >= 0.75f)
        {
            attack = 1;
        }
        attack_menu.ActivateSlider(id, attack);

        ToDefault();
    }

    //Функция обнуляет положение рукоятки
    public void ToDefault()
    {
        m_slider.value = 0.5f;
        circle.SetActive(false);
        waves.SetActive(false);
        background_image.color = new Color()
        {
            a = 0f
        };
        SliderImageDisappear();
    }

    //Функция меняет изображение рукоятки
    public void EditHandleImage(Sprite new_image)
    {
        if (new_image != null)
        {
            handle_image.sprite = new_image;
            is_changed = true;
        }
        else
        {
            is_changed = false;
        }
    }

    public void Trigger(bool activate)
    {
        gameObject.SetActive(activate);
    }
}
