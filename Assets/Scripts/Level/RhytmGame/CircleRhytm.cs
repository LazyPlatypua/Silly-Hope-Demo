using UnityEngine;

public class CircleRhytm : AudioAnalizer
{
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBand();
    }

    protected override void MakeFrequencyBand()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            rhytmEvent.FrequancyChange(i, average);
        }
    }

    public void ChangePointSize()
    {
    }
}
