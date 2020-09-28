using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InkwellsManager : MonoBehaviour
{
    public List<Sprite> inkwellsSprites;
    public SpriteRenderer spriteRenderer;
    public TextMeshProUGUI inkText;
    public GameObject DebugMenu;

    public int highest_value = 100;
    public int middle_value = 50;
    public bool debugMenuIsActive;
    public int currentInk;
    
    public void InkUpdate(int ink)
    {
        if(ink >= highest_value)
        {
            spriteRenderer.sprite = inkwellsSprites[2];
        }
        else
        {
            if (ink >= middle_value)
            {
                spriteRenderer.sprite = inkwellsSprites[1];
            }
            else
            {
                spriteRenderer.sprite = inkwellsSprites[0];
            }
        }

        currentInk = ink;
        inkText.text = ink.ToString() ;
    }

    public void TriggerDebugMenu()
    {
        DebugMenu.SetActive(!debugMenuIsActive);
        debugMenuIsActive = !debugMenuIsActive;
    }

    public int getInkCount() 
    {
        return currentInk;
    }
}
