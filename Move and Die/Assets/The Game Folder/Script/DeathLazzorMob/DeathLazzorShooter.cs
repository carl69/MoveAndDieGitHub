using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLazzorShooter : MonoBehaviour
{
    public int fireTicks = 4;
    int curFireTick = 4;

    public Animator anim;

    float dir;
    float oldDir;

    // Start is called before the first frame update
    void Start()
    {
        curFireTick = fireTicks;
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

            spawnBullet();
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("crouch") || Input.GetButtonDown("Dash"))
        {
            spawnBullet();
        }
    }

    void spawnBullet()
    {
        curFireTick -= 1;

        if (curFireTick  == 1)
        {
            anim.SetTrigger("Ready");
        }

        if (curFireTick <= 0)
        {
            curFireTick = fireTicks;// resets timer

            anim.SetTrigger("Shoot");


        }
    }
}
