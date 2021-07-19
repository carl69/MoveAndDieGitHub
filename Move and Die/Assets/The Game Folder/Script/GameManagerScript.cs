using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // deaths
    public int PlayerDeaths = 0;

    //
    public int GameMod = 1;
    public List<MyTurret> Turrets = new List<MyTurret>();

    // highscore
    [HideInInspector]
    public ScoreTracker st;

    // timer
    float startTime = 0;
    float endTime = 0;
    [HideInInspector]
    public float TimeSpendt;

    // TURRETS
    List<MyTurret> MTList = new List<MyTurret>();
    public GameObject deadPlayer;
    public Transform playerPos;
    // Bullets
    public List<bulletScript> BS = new List<bulletScript>();
    public void playerDeath()
    {
        foreach (bulletScript bulletS in BS)
        {
            //BS.Remove(bulletS);

            bulletS.DestroyBullet();
        }
        BS.Clear();
        GameObject explosionInstant=Instantiate(deadPlayer, playerPos.position, playerPos.rotation);
        Destroy(explosionInstant, 3);
        deathCount();
    }

    public void GameWon()
    {
        foreach (bulletScript bulletS in BS)
        {
            //BS.Remove(bulletS);

            bulletS.DestroyBullet();
        }
        BS.Clear();

        endTime = Time.time;
        TimeSpendt = endTime - startTime;

        //st.CheckScore();  // not getting checked here anymore ;^)
    }

    // GAMEMODE
    private void Start()
    {
        GameMod = PlayerPrefs.GetInt("GameMode",1); // LOAD THE GAMEMODE
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Turret"))
        {
            MTList.Add(i.GetComponent<MyTurret>());
        }
        // MT = GameObject.FindGameObjectsWithTag("Turret")

        startTime = Time.time;
    }

    private void Update()
    {

        //if (Input.GetKey(KeyCode.Z))
        //{
        //    Time.timeScale = 0.75f;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //}

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Gamemode 1");
            PlayerPrefs.SetInt("GameMode", 1); // SAVE THE GAMEMODE
            foreach (MyTurret l in Turrets)
            {
                l.GameMod = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Debug.Log("Gamemode 2");
            //PlayerPrefs.SetInt("GameMode", 2); // SAVE THE GAMEMODE
            //foreach (MyTurret l in Turrets)
            //{
            //    l.GameMod = 2;
            //}
        }

    }
    public void deathCount()
    {
        PlayerDeaths += 1;
    }

    public void StopTurrets()
    {
        foreach (MyTurret i in MTList)
        {
            i.Deactivated = true;
        }
    }
}
