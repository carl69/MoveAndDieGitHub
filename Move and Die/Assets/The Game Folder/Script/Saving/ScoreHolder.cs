using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreHolder : MonoBehaviour
{
    public int Rank;

    public ScoreTracker st;

    public Text NameUI;
    public Text DeathUI;
    public Text TimeUI;
    public Text InputUI;


    void OnEnable()
    {
        st.sortScoreByTime(SceneManager.GetActiveScene().buildIndex); // sort


        if (st.Scores.Count -1 < Rank)
        {

        }
        else
        {


            ScoreClass s = st.Scores[Rank];

            NameUI.text = s.PlayerName;
            DeathUI.text = "Deaths: " + s.Deaths.ToString();
            TimeUI.text = "Time: " + s.MatchTime.ToString();
            InputUI.text = "Inputs: " + s.Inputs.ToString();
        }



        
    }
}
