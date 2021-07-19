using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class ScoreTracker : MonoBehaviour
{
    int CurScene;
    [HideInInspector]
    public string CurPlayer = "Carl";
    public int inputs = 0;

    // StoredData
    public List<ScoreClass> Scores = new List<ScoreClass>();
    [Space]
    public List<int> LevelIndex = new List<int>();
    public List<string> PlayerName = new List<string>();
    public List<int> Deaths = new List<int>();
    public List<float> levelTime = new List<float>();
    public List<int> inputCount = new List<int>();


    GameManagerScript gm;


    //input tracking
    float dir = 0;
    float oldDir = 0;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
        gm.st = this;

        CurScene = SceneManager.GetActiveScene().buildIndex; // get scene index

        LoadData();
    }

    private void FixedUpdate()
    {
        float curDir = Input.GetAxis("Horizontal");
        if (curDir < 0)
        {
            dir = -1;
        }
        else if (curDir > 0)
        {
            dir = 1;
        }

        if (dir != oldDir)
        {
            oldDir = dir;
            CountInputs();
        }
    }

    private void Update()
    {


        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("crouch") || Input.GetButtonDown("Dash"))
        {
            CountInputs();
        }

        // game testing
        if (Input.GetKeyDown(KeyCode.P))
        {
            //CheckScore();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //LoadData();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //RemoveHighScores();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            //sortScoreByTime(2);
        }
    }

    void CountInputs()
    {
        inputs += 1;
    }

    public void sortScoreByTime(int SelectedScrene)
    {
        Scores.Clear();
        // add the scoreClasses
        for (int i = 0; i < LevelIndex.Count; i++)
        {
            if (LevelIndex[i] == SelectedScrene) // check if the level is for the selected scene
            {
                ScoreClass s = new ScoreClass();
                s.PlayerName = PlayerName[i];
                s.Deaths = Deaths[i];
                s.MatchTime = levelTime[i];

                s.Inputs = inputCount[i];


                Scores.Add(s);
            }
        }

        // sort based on time in match
        Scores = Scores.OrderBy(w => w.MatchTime).ToList();
        
    }

    void RemoveHighScores()
    {
        LevelIndex.Clear();
        PlayerName.Clear();
        Deaths.Clear();
        levelTime.Clear();
        if (inputCount.Count > 0)
        {
            inputCount.Clear();

        }

        SubmitScore();
    }

    public void CheckScore()
    {

        LevelIndex.Add(CurScene);
        PlayerName.Add(CurPlayer);
        Deaths.Add(gm.PlayerDeaths);
        levelTime.Add(gm.TimeSpendt);
        inputCount.Add(inputs);

        SubmitScore();
    }

    void SubmitScore()
    {
        //CurPlayer

        SaveScore.SavePlayerScore(this);
    }

    void LoadData()
    {
        HighScoreData data = SaveScore.LoadPlayerScore();
        LevelIndex = data.LevelIndex;
        PlayerName = data.PlayerName;
        Deaths = data.Deaths;
        levelTime = data.levelTime;
        inputCount = data.inputCount;
    }
}
