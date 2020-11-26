//Класс отвечает за поведение точки

using Level.Load_and_Manager;
using UnityEngine;  //Подключить классы unity

public class PointBehaviour : MonoBehaviour
{
	public SpriteRenderer sprite_renderer;				//Ссылка на спрайт рендерер
	public GameManager game_manager;					//Ссылка на игровой менеджер
	public RhythmManager rhythm_manager;				//Ссылка на ритм менеджер
	public Animator point_animator;						//Ссылка на аниматор точки
	public GameObject circle;							//Ссылка на круг вокруг точки
	public Color[] colors = new Color[4];				//Ссылка на цвета точки
	public Transform m_transform;						//Ссылка на трансформ точки

	public static float beat_tempo = 120;				//Темп песни. 
	public static bool is_started = false;				//Начался ли уровень и не на паузе ли игра
	public static float end_point = 6;                      //положение крайней нижней точки, после которой она удаляется.
	public static bool[] active_lines = new bool[2];
	public int line = 0;								//номер линии, на которой находится точка

	public bool can_be_pressed = false;					//Может ли точка быть нажатой
	public bool is_red_point = false;					//Это красная точка?
	public bool can_be_moved = true;                    //Может ли точка перемещаться?
	public bool is_missed = false;

	private short direction = 1;

	//Функция срабатывает в первый фрейм сцены
	private void Start()
	{ 
		if(sprite_renderer == null)
        {
			gameObject.GetComponent<SpriteRenderer>();
        }
		if (game_manager == null)
        {
			game_manager = GameManager.instance;
        }
		if (rhythm_manager == null)
		{
			rhythm_manager = RhythmManager.instance;
		}
		if (point_animator == null)
        {
			gameObject.GetComponent<Animator>();
        }
		m_transform = transform;
        RhytmEvent.instance.onRhytmButtonPress += OnButtonPress;
	}

	private void OnButtonPress(int _line)
    {
		if (can_be_pressed && _line == line)
        {
			DeactivatePoint();
		}
    }

	//Функция срабатывает каждый фрейм сцены
	private void Update()
	{
		if (is_started)
		{
			if (can_be_moved)
			m_transform.position += new Vector3(direction * beat_tempo / 60 * Time.deltaTime, 0f, 0f);

		}

		if (Mathf.Abs(transform.position.x) >= end_point)
		{
			rhythm_manager.OnMissPoint();
			Destroy(gameObject);
		}

	}

	//Деактивировать точку
	public void DeactivatePoint()
	{
		can_be_pressed = false;
		can_be_moved = false;

		point_animator.SetTrigger("catch");
	}

	public void DeletePoint()
    {
		rhythm_manager.CatchPoint(this);
		Destroy(gameObject);
    }

	//Функция срабатывает при фхождении точки в триггер
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Line"))
		{
			can_be_pressed = true;
			sprite_renderer.color = colors[2];
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Line"))
		{
			can_be_pressed = false;
			is_missed = true;
			sprite_renderer.color = colors[3];
		}
	}

	//Функция назначает точку красной
	public void SetRed(bool is_red)
	{
		is_red_point = is_red;
		if (!is_red)
		{
			sprite_renderer.color = colors[0];
			direction = -1;
		}
		else
		{
			sprite_renderer.color = colors[1];
			direction = 1;
		}
	}
}