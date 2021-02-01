using System.Collections;
using TMPro;
using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    public Animator animatorCrossfade;
    public TextMeshProUGUI headphonesText;
    public TextMeshProUGUI laguageText;
    public TextMeshProUGUI selectText;
    public TextMeshProUGUI toTutorialText;
    public TextMeshProUGUI skipTutorialText;
    public SceneLoader sceneLoader;
    public float transitionTime = 1f;  //Время перехода
    public bool isFirstLoad = false;

    public float waitToGoFromHeadphones = 7f;
    public enum State
    {
        Headphones,
        Language,
        ToTutorial
    }
    public State currentState = State.Headphones;
    public Language.LanguageType currentLanguage;

    private void Start()
    {
        currentState = State.Headphones;
        GameData gameData = SaveSystem.LoadData();
        if (gameData == null)
        {
            Debug.Log("StartScreenManger: GameData is missing.");
            isFirstLoad = true;
            currentLanguage = Language.LanguageType.English;
            SetStrings();
        }
        else
        {
            currentLanguage = Language.IntToLanguage(gameData.language);
        }
        SetStrings();
        StartCoroutine(WaitToChangeHeadphones());
    }

    public void SetStrings()
    {
        StringSettings temp = new StringSettings(Language.LanguageToInt(currentLanguage));
        headphonesText.text = temp.headphones;
        laguageText.text = temp.language;
        selectText.text = temp.select;
        toTutorialText.text = temp.playTutorial;
        skipTutorialText.text = temp.skipTutorial;
    }

    private void Update()
    {
        if (currentState == State.Headphones)
        {
            if (Input.touchCount > 0 )
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    FromHeadphones();
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                FromHeadphones();
            }
        }
    }

    private IEnumerator WaitToChangeHeadphones()
    {
        Debug.Log("Wait for input");
        yield return new WaitForSecondsRealtime(waitToGoFromHeadphones);
        if (currentState == State.Headphones)
        {
            Debug.Log("Changing state");
            FromHeadphones();
        }
    }

    private void FromHeadphones()
    {
        animatorCrossfade.SetTrigger("Start");
        if (isFirstLoad)
        {
            ToLanguageSelect();
        }
        else
        {
            ToMainMenu();
        }
    }

    private void ToLanguageSelect()
    {
        currentState = State.Language;
    }

    public void ToMainMenu()
    {

        sceneLoader.SceneLoad("MainMenu");
    }

    public void ToTutorialLevel()
    {
        sceneLoader.SceneLoad("Tutorial");
    }

    public void ToNextLanguage()
    {
        if(Language.LanguageToInt(currentLanguage) < 4)
        {
            currentLanguage++;
        }
        else
        {
            currentLanguage = 0;
        }
        SetStrings();
    }

    public void ToTutorial()
    {
        currentState = State.ToTutorial;
        animatorCrossfade.SetTrigger("Start");
    }

    public void SaveData()
    {
        DataHolder.language = (byte)Language.LanguageToInt(currentLanguage);
    }
}
