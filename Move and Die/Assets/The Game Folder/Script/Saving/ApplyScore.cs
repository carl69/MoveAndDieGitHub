using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplyScore : MonoBehaviour
{
    public bool lastLevel = false;

    public ScoreTracker st;
    GameManagerScript gm;

    public Text NameUI;
    public Text DeathUI;
    public Text TimeUI;
    public Text InputUI;

    public GameObject ApplyScoreButtonUI;

    public GameObject LoadingScene;
    private void OnEnable()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();

        DeathUI.text = gm.PlayerDeaths.ToString();
        TimeUI.text = gm.TimeSpendt.ToString();
        InputUI.text = st.inputs.ToString();
    }

    public void ApplyToScoreButton()
    {
        ApplyScoreButtonUI.SetActive(false); // turns the button off so you can't apply your score more then once

        st.CurPlayer = NameUI.text;
        st.CheckScore();


        if (!lastLevel)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            //SceneManager.LoadScene(0);
            LoadLevel(0);
        }
    }

    public void LoadLevel(int SceneIndex)
    {
        StartCoroutine(LoadAsyncScene(SceneIndex));
        LoadingScene.SetActive(true);
    }

    IEnumerator LoadAsyncScene(int SceneIndex)
    {
        AsyncOperation sceneLoadData = SceneManager.LoadSceneAsync(SceneIndex);

        while (sceneLoadData.isDone == false)
        {
            Debug.Log(sceneLoadData.progress);

            yield return null;
        }
    }

}
