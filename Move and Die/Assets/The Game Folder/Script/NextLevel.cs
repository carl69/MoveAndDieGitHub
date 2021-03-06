using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public bool LastLevel = false;
    GameManagerScript GMS;
    AudioSource AudioS;
    bool won = false;
    public GameObject LevelCanvas;
    public Animator anim;
    BulletSpawner BS;
    playerMovement PM;
    GameObject player;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PM = player.GetComponent<playerMovement>();
        BS = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BulletSpawner>();
        AudioS = GetComponent<AudioSource>();
        GMS = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
        LevelCanvas = GameObject.FindGameObjectWithTag("Score");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && won == false)
        {
            BS.SpawnBullets = false;// STOP CAMERA SPAWNING
            GMS.StopTurrets(); // STOP TURRETS FROM SHOOTING
            PM.enabled = false; // STOP PLAYER
            
            won = true;
            GMS.GameWon();
            AudioS.Play();
            anim.SetBool("Finish",true);
            StartCoroutine(Waiting());
            player.SetActive(false);
        }
    }
    IEnumerator Waiting()
    {
        LevelCanvas.GetComponent<OpenScoreUI>().ActivateUI();

        if (LevelCanvas != null)
        {

        }
        yield return new WaitForSeconds(3f);

        //LevelSelect();
    }
    public void LevelSelect()
    {
        if (!LastLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
