using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject LoadingScene;

    public void QUITDAGAME()
    {
        Application.Quit();
    }


   public void Tutorial()
    {
        loadingLevelX(1);

    }

    public void SkipTutorial()
    {
        loadingLevelX(2);

    }
    public void loadingLevelX(int indexNr)
    {
        LoadingScene.SetActive(true);

        SceneManager.LoadSceneAsync(indexNr);

    }
    //public void LevelSelect()
    //{
    //    SceneManager.LoadScene(1);

    //}
}
