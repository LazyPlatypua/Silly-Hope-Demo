using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalizer : MonoBehaviour
{
    public AudioSource _audioSource;
    public RhytmEvent rhytmEvent;
    public static float[] _samples = new float[512];

    void Awake()
    {
        if (rhytmEvent == null)
        {
            rhytmEvent = RhytmEvent.instance;
        }
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }

    protected void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    protected virtual void MakeFrequencyBand()
    {
    }
}