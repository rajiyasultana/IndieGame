using UnityEngine;
using System.IO;


public class SaveManager : MonoBehaviour
{
    private static string savePath;
    void Start()
    {
        savePath = Application.persistentDataPath + "/gameData.json";
    }

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
        return null;
    }
}
