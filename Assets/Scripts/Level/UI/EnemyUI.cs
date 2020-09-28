using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Image combometerWhiteImage;
    public Image healthbarRedImage;
    public Animator _animator;
    public float waitForStart = 1f;

    public void SetToDefault()
    {
        ChangeHealthFill(100);
        ChangeCombometerFill(0);
    }

    public void CombometerToNull()
    {
        combometerWhiteImage.fillAmount = 0;
    }

    public void ChangeHealthFill(float fill)
    {
        healthbarRedImage.fillAmount = fill;
    }

    public void ActivateHealthBar()
    {
        _animator.SetBool("health_appear", true);
    }

    public void ActivateHealthBar(float fill)
    {
        ChangeHealthFill(fill);
        ActivateHealthBar();
    }

    public void DeactivateHealthBar()
    {
        _animator.SetBool("health_appear", false);
    }

    public void ChangeCombometerFill(float fill)
    {
        combometerWhiteImage.fillAmount = fill;
    }

    public void ActivateCombometer()
    {
        _animator.SetBool("combo_appear", true);
    }

    public void ActivateCombometer(float fill)
    {
        ChangeCombometerFill(fill);
        ActivateCombometer();
    }

    public void DeactivateCombometer()
    {
        _animator.SetBool("combo_appear", false);
    }

    public IEnumerator WaitToStart()
    {
        gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(waitForStart);
        gameObject.SetActive(true);
    }
}
