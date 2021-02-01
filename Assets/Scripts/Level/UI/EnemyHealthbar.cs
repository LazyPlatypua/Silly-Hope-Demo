using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public Image healthbarImage;
    public GameObject @object;
    public Animator animator;
    public float waitForStart = 1f;
    private void Start()
    {
        if (healthbarImage == null)
        {
            healthbarImage = GetComponent<Image>();
        }

        if (@object == null)
        {
            @object = gameObject;
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void ChangeFill(float fill)
    {
        healthbarImage.fillAmount = fill;
    }

    public void ActivateHealthBar()
    {
        animator.SetBool("appear", true);
    }

    public void ActivateHealthBar(float fill)
    {
        ChangeFill(fill);
        ActivateHealthBar();
    }

    public void DeactivateHealthBar()
    {
        animator.SetBool("appear", false);
    }

    public IEnumerator WaitToStart()
    {
        gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(waitForStart);
        gameObject.SetActive(true);
    }
}
