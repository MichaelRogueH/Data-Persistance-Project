using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public string highScorePlayerName;
    public int highScore;

 

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    [System.Serializable]
    class SaveData
    {
        
        public string highScorePlayerName;
        public int highScore;
    }

    public void SaveHighScore(int saveMode)
    {
        
        SaveData data = new SaveData();
        //data.TeamColor = TeamColor;
        if (saveMode == 1)
        {
            highScorePlayerName = "";
            highScore = 0;
        } 
        data.highScorePlayerName = highScorePlayerName;
        data.highScore = highScore;
        
        Debug.Log("Save HighSore " + data.highScorePlayerName + " : " + data.highScore);
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
     
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //TeamColor = data.TeamColor;
            highScore = data.highScore;
            highScorePlayerName = data.highScorePlayerName;
        }
        Debug.Log("Load HighSore " + highScorePlayerName + " : " + highScore);
    }
}
