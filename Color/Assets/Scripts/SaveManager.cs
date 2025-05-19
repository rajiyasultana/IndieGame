using UnityEngine;
using System.IO;


public class SaveManager : MonoBehaviour
{
    private static readonly string savePath = Application.persistentDataPath + "/gameData.json";

    public static void SaveData(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved to " + savePath);
    }

    public static GameData LoadData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            // Create default data and save it
            GameData defaultData = new GameData
            {
                highScore = 0,
                bestTime = 0f
            };

            SaveData(defaultData);
            return defaultData;
        }
    }
}
