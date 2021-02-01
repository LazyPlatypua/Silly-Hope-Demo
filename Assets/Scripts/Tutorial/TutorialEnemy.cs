using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    public TutorialManager tm;
    public EnemyUI enemyUI;       //ссылка на полоску здоровья врага
    public Animator animator;    //спрайтовый рендер врага
    public int defaultHealth;
    public int currentHealth;
    public int damage = 0;                      //урон врага
    public int ink = 0;
    public int comboMeterSize = 6;            //размер комбометра
    public float dazeTime = 2;
    public bool stuned = false;      //является ли враг оглушенным
    public Vector3 position;                    //позиция врага
    public int currentlyFilled = 0;        //количество заполненных ячеек

    //Функция срабатывает при старте сцены
    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        Activate();
    }

    //Функция срабатывает каждый фрейм
    private void Update()
    {

    }

    //Функция обновляет здоровье существа
    public void UpdateHealth(int damage)
    {
        float amount;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            StartDeathAnim();
        }
        amount = (float)currentHealth / (float)defaultHealth;
        enemyUI.ChangeHealthFill(amount);
    }

    public void ShowHealth()
    {
        enemyUI.ActivateHealthBar();
    }

    public void HideHealth()
    {
        enemyUI.DeactivateHealthBar();
    }

    public void StartDeathAnim()
    //функция, начинающая процесс смерти врага
    {
        enemyUI.gameObject.SetActive(false);
        enemyUI.SetToDefault();

        SetAllAnimToFalse();
        animator.SetBool("death", true);

        tm.ChangeState();
    }

    //Функция включает врага на сцене
    public void Activate()
    {
        animator.SetBool("death", false);
        SetAllAnimToFalse();
        currentHealth = defaultHealth;

        gameObject.SetActive(true);
        enemyUI.gameObject.SetActive(true);
    }

    //Функция, начинающая атаку врага. Если враг оглушен, то атака невозможна
    public void Attack()
    {
        if (!stuned)
        {
            animator.SetBool("attack", true);
        }

        enemyUI.DeactivateCombometer();
        currentlyFilled = 0;
    }

    //Функция обнуляет все анимации (кроме смерти)
    public void SetAllAnimToFalse()
    {
        animator.SetBool("attack", false);

        animator.SetBool("take_damage", false);
    }

    //Функция, обозначающая точку касания атаки
    public void PointOfAttack()
    {
        tm.DealDamageToKnight();
    }

    //Функция, выключающая анимацию. 
    public void DeactivateAnimation(string activeTrigger)
    {

        if (activeTrigger == "death")
        {
            Death();
        }
        else
        {
            animator.SetBool(activeTrigger, false);
        }

        if (activeTrigger == "take_damage")
        {
            SetAllAnimToFalse();
        }
    }

    //Функция, отключающая врага на сцене
    public void Death()
    {
        gameObject.SetActive(false);
    }

    //Функция, возвращающая булево значение на вопрос: полон ли комбометр врага
    public bool IsCombometerFull()
    {
        return comboMeterSize == currentlyFilled;
    }

    //функция добавляет очки к комбометру. Если враг оглушен, очки не добавляются
    public virtual void AddToCombometer()
    {
        if (!stuned)
        {
            if (currentlyFilled < comboMeterSize)
            {
                currentlyFilled++;
            }
            enemyUI.ActivateCombometer((float)currentlyFilled / (float)comboMeterSize);
        }
        if (IsCombometerFull())
        {
            Attack();
        }
    }

    public void TakeDamage(int damage, string type)
    //Функция наносит урон врагу. Принимает количество урона и тип (0 - обычный, 1 - оглушение, 2 - критический)
    {
        switch (type)
        {
            case "attack":
                if (Random.Range(0, 1f) < 0.25f)
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
        HideHealth();
    }

    public  void TakeSimpleAttackAnim()
    //Функция, начинающя анимацию получения урона
    {
        SetAllAnimToFalse();
        animator.SetBool("take_damage", true);
    }

    public void Stun()
    //Функция включает состояние оглушения
    {
        if (!gameObject.activeSelf)
        {
            return;
        }
        SetAllAnimToFalse();
        stuned = true;
        StartCoroutine(StartDaze(dazeTime));
        animator.SetBool("stun", stuned);
    }

    protected virtual IEnumerator StartDaze(float dazeTime)
    //функция, начинающаяя отсчет до конца оглушения
    {
        yield return new WaitForSecondsRealtime(dazeTime);
        stuned = false;
    }
}