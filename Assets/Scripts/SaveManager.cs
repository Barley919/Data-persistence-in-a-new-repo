using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public string bestPlrName;
    public string username;
    public int bestScore;

    private void Awake()
    {
        if(Instance != null)
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
        public string bestPlrName;
        public int bestScore;
    }

    public void SaveInfo()
    {
        SaveData intData = new SaveData();
        SaveData stringData = new SaveData();
        intData.bestScore = bestScore;
        stringData.bestPlrName = bestPlrName;

        string intJson = JsonUtility.ToJson(intData);
        string stringJson = JsonUtility.ToJson(stringData);

        File.WriteAllText(Application.persistentDataPath + "/saveintdata.json", intJson);
        File.WriteAllText(Application.persistentDataPath + "/savestringdata.json", stringJson);
    }

    public void LoadInfo()
    {
        string intPath = Application.persistentDataPath + "/saveintdata.json";
        string stringPath = Application.persistentDataPath + "/savestringdata.json";
        if(File.Exists(intPath))
        {
            string intJson = File.ReadAllText(intPath);
            SaveData intData = JsonUtility.FromJson<SaveData>(intJson);

            bestScore = intData.bestScore;
        }

        if(File.Exists(stringPath))
        {
            string stringJson = File.ReadAllText(stringPath);
            SaveData stringData = JsonUtility.FromJson<SaveData>(stringJson);

            bestPlrName = stringData.bestPlrName;
        }
    }
}
