using System.Collections.Generic;
using Level.FightGame;
using Level.Load_and_Manager;
using Level.RhytmGame;
using Level.UI;
using Scriptable_Objects;
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
    public void SetKnightBehaviour(int health, SwordData swordData, int combometerNeededPoints)
    {
        foreach(GameObject sword in swords)
        {
            sword.SetActive(false);
        }

        if(gameManager == null)
        {
            gameManager = GameManager.instance;
        }
        
        if (rhythmManager == null)
        {
            rhythmManager = RhythmManager.instance;
        }
        
        if (attackMenu == null)
        {
            attackMenu = AttackMenu.instance;
        }
        
        currentHealth = health;
        defaultHealth = health;
        
        GameObject currentSword = swords[swordData.id];
        currentSword.SetActive(true);
        combometer = currentSword.transform.Find("Knight Combometer").GetComponent<KnightCombometer>();
        combometer.StartCombometer(combometerNeededPoints);
    }

    public KnightCombometer GetCombometer()
    {
        return combometer;
    }

    //Начать атаку
    public override void Attack(Attack a)
    {
        Debug.Log($"KnightBehaviour.Attack({a.attackName})");
        animator.SetBool(a.attackName, true);
        current_a = a;
    }

    //Точка контакта атаки
    public override void PointOfAttack(string attackName)
    {
        base.PointOfAttack(attackName);
        current_a.attackName = attackName;
        attackMenu.DealDamageToEnemy(current_a);
        current_a = new Attack();
    }

    //Обновить здоровье рыцаря
    protected override void UpdateHealth(int damage)
    {
        base.UpdateHealth(damage);
        gameManager.UpdateHealthBar(currentHealth);
    }

    //Убить рыцаря
    protected override void Death()
    {
        gameManager.Defeat();
    }

    //Обнулить все анимации
    protected override void SetAllAnimToFalse()
    {
        animator.SetBool("heavy_attack", false);
        base.SetAllAnimToFalse();
    }

    //Обнулить анимацию
    public override void DeactivateAnimation(string activeTrigger)
    {
        base.DeactivateAnimation(activeTrigger);
    }

    //Начать анимацию смерти
    protected override void StartDeathAnim()
    {
        combometer.ActivateLight(false, false);
        combometer.ActivateLight(true, false);
        base.StartDeathAnim();
    }
}
