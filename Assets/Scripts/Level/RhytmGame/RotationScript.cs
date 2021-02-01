//Класс отвечает за вращение точек
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public bool isRandom = false;      //назначит рандомную скорость вращения
    public bool isStarted = false;     //вращение началось
    public float rotationSpeed = 1f;   //скорость вращения

    private Transform m_transform;      //трансформ точки
    
    // Start is called before the first frame update
    void Start()
    {
        m_transform = gameObject.transform;
        if (isRandom)
        {
            rotationSpeed = Random.Range(-5f, 5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            m_transform.Rotate(0.0f, 0.0f, rotationSpeed, Space.Self);
        }
    }
}
