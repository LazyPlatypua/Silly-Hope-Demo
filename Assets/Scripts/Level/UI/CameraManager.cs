//Клаас отвечает за движение камеры
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;  //Ссылка на этот скрипт
    public Animator animator;       //Ссылка на аниматор камеры
    public Camera m_camera;         //Ссылка на камеру
    public Vector3 start_position;  //Начальная позиция камеры
    public Vector3 last_position;   //Конечная позиция точки
    public float start_size;        //Начальный размер камеры
    public float last_size;         //Конечный размер камеры

    private void Awake()
    {
        instance = this;
    }

    public void JiggleLeft()
    {
        animator.SetTrigger("jiggleLeft");
    }

    public void JiggleRight()
    {
        animator.SetTrigger("jiggleRight");
    }

    //Начать переход
    public void ActivateTransition()
    {
        animator.SetBool("ActivateMenu", true);
    }

    //Вернуться на начальную позицию
    public void DeactivateTransition()
    {
        animator.SetBool("DeactivateMenu", true);
    }

    //Установить позицию
    public void SetPosition()
    {
        animator.SetBool("ActivateMenu", false);
        animator.SetBool("DeactivateMenu", false);
    }
}
