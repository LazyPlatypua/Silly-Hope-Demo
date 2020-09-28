using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TutorialPoint : MonoBehaviour
{
    public float speed = 0.5f;
    public float endPoint = -2f;
    public int line = 0;
    public bool isRed = false;
    public bool canBePressed = false;
    public Transform m_transform;
    public SpriteRenderer spriteRenderer;
    public TutorialManager tutorialManager;
    public Color[] colors;

    private void Update()
    {
        if (transform.position.y < endPoint)
        {
            DestroyPoint(false);
        }
        m_transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
    }

    public void SetTutorialPoint(TutorialManager tutorialManager, bool isRed, int line, float end)
    {
        this.tutorialManager = tutorialManager;
        this.line = line;
        this.isRed = isRed;
        if(isRed)
        {
            spriteRenderer.color = colors[1];
        }
        else
        {
            spriteRenderer.color = colors[0];
        }
        endPoint = end;

        tutorialManager.onRhytmButtonPress += OnButtonPress;
    }

    private void OnButtonPress(int _line)
    {
        if (canBePressed && _line == line)
        {
            DestroyPoint(true);
        }
    }


    public void DestroyPoint(bool byPlayer)
    {
        if(byPlayer)
        {
            tutorialManager.AddPoints(isRed);
        }
        else
        {
            tutorialManager.AddToEnemy();
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Line"))
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
            spriteRenderer.color = colors[3];
        }
    }
}
