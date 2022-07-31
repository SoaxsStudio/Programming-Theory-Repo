using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string userName;
    public int highScore;
    public string highScoreUser;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }

    [System.Serializable]
    class SaveData
    {
        public string userName;
        public int highScore;
        public string highScoreUser;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();

        data.userName = userName;
        data.highScore = highScore;
        data.highScoreUser = highScoreUser;

        if (data.userName == "DELETE")
        {
            data.userName = "";
            data.highScore = 0;
            data.highScoreUser = "";
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            userName = data.userName;
            highScore = data.highScore;
            highScoreUser = data.highScoreUser;
        }
    }
}
