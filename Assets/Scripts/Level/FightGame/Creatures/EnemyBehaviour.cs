//Класс отвечает за поведение врага.

using Level.FightGame;
using UnityEngine;  //Подключить классы unity

public class EnemyBehaviour : CreatureBehaviour
{
    [Header("Links")]
    public EnemyUI enemyUI;       //ссылка на полоску здоровья врага
    public SpriteRenderer spriteRenderer;    //спрайтовый рендер врага
    [Header("Enemy settings")]
    public int damage = 1;                      //урон врага
    public int ink = 4;                         //количество чернил, которое получит игрок за убийство врага
    [Range(2, 6)]                           
    public int comboMeterSize = 2;            //размер комбометра

    public Vector3 position;                    //позиция врага
    public int spawnPointIndex;               //Индекс точки спавна
    public float runningSpeed = 1;             //скорость бега врага
    protected bool is_running_out = false;      //Бежит ли враг
    protected bool is_running = false;          //Убегает ли враг

    [HideInInspector]
    public int deathCount = 0;                 //Количество смертей врага
    public int currentlyFilled = 0;        //количество заполненных ячеек

    //Функция срабатывает при старте сцены
    private void Start() 
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        Activate();
    }

    //Функция срабатывает каждый фрейм
    private void Update()
    {
        if (is_running)
        {
            float step = runningSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, position, step);
            if (Vector3.Distance(transform.position, position) < 0.01f)
            {
                is_running = false;
                if (is_running_out)
                {
                    deathCount++;
                    attackMenu.ActivateEnemies(spawnPointIndex);
                    enemyUI.SetToDefault();
                    currentHealth = defaultHealth;
                    Death();
                }
            }
        }
        animator.SetBool("run", is_running);
    }

    //Функция обновляет здоровье существа
    protected override void UpdateHealth(int damage)
    {
        float amount;
        base.UpdateHealth(damage);
        amount = (float)currentHealth / (float)defaultHealth;
        enemyUI.ChangeHealthFill(amount);
    }

    public virtual void ShowHealth()
    {
        enemyUI.ActivateHealthBar();
    }

    public virtual void HideHealth()
    {
        enemyUI.DeactivateHealthBar();
    }

    protected  override void StartDeathAnim()
    //функция, начинающая процесс смерти врага
    {
        enemyUI.gameObject.SetActive(false);
        enemyUI.SetToDefault();

        base.StartDeathAnim();

        deathCount++;
        gameManager.AddInk(ink);
        currentHealth = defaultHealth;

        attackMenu.ActivateEnemies(spawnPointIndex);
    }

    //Функция включает врага на сцене
    public virtual void Activate()
    {
        animator.SetBool("death", false);
        SetAllAnimToFalse();
        currentHealth = defaultHealth;

        gameObject.SetActive(true);
        transform.position = new Vector3 (position.x + attackMenu.startRunningDelta, position.y, position.z);
        is_running = true;

        switch (spawnPointIndex)
        {
            case 0:
                spriteRenderer.sortingOrder = 0;
                break;
            case 1:
                spriteRenderer.sortingOrder = 10;
                break;
            case 2:
                spriteRenderer.sortingOrder = 20;
                break;
            default:
                Debug.LogError("Unknown spawn point index: " + spawnPointIndex + ", go to spawn point 0.");
                spawnPointIndex = 0;
                goto case 0;
        }
        enemyUI.gameObject.SetActive(true);
    }

    //Функция, начинающая атаку врага. Если враг оглушен, то атака невозможна
    public override void Attack(Attack a)
    {
        base.Attack(a);

        enemyUI.DeactivateCombometer();
        currentlyFilled = 0;
    }

    //Функция обнуляет все анимации (кроме смерти)
    protected override void SetAllAnimToFalse()
    {
        base.SetAllAnimToFalse();
    }
    
    //Функция, обозначающая точку касания атаки
    public override void PointOfAttack(string attackName)
    {
        base.PointOfAttack(attackName);

        attackMenu.DealDamageToKnight(attackName, damage);
    }

    //Функция, выключающая анимацию. 
    public override void DeactivateAnimation(string activeTrigger)
    {
        base.DeactivateAnimation(activeTrigger);
    }

    //Функция, отключающая врага на сцене
    protected override void Death()
    {
        gameObject.SetActive(false);

        gameManager.EnemyDefeat();
    }

    //Функция, возвращающая булево значение на вопрос: полон ли комбометр врага
    public virtual bool IsCombometerFull()
    {
        return comboMeterSize == currentlyFilled;
    }

    //функция добавляет очки к комбометру. Если враг оглушен, очки не добавляются
    public virtual void AddToCombometer()
    {
        if (!stuned)
        {
            if(currentlyFilled < comboMeterSize)
            {
                currentlyFilled++;
            }
            enemyUI.ActivateCombometer((float)currentlyFilled / (float) comboMeterSize);
        }
    }

    //Функция меняет состояние врага на убегающего со сцены
    public virtual void RuningOut()
    {
        Debug.Log("EnemyBehaviour: Running Out " + gameObject.name);
        is_running_out = true;
        runningSpeed *= 2;
        transform.Rotate(0f, 180f, 0f);
        position = new Vector3(transform.position.x + 10f, transform.position.y, 0.0f);
        is_running = true;
        animator.SetBool("run", is_running);
        deathCount++;
    }
}