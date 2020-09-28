//Класс отвечает за сохранение данных
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //Сохранить данные из главного меню
    public static void SaveData(MainMenuManager main_menu_manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SillyHopeSaveFile.yeboi";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(main_menu_manager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    //Загрузить данные
    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/SillyHopeSaveFile.fuck";

        if (File.Exists(path))
        {
            Debug.Log("GameData is found. Retrieving");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream =  new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("SaveSystem: GameData is missing");
            return null;
        }
    }
}
