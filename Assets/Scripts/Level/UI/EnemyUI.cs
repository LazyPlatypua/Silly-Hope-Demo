using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Image combometerWhiteImage;
    public Image healthbarRedImage;
    public Animator animator;
    public float waitForStart = 1f;
    private static readonly int HealthAppear = Animator.StringToHash("health_appear");
    private static readonly int ComboAppear = Animator.StringToHash("combo_appear");

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
        animator.SetBool(HealthAppear, true);
    }

    public void ActivateHealthBar(float fill)
    {
        ChangeHealthFill(fill);
        ActivateHealthBar();
    }

    public void DeactivateHealthBar()
    {
        animator.SetBool(HealthAppear, false);
    }

    public void ChangeCombometerFill(float fill)
    {
        combometerWhiteImage.fillAmount = fill;
    }

    public void ActivateCombometer()
    {
        animator.SetBool(ComboAppear, true);
    }

    public void ActivateCombometer(float fill)
    {
        ChangeCombometerFill(fill);
        ActivateCombometer();
    }

    public void DeactivateCombometer()
    {
        animator.SetBool(ComboAppear, false);
    }

    public IEnumerator WaitToStart()
    {
        gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(waitForStart);
        gameObject.SetActive(true);
    }
}
