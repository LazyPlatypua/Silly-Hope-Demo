using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhytmEvent : MonoBehaviour
{
    public static RhytmEvent instance;

    private void Awake()
    {
        if(instance == null)
        instance = this;
    }

    public event Action<int> ONRhytmButtonPress;
    public void RhytmButtonPress(int line)
    {
        ONRhytmButtonPress?.Invoke(line);
    }

    public event Action<int, float> ONFrequancyChange;

    public void FrequancyChange(int id, float size)
    {
        ONFrequancyChange?.Invoke(id , size);
    }
}
