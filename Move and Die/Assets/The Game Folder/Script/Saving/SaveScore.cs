
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveScore
{

    public static void SavePlayerScore(ScoreTracker score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Score.uwu";
        FileStream stream = new FileStream(path, FileMode.Create);

        HighScoreData data = new HighScoreData(score);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static HighScoreData LoadPlayerScore()
    {
        string path = Application.persistentDataPath + "/Score.uwu";
        Debug.Log("Saved to: " + path);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            HighScoreData data = formatter.Deserialize(stream) as HighScoreData;
            stream.Close();
            return data;


        }
        else
        {
            Debug.Log("Savefile not found in: " + path);
            return null;
        }
    }
}
