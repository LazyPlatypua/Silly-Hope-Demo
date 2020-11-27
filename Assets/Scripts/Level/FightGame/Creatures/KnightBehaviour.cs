using System.Collections.Generic;
using Level.Load_and_Manager;
using Save_System;
using UnityEngine;


public class KnightBehaviour : CreatureBehaviour
{
    public static KnightBehaviour instance;         //ссылка на этот скрипт
    public KnightCombometer combometer;             //ссылка на комбометр
    public RhythmManager rhythmManager;            //ссылка на ритм менеджер

    public List<GameObject> swords;                 //список мечей рыцаря

    private Attack current_a;        //Текущая атака

    private void Awake()
    {
        instance = this;
    }

    //Установить поведение рыцаря
    public void SetKnightBehaviour(int health, SwordData swordData, int size)
    {
        foreach(GameObject sword in swords)
        {
            sword.SetActive(false);
        }

        if(game_manager == null)
        {
            game_manager = GameManager.instance;
        }
        
        if (rhythmManager == null)
        {
            rhythmManager = RhythmManager.instance;
        }
        
        if (attack_menu == null)
        {
            attack_menu = AttackMenu.instance;
        }
        
        current_health = health;
        default_health = health;
        
        GameObject currentSword = swords[swordData.id];
        currentSword.SetActive(true);
        combometer = currentSword.transform.Find("Knight Combometer").GetComponent<KnightCombometer>();
        combometer.StartCombometer(size);
    }

    public KnightCombometer GetCombometer()
    {
        return combometer;
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
