using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance 
    { 
        get 
        { 
            if (instance == null)
            {
                GameObject scoreManagerGO= new GameObject("ScoreManager");
                var scoreManagerInstance = scoreManagerGO.AddComponent<ScoreManager>();
                return scoreManagerInstance;
            }

            return instance; 
        } 
    }

    public int Score;
    public string PlayerName;

    public int HighScore;
    public string HighScorePlayerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScoreData();
    }

    public void AddScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        MainUIHandler.Instance.UpdateScore(Score);
    }
         
    [System.Serializable]
    class HighScoreData
    {
        public int HighScore;
        public string PlayerName;
    }

    public void SaveHighScoreData()
    {
        string path = Application.persistentDataPath + "/highscorefile.json";

        HighScoreData highScoreData = new HighScoreData();
        highScoreData.PlayerName = HighScorePlayerName;
        highScoreData.HighScore = HighScore;
        
        string json = JsonUtility.ToJson(highScoreData);

        File.WriteAllText(path, json);
    }

    void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/highscorefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            HighScore = data.HighScore;
            HighScorePlayerName = data.PlayerName;
        }
    }
}
