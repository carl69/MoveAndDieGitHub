using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTurret : MonoBehaviour
{
    public GameObject[] target;
    public float objectDistance;
    public float rotationDamping;
    public GameObject bulletSpawner;
    public GameObject bullet;

    public float countdownToBulletTime;
    public int bulletTimer;

    GameManagerScript GMScript;
    public int GameMod = 1;

    public bool Deactivated;
    [HideInInspector]
    public bool playerInRange = false;
    public GameObject LazzorPointer;
    SpriteRenderer SR_lazzor;
    Transform player;
    public LayerMask ValidTargets;

    // Start is called before the first frame update
    void Start()
    {
        GameMod = PlayerPrefs.GetInt("GameMode", 1);

        target = GameObject.FindGameObjectsWithTag("Player");
        GMScript = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
        GMScript.Turrets.Add(this);

        SR_lazzor = LazzorPointer.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    float dir = 0;
    float oldDir = 0;
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

        if (dir != oldDir && GameMod == 1)
        {
            oldDir = dir;
            countdownToBulletTime -= 1;

            spawnBullet();
        }



 

        
    }


    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            Vector3 rayDir = (transform.position - player.position) * -1;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, rayDir, out hit, 999999f, ValidTargets))
            {
                float dis = Vector3.Distance(hit.point, transform.position);
                SR_lazzor.size = new Vector2(dis, 0.1f);
            }
        }

        lookAtPlayer();
        for (var i = 0; i < target.Length; i++)
        {

            objectDistance = Vector3.Distance(target[i].transform.position, transform.position);

            if (objectDistance < 20f)
            {
                
            }
        }
        if (GameMod == 1)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("crouch") || Input.GetButtonDown("Dash"))
            {
                countdownToBulletTime -= 1;
                spawnBullet();

            }
        }
        else if (GameMod == 2)
        {
            countdownToBulletTime -= 1 *Time.deltaTime;
            spawnBullet();
        }

    }
    void lookAtPlayer()
    {
        for (var i = 0; i < target.Length; i++)
        {

            Vector3 playerOffset = new Vector3(target[i].transform.position.x,
            target[i].transform.position.y + 1,
            target[i].transform.position.z);

            Quaternion rotation = Quaternion.LookRotation(playerOffset - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
        }
    }

    void spawnBullet()
    {
        if (playerInRange)
        {
            if (countdownToBulletTime <= 0 && !Deactivated)
            {
                GameObject SpawnedBullet = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                // Bullet Var
                bulletScript bs = SpawnedBullet.GetComponent<bulletScript>();
                bs.GMS = GMScript;
                // add bullet to the list
                GMScript.BS.Add(bs);
                // Bullet rot

                countdownToBulletTime = bulletTimer;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
            LazzorPointer.SetActive(true);
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        DeactivateTurrt();
    //    }
    //}

    public void DeactivateTurrt()
    {
        playerInRange = false;
        LazzorPointer.SetActive(false);
        SR_lazzor.size = new Vector2(1, 1);
    }
}