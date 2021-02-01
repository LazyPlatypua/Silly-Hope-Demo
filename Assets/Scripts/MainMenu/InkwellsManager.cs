using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InkwellsManager : MonoBehaviour
{
    public List<Sprite> inkwellsSprites;
    public SpriteRenderer spriteRenderer;
    public TextMeshProUGUI inkText;
    public GameObject debugMenu;

    public int highestValue = 100;
    public int middleValue = 50;
    public bool debugMenuIsActive;
    public int currentInk;
    
    public void InkUpdate(int ink)
    {
        if(ink >= highestValue)
        {
            spriteRenderer.sprite = inkwellsSprites[2];
        }
        else
        {
            if (ink >= middleValue)
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
        debugMenu.SetActive(!debugMenuIsActive);
        debugMenuIsActive = !debugMenuIsActive;
    }

    public int GETInkCount() 
    {
        return currentInk;
    }
}
