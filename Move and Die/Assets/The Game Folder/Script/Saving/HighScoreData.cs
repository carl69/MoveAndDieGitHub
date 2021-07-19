using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreData 
{
    public List<int> LevelIndex = new List<int>();
    public List<string> PlayerName = new List<string>();
    public List<int> Deaths = new List<int>();
    public List<float> levelTime = new List<float>();
    public List<int> inputCount = new List<int>();


    public HighScoreData(ScoreTracker ST)
    {
        LevelIndex = ST.LevelIndex;
        PlayerName = ST.PlayerName;
        Deaths = ST.Deaths;
        levelTime = ST.levelTime;
        inputCount = ST.inputCount;
    }
}
