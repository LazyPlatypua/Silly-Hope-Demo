using System.Collections;
using TMPro;
using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
    public Animator animator_crossfade;
    public TextMeshProUGUI headphones_text;
    public TextMeshProUGUI laguage_text;
    public TextMeshProUGUI select_text;
    public TextMeshProUGUI to_tutorial_text;
    public TextMeshProUGUI skip_tutorial_text;
    public SceneLoader scene_loader;
    public float transition_time = 1f;  //Время перехода
    public bool is_first_load = false;

    public float waitToGoFromHeadphones = 7f;
    public enum State
    {
        headphones,
        language,
        to_tutorial
    }
    public State current_state = State.headphones;
    public Language.LanguageType current_language;

    private void Start()
    {
        current_state = State.headphones;
        GameData game_data = SaveSystem.LoadData();
        if (game_data == null)
        {
            Debug.Log("StartScreenManger: GameData is missing.");
            is_first_load = true;
            current_language = Language.LanguageType.english;
            SetStrings();
        }
        else
        {
            current_language = Language.IntToLanguage(game_data.language);
        }
        SetStrings();
        StartCoroutine(WaitToChangeHeadphones());
    }

    public void SetStrings()
    {
        StringSettings temp = new StringSettings(Language.LanguageToInt(current_language));
        headphones_text.text = temp.headphones;
        laguage_text.text = temp.language_;
        select_text.text = temp.select;
        to_tutorial_text.text = temp.play_tutorial;
        skip_tutorial_text.text = temp.skip_tutorial;
    }

    private void Update()
    {
        if (current_state == State.headphones)
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
        if (current_state == State.headphones)
        {
            Debug.Log("Changing state");
            FromHeadphones();
        }
    }

    private void FromHeadphones()
    {
        animator_crossfade.SetTrigger("Start");
        if (is_first_load)
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
        current_state = State.language;
    }

    public void ToMainMenu()
    {

        scene_loader.SceneLoad("MainMenu");
    }

    public void ToTutorialLevel()
    {
        scene_loader.SceneLoad("Tutorial");
    }

    public void ToNextLanguage()
    {
        if(Language.LanguageToInt(current_language) < 4)
        {
            current_language++;
        }
        else
        {
            current_language = 0;
        }
        SetStrings();
    }

    public void ToTutorial()
    {
        current_state = State.to_tutorial;
        animator_crossfade.SetTrigger("Start");
    }

    public void SaveData()
    {
        DataHolder.language = (byte)Language.LanguageToInt(current_language);
    }
}
