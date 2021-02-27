//Класс отвечает за поведение точки

using Level.Load_and_Manager;
using Level.RhytmGame;
using UnityEngine;  //Подключить классы unity

public class PointBehaviour : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;				//Ссылка на спрайт рендерер
	public GameManager gameManager;					//Ссылка на игровой менеджер
	public RhythmManager rhythmManager;				//Ссылка на ритм менеджер
	public Animator pointAnimator;						//Ссылка на аниматор точки
	public GameObject circle;							//Ссылка на круг вокруг точки
	public Color[] colors = new Color[4];				//Ссылка на цвета точки

	public static float beat_tempo = 120;				//Темп песни. 
	public static bool is_started = false;				//Начался ли уровень и не на паузе ли игра
	public static float end_point = 6;                      //положение крайней нижней точки, после которой она удаляется.
	public static bool[] active_lines = new bool[2];
	public int line = 0;								//номер линии, на которой находится точка

	public bool canBePressed = false;					//Может ли точка быть нажатой
	public bool isRedPoint = false;					//Это красная точка?
	public bool canBeMoved = true;                    //Может ли точка перемещаться?
	public bool isMissed = false;

	private short direction = 1;

	//Функция срабатывает в первый фрейм сцены
	private void Start()
	{ 
		if(spriteRenderer == null)
        {
			gameObject.GetComponent<SpriteRenderer>();
        }
		if (gameManager == null)
        {
			gameManager = GameManager.instance;
        }
		if (rhythmManager == null)
		{
			rhythmManager = RhythmManager.instance;
		}
		if (pointAnimator == null)
        {
			gameObject.GetComponent<Animator>();
        }
        RhytmEvent.instance.ONRhytmButtonPress += OnButtonPress;
	}

	private void OnButtonPress(int line)
    {
		if (canBePressed && line == this.line)
        {
			DeactivatePoint();
		}
    }

	//Функция срабатывает каждый фрейм сцены
	private void Update()
	{
		if (is_started)
		{
			if (canBeMoved)
			transform.position += new Vector3(direction * beat_tempo / 60 * Time.deltaTime, 0f, 0f);

		}

		if (Mathf.Abs(transform.position.x) >= end_point)
		{
			rhythmManager.OnMissPoint();
			Destroy(gameObject);
		}

	}

	//Деактивировать точку
	public void DeactivatePoint()
	{
		canBePressed = false;
		canBeMoved = false;

		pointAnimator.SetTrigger("catch");
	}

	public void DeletePoint()
    {
		rhythmManager.CatchPoint(this);
		Destroy(gameObject);
    }

	//Функция срабатывает при фхождении точки в триггер
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Line"))
		{
			canBePressed = true;
			spriteRenderer.color = colors[2];
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Line"))
		{
			canBePressed = false;
			isMissed = true;
			spriteRenderer.color = colors[3];
		}
	}

	//Функция назначает точку красной
	public void SetRed(bool isRed)
	{
		isRedPoint = isRed;
		if (!isRed)
		{
			spriteRenderer.color = colors[0];
			direction = -1;
		}
		else
		{
			spriteRenderer.color = colors[1];
			direction = 1;
		}
	}
}