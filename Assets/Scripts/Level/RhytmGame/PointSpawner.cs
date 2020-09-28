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
    public static float musicDelay;
    public static float audioLenght;
    public AudioClip musicClip;
    public Sprite pointImage;

    public float spawnPointHeight = 5f;
    public float endLine = -6;
    public GameObject mainLine;
    private float mainLineHeight;

    public float[] freqBand = new float[4];

    public float timeBetweenPoints = 1.5f;
    public float pointRotationSpeed = 2f;             //Скорость вращения точек 
    public float[] linesXCoord;

    public float[] lineTreshholds;

    public bool isWorking = false;
    public bool levelIsStarted = false;
    private bool canGenerate = true;
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

        mainLineHeight = mainLine.transform.position.y;

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
        PointBehaviour.beat_tempo = bpm;
        PointBehaviour.end_point = endLine;
        audioLenght = clip.length;
        musicDelay = (spawnPointHeight - mainLineHeight) / (bpm / 60);

        _audioSource.Stop();
        _audioSource.clip = musicClip;

        musicAudioSource.Stop();
        musicAudioSource.clip = musicClip;

        isWorking = true;
        _audioSource.Play();
        StartCoroutine(StartMusic());
    }

    
    IEnumerator StartMusic()
    {
        yield return new WaitForSecondsRealtime(musicDelay);

        levelIsStarted = true;
        musicAudioSource.Play();
    }

    private void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBand();
        if(canGenerate)
        {
            for (int i = 3; i >= 0; i --)
            {
                if ((freqBand[i] > lineTreshholds[i]))
                {
                    GeneratePoint(i);
                    break;
                }
            }
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
        int count = 0;

        for (int i = 0; i < 4; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(4, i) * 4;

            if (i == 3)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }

            average /= count;

            freqBand[i] = average;
        }
    }

    public void GeneratePoint( int line)
    {
        GameObject newgo = Instantiate(pointPrefab);
        PointBehaviour newgo_pb = newgo.GetComponent<PointBehaviour>();

        newgo.transform.position = new Vector3(linesXCoord[line], spawnPointHeight, 0.0f);
        newgo_pb.line = line;
        newgo_pb.rotation_speed = pointRotationSpeed * (Random.Range(0, 2) * 2 - 1);
        newgo_pb.rhythm_manager = this.rhythmManager;
        newgo_pb.game_manager = this.gameManager;
        newgo_pb.sprite_renderer.sprite = pointImage;
        newgo_pb.SetRed(line >= 2);
        StartCoroutine(WaitToGenerateNewPoint());
    }

    IEnumerator WaitToGenerateNewPoint()
    {
        canGenerate = false;
        yield return new WaitForSecondsRealtime(timeBetweenPoints);
        canGenerate = true;
    }
}
