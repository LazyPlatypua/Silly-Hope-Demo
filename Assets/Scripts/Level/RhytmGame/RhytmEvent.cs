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

    public event Action<int> onRhytmButtonPress;
    public void RhytmButtonPress(int line)
    {
        onRhytmButtonPress?.Invoke(line);
    }

    public event Action<int, float> onFrequancyChange;

    public void FrequancyChange(int id, float size)
    {
        onFrequancyChange?.Invoke(id , size);
    }
}
