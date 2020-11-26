//Класс отвечает за поведение существа
using System.Collections;
using Level.Load_and_Manager;
using UnityEngine;

public class CreatureBehaviour : MonoBehaviour
//Класс для всех существ
{
    [Header("Links")]
    public GameManager game_manager;    //ссылка на игровой менеджер
    public AttackMenu attack_menu;      //ссылка на меню атак
    public Animator animator;           //ссылка на аниматор 
    public int default_health;          //Здоровье по умолчанию
    public float daze_time;

    protected bool stuned = false;      //является ли враг оглушенным
    protected bool ripost_flag = false; //Находится ли существо под маркером рипоста
    protected bool parry_flag = false;  //находится ли существо под маркером состояния парирования

    [SerializeField]
    protected int current_health;       //текущее здоровье

    public virtual void Attack(Attack a)
    //функция, начинающая атаку существа. Если враг оглушен, то атака невозможна
    {
        if (!stuned)
        {
            animator.SetBool(a.attack_name, true);
        }
    }

    public virtual void PointOfAttack(string name)
    //Функция, обозначающая точку касания атаки
    {
        
    }

    public virtual void TakeDamage(int damage, string type)
    //Функция наносит урон врагу. Принимает количество урона и тип (0 - обычный, 1 - оглушение, 2 - критический)
    {
        switch (type)
        {
            case "attack":
                if(Random.Range(0, 1f) < 0.25f)
                {
                    UpdateHealth(damage * 2);
                }
                else
                {
                    UpdateHealth(damage);
                }
                TakeSimpleAttackAnim();
                break;

            case "heavy_attack":
                if (Random.Range(0f, 1f) < 0.5f)
                {
                    UpdateHealth(damage);
                    Stun();
                }
                else
                {
                    goto case "attack";
                }
                break;

            default:
                Debug.LogError("EnemyBehaviour.TakeDamage(" + damage + ", " + type + "): unknown type variable! Set to default");
                break;
        }
    }

    protected virtual void UpdateHealth(int damage)
    //Функция обновляет здоровье существа
    {
        current_health -= damage;
        if (current_health <= 0)
        {
            StartDeathAnim();
        }
    }

    //Функция обнуляет все анимации (кроме смерти)
    protected virtual void SetAllAnimToFalse()
    {
        animator.SetBool("attack", false);

        animator.SetBool("take_damage", false);
    }

    //Функция, выключающая анимацию. 
    public virtual void DeactivateAnimation(string active_trigger)
    {
        if (active_trigger == "death")
        {
            Death();
        }
        else
        {
            animator.SetBool(active_trigger, false);
        }

        if(active_trigger == "take_damage")
        {
            SetAllAnimToFalse();
        }
    }

    //функция, начинающая процесс смерти существа
    protected virtual void StartDeathAnim()
    {
        SetAllAnimToFalse();
        animator.SetBool("death", true);
    }

    protected virtual void TakeSimpleAttackAnim()
    //Функция, начинающя анимацию получения урона
    {
        SetAllAnimToFalse();
        animator.SetBool("take_damage", true);
    }

    protected virtual void Stun()
    //Функция включает состояние оглушения
    {
        SetAllAnimToFalse();
        stuned = true;
        StartCoroutine(StartDaze(daze_time));
        animator.SetBool("stun", stuned);
    }

    protected virtual IEnumerator StartDaze(float daze_time)
    //функция, начинающаяя отсчет до конца оглушения
    {
        yield return new WaitForSecondsRealtime(daze_time);
        stuned = false;
    }

    protected virtual void Death()
    //Функция заканчивает процесс умирания существа
    {
    }
}
