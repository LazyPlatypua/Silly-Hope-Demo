//Класс отвечает за поведение врага.
using UnityEngine;  //Подключить классы unity

public class EnemyBehaviour : CreatureBehaviour
{
    [Header("Links")]
    public EnemyUI enemyUI;       //ссылка на полоску здоровья врага
    public SpriteRenderer m_sprite_renderer;    //спрайтовый рендер врага
    [Header("Enemy settings")]
    public int damage = 1;                      //урон врага
    public int ink = 4;                         //количество чернил, которое получит игрок за убийство врага
    [Range(2, 6)]                           
    public int combo_meter_size = 2;            //размер комбометра

    public Vector3 position;                    //позиция врага
    public int spawn_point_index;               //Индекс точки спавна
    public float running_speed = 1;             //скорость бега врага
    protected bool is_running_out = false;      //Бежит ли враг
    protected bool is_running = false;          //Убегает ли враг

    [HideInInspector]
    public int death_count = 0;                 //Количество смертей врага
    public int currently_filled = 0;        //количество заполненных ячеек

    //Функция срабатывает при старте сцены
    private void Start() 
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (m_sprite_renderer == null)
        {
            m_sprite_renderer = GetComponent<SpriteRenderer>();
        }
        Activate();
    }

    //Функция срабатывает каждый фрейм
    private void Update()
    {
        if (is_running)
        {
            float step = running_speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, position, step);
            if (Vector3.Distance(transform.position, position) < 0.01f)
            {
                is_running = false;
                if (is_running_out)
                {
                    death_count++;
                    attack_menu.ActivateEnemies(spawn_point_index);
                    enemyUI.SetToDefault();
                    current_health = default_health;
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
        amount = (float)current_health / (float)default_health;
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

        death_count++;
        game_manager.AddInk(ink);
        current_health = default_health;

        attack_menu.ActivateEnemies(spawn_point_index);
    }

    //Функция включает врага на сцене
    public virtual void Activate()
    {
        animator.SetBool("death", false);
        SetAllAnimToFalse();
        current_health = default_health;

        gameObject.SetActive(true);
        transform.position = new Vector3 (position.x + attack_menu.start_running_delta, position.y, position.z);
        is_running = true;

        switch (spawn_point_index)
        {
            case 0:
                m_sprite_renderer.sortingOrder = 0;
                break;
            case 1:
                m_sprite_renderer.sortingOrder = 10;
                break;
            case 2:
                m_sprite_renderer.sortingOrder = 20;
                break;
            default:
                Debug.LogError("Unknown spawn point index: " + spawn_point_index + ", go to spawn point 0.");
                spawn_point_index = 0;
                goto case 0;
        }
        enemyUI.gameObject.SetActive(true);
    }

    //Функция, начинающая атаку врага. Если враг оглушен, то атака невозможна
    public override void Attack(Attack a)
    {
        base.Attack(a);

        enemyUI.DeactivateCombometer();
        currently_filled = 0;
    }

    //Функция обнуляет все анимации (кроме смерти)
    protected override void SetAllAnimToFalse()
    {
        base.SetAllAnimToFalse();
    }
    
    //Функция, обозначающая точку касания атаки
    public override void PointOfAttack(string name)
    {
        base.PointOfAttack(name);

        attack_menu.DealDamageToKnight(name, damage);
    }

    //Функция, выключающая анимацию. 
    public override void DeactivateAnimation(string active_trigger)
    {
        base.DeactivateAnimation(active_trigger);
    }

    //Функция, отключающая врага на сцене
    protected override void Death()
    {
        gameObject.SetActive(false);

        game_manager.EnemyDefeat();
    }

    //Функция, возвращающая булево значение на вопрос: полон ли комбометр врага
    public virtual bool IsCombometerFull()
    {
        return combo_meter_size == currently_filled;
    }

    //функция добавляет очки к комбометру. Если враг оглушен, очки не добавляются
    public virtual void AddToCombometer()
    {
        if (!stuned)
        {
            if(currently_filled < combo_meter_size)
            {
                currently_filled++;
            }
            enemyUI.ActivateCombometer((float)currently_filled / (float) combo_meter_size);
        }
    }

    //Функция меняет состояние врага на убегающего со сцены
    public virtual void RuningOut()
    {
        Debug.Log("EnemyBehaviour: Running Out " + gameObject.name);
        is_running_out = true;
        running_speed *= 2;
        transform.Rotate(0f, 180f, 0f);
        position = new Vector3(transform.position.x + 10f, transform.position.y, 0.0f);
        is_running = true;
        animator.SetBool("run", is_running);
        death_count++;
    }
}