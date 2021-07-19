using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScoreUI : MonoBehaviour
{
    public GameObject ScoreUI;
    public GameObject TabScoreUI; 
    public void ActivateUI()
    {
        ScoreUI.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Tab"))
        {
            TabScoreBoard();
        }
        if (Input.GetButtonUp("Tab"))
        {
            TabScoreBoardOff();
        }
    }

    public void TabScoreBoard()
    {
        TabScoreUI.SetActive(true);

    }

    void TabScoreBoardOff()
    {
        TabScoreUI.SetActive(false);

    }
}
