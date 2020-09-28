using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public Image healthbarImage;
    public GameObject _object;
    public Animator _animator;
    public float waitForStart = 1f;
    private void Start()
    {
        if (healthbarImage == null)
        {
            healthbarImage = GetComponent<Image>();
        }

        if (_object == null)
        {
            _object = gameObject;
        }

        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    public void ChangeFill(float fill)
    {
        healthbarImage.fillAmount = fill;
    }

    public void ActivateHealthBar()
    {
        _animator.SetBool("appear", true);
    }

    public void ActivateHealthBar(float fill)
    {
        ChangeFill(fill);
        ActivateHealthBar();
    }

    public void DeactivateHealthBar()
    {
        _animator.SetBool("appear", false);
    }

    public IEnumerator WaitToStart()
    {
        gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(waitForStart);
        gameObject.SetActive(true);
    }
}
