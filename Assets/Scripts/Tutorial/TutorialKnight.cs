using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialKnight : MonoBehaviour
{
    public TutorialManager tm;
    public KnightCombometer knightCombometer;
    public Animator animator;

    private void Awake()
    {
        knightCombometer.StartCombometer(3);
    }

    public void AddToCombometer(bool isRed)
    {
        knightCombometer.Add(!isRed);
    }

    public void Attack(string name)
    {
        animator.SetBool(name, true);
    }

    //Точка контакта атаки
    public void PointOfAttack(string name)
    {
        tm.DealDamageToEnemy(name);
    }

    //Обнулить все анимации
    public void SetAllAnimToFalse()
    {
        animator.SetBool("heavy_attack", false);

        animator.SetBool("attack", false);

        animator.SetBool("take_damage", false);
    }

    //Обнулить анимацию
    public void DeactivateAnimation(string active_trigger)
    {
        animator.SetBool(active_trigger, false);

        if (active_trigger == "take_damage")
        {
            SetAllAnimToFalse();
        }
    }

    public virtual void TakeDamage()
    //Функция наносит урон врагу. Принимает количество урона и тип (0 - обычный, 1 - оглушение, 2 - критический)
    {
        TakeSimpleAttackAnim();
    }

    protected virtual void TakeSimpleAttackAnim()
    //Функция, начинающя анимацию получения урона
    {
        SetAllAnimToFalse();
        animator.SetBool("take_damage", true);
    }
}
