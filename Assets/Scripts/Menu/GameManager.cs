using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string Name;
    public int HighestScore = 0;
    public string HighestName = "";
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string highestName;
        public int highestScore;

        public SaveData(string highestName, int highestScore)
        {
            this.highestName = highestName;
            this.highestScore = highestScore;
        }
    }

    public void SaveScore()
    {
        SaveData data = new SaveData(HighestName, HighestScore);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighestName = data.highestName;
            HighestScore = data.highestScore;
        }
    }
}
