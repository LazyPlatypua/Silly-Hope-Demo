using System;
using System.Collections;
using Level.Load_and_Manager;
using UnityEngine;
using UnityEngine.Serialization;

public class PointSpawner : AudioAnalizer
{
    public static PointSpawner instance;

    public AudioSource musicAudioSource;

    public RhythmManager rhythmManager;
    public GameManager gameManager;
    public AttackMenu attackMenu;
    public GameObject pointPrefab;

    public static int[] bpm;
    public static float[] timeStamps;
    public float musicDelay = 6;
    public static float audioLenght;
    public AudioClip musicClip;
    public Sprite pointSprite;

    public float endLine = 5.3f;

    public float freqBand;

    public float timeBetweenPoints = 0.7f;
    public Vector3 spawnPosition;

    public float threshold = 0.005f;

    public bool isWorking = false;
    public bool levelIsStarted = false;
    private bool canGenerate = false;
    private bool isStarted = false;

    private void Awake()
    {
        instance = this;
    }

    public void StartPointSpawner(LocationData locationData, RhythmManager rhythmManager, GameManager gameManager)
    {
        levelIsStarted = false;
        pointSprite = locationData.pointSprite;
        bpm = locationData.beatTempos;
        timeStamps = locationData.timestamps;
        musicClip = locationData.audioClip;
        
        musicDelay = gameManager.musicDelay;
        PointBehaviour.beat_tempo = bpm[0];
        PointBehaviour.end_point = endLine;
        audioLenght = musicClip.length;

        _audioSource.Stop();
        _audioSource.clip = musicClip;

        musicAudioSource.Stop();
        musicAudioSource.clip = musicClip;

        _audioSource.Play();
        StartCoroutine(StartMusic());
    }

    
    
    IEnumerator StartMusic()
    {
        yield return new WaitForSecondsRealtime(musicDelay);

        levelIsStarted = true;
        isWorking = true;
        canGenerate = true;
        musicAudioSource.Play();
    }

    private void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBand();
        if(canGenerate && freqBand > threshold)
        {
            GeneratePoint();
        }

        isStarted |= _audioSource.time > 0f;
        if (!_audioSource.loop && (isStarted && _audioSource.time <= 0f))
        {
            attackMenu.StartEnemiesRunOut();
            StartCoroutine(WaitForVictoryScreen());
        }

    }
    IEnumerator WaitForVictoryScreen()
    {
        isStarted = false;

        yield return new WaitForSecondsRealtime(musicDelay);

        gameManager.Victory();
    }

    protected override void MakeFrequencyBand()
    {
        freqBand = _samples[0];
    }

    public void GeneratePoint()
    {
        int line = UnityEngine.Random.Range(0, 2);
        GameObject newgo = Instantiate(pointPrefab);
        PointBehaviour newgo_pb = newgo.GetComponent<PointBehaviour>();

        newgo.transform.position = spawnPosition;
        newgo_pb.line = line;
        newgo_pb.rhythm_manager = this.rhythmManager;
        newgo_pb.game_manager = this.gameManager;
        newgo_pb.sprite_renderer.sprite = pointSprite;
        newgo_pb.SetRed(line >= 1);
        StartCoroutine(WaitToGenerateNewPoint());
    }

    IEnumerator WaitToGenerateNewPoint()
    {
        canGenerate = false;
        yield return new WaitForSecondsRealtime(timeBetweenPoints + UnityEngine.Random.Range(-0.5f, 0.5f));
        canGenerate = true;
    }
}
