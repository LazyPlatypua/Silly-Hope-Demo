using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalizer : MonoBehaviour
{
    public AudioSource audioSource;
    public RhytmEvent rhytmEvent;
    public static float[] samples = new float[512];

    void Awake()
    {
        if (rhytmEvent == null)
        {
            rhytmEvent = RhytmEvent.instance;
        }
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    protected void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    protected virtual void MakeFrequencyBand()
    {
    }
}