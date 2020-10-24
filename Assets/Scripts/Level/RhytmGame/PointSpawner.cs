using System;
using System.Collections;
using UnityEngine;

public class PointSpawner : AudioAnalizer
{
    public static PointSpawner instance;

    public AudioSource musicAudioSource;

    public RhythmManager rhythmManager;
    public GameManager gameManager;
    public AttackMenu attackMenu;
    public GameObject pointPrefab;

    public static int bpm = 120;
    public float musicDelay;
    public static float audioLenght;
    public AudioClip musicClip;
    public Sprite pointImage;

    public float endLine = 6;

    public float freqBand;

    public float timeBetweenPoints = 1.5f;
    public Vector3 spawnPosition;

    public float treshhold;

    public bool isWorking = false;
    public bool levelIsStarted = false;
    private bool canGenerate = false;
    private bool isStarted = false;

    private void Awake()
    {
        instance = this;
    }

    public void StartPointSpawner(int beatsPerMinute, AudioClip clip, RhythmManager rhythm, GameManager game, Sprite image)
    {
        levelIsStarted = false;
        pointImage = image;
        bpm = beatsPerMinute;
        musicClip = clip;
        rhythmManager = rhythm;
        gameManager = game;

        if(rhythmManager ==null)
        {
            rhythmManager = RhythmManager.instance;
        }

        if(gameManager == null)
        {
            gameManager = GameManager.instance;
        }

        if(attackMenu == null)
        {
            attackMenu = AttackMenu.instance;
        }

        if (_audioSource == null)
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
        }

        if (musicAudioSource == null)
        {
            musicAudioSource = gameManager.audio_source;
        }
        musicDelay = gameManager.musicDelay;
        PointBehaviour.beat_tempo = bpm;
        PointBehaviour.end_point = endLine;
        audioLenght = clip.length;

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
        if(canGenerate && freqBand > treshhold)
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
        newgo_pb.sprite_renderer.sprite = pointImage;
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
