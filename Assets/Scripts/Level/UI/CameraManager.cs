//Клаас отвечает за движение камеры
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;  //Ссылка на этот скрипт
    public Animator animator;       //Ссылка на аниматор камеры
    public Camera mCamera;         //Ссылка на камеру
    public Vector3 startPosition;  //Начальная позиция камеры
    public Vector3 lastPosition;   //Конечная позиция точки
    public float startSize;        //Начальный размер камеры
    public float lastSize;         //Конечный размер камеры

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
