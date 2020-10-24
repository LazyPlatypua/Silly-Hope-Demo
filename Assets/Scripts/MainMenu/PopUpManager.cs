using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUpImage;
    public TextMeshProUGUI popUpText;
    public TextMeshProUGUI okButtonText;
    public Animator animator;

    private string nowAvailable;
    private string sizeUpdate;
    private string newCombo;

    public void UpdateStrings(StringSettings temp)
    {
        nowAvailable = temp.pop_up_now_available;
        sizeUpdate = temp.pop_up_size_update;
        newCombo = temp.pop_up_new_combo;
        okButtonText.text = temp.pop_up_ok;
    }

    public void ClosePopUp()
    {
        animator.SetTrigger("activate");
    }

    public void OpenPopUp(string str)
    {
        gameObject.SetActive(true);
        popUpText.text = $"{nowAvailable}\n{str}";

        animator.SetTrigger("activate");
    }

    public void OpenPopUp(string str, byte newsize)
    {
        gameObject.SetActive(true);
        popUpText.text = $"{nowAvailable}\n{str}\n\n{sizeUpdate} {newsize}{newCombo}";
        animator.SetTrigger("activate");
    }

    public void OpenJokePopUp(string str)
    {
        gameObject.SetActive(true);
        popUpText.text = str;
        animator.SetTrigger("activate");
    }


    public void DebugButton()
    {
        OpenPopUp("Chapter 1: Village", 2);
    }
}
