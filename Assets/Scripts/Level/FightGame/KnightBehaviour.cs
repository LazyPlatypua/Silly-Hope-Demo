//Класс отвечает за поведение рыцаря
using System.Collections.Generic;   //Подключить списки
using UnityEngine;                  //Подключить классы unity

public class KnightBehaviour : CreatureBehaviour
{
    public static KnightBehaviour instance;         //ссылка на этот скрипт
    public KnightCombometer combometer;             //ссылка на комбометр
    public RhythmManager rhythm_manager;            //ссылка на ритм менеджер

    public Figures figure = null;                   //Фигура для магического меча
    public List<GameObject> swords;                 //список мечей рыцаря

    private Attack current_a = new Attack();        //Текущая атака

    private void Awake()
    {
        instance = this;
    }

    //Установить поведение рыцаря
    public KnightCombometer SetKnightBehaviour(int health, int sword, int size, Figures m_figure)
    {
        foreach(GameObject t_sword in swords)
        {
            t_sword.SetActive(false);
        }

        if(game_manager == null)
        {
            game_manager = GameManager.instance;
        }
        
        if (rhythm_manager == null)
        {
            rhythm_manager = RhythmManager.instance;
        }
        
        if (attack_menu == null)
        {
            attack_menu = AttackMenu.instance;
        }
        
        figure = m_figure;
        current_health = health;
        default_health = health;
        swords[sword].SetActive(true);
        combometer = swords[sword].transform.Find("Knight Combometer").GetComponent<KnightCombometer>();
        combometer.StartCombometer(size);

        return combometer ;
    }

    //Начать атаку
    public override void Attack(Attack a)
    {
        animator.SetBool(a.attack_name, true);
        current_a = a;
    }

    //Точка контакта атаки
    public override void PointOfAttack(string name)
    {
        base.PointOfAttack(name);
        current_a.attack_name = name;
        attack_menu.DealDamageToEnemy(current_a);
        current_a = new Attack();
    }

    //Обновить здоровье рыцаря
    protected override void UpdateHealth(int damage)
    {
        base.UpdateHealth(damage);
        game_manager.UpdateHealthBar(current_health);
    }

    //Убить рыцаря
    protected override void Death()
    {
        game_manager.Defeat();
    }

    //Обнулить все анимации
    protected override void SetAllAnimToFalse()
    {
        animator.SetBool("heavy_attack", false);
        base.SetAllAnimToFalse();
    }

    //Обнулить анимацию
    public override void DeactivateAnimation(string active_trigger)
    {
        base.DeactivateAnimation(active_trigger);
    }

    //Начать анимацию смерти
    protected override void StartDeathAnim()
    {
        combometer.ActivateLight(false, false);
        combometer.ActivateLight(true, false);
        base.StartDeathAnim();
    }
}
