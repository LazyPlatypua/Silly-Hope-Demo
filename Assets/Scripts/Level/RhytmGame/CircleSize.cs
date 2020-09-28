using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSize : MonoBehaviour
{
    public Transform[] sectors;
    public float startScale, scaleMultiplier;
    public RhytmEvent rhytmEvent;

    private void Awake()
    {
        if (rhytmEvent == null)
        rhytmEvent = RhytmEvent.instance;

        rhytmEvent.onFrequancyChange += OnFrequancyChange;
    }

    public void OnFrequancyChange(int id, float freq)
    {
        sectors[id].localScale = new Vector3(freq * scaleMultiplier + startScale, freq * scaleMultiplier + startScale, sectors[id].localScale.z);
    }
}
