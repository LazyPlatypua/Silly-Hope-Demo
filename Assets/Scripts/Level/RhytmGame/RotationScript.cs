//Класс отвечает за вращение точек
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public bool is_random = false;      //назначит рандомную скорость вращения
    public bool is_started = false;     //вращение началось
    public float rotation_speed = 1f;   //скорость вращения

    private Transform m_transform;      //трансформ точки
    
    // Start is called before the first frame update
    void Start()
    {
        m_transform = gameObject.transform;
        if (is_random)
        {
            rotation_speed = Random.Range(-5f, 5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (is_started)
        {
            m_transform.Rotate(0.0f, 0.0f, rotation_speed, Space.Self);
        }
    }
}
