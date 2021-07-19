using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{

    public string[] StageOneAttacks;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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

        if (dir != oldDir)
        {
            oldDir = dir;

            Attack();
        }
    }
    void Update()
    {

            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("crouch") || Input.GetButtonDown("Dash"))
            {
            Attack();
            }
    }

    void Attack()
    {
        // add cooldown here


        // select attack
        int attack = Random.Range(0, StageOneAttacks.Length);

        // get the animation here
        anim.SetTrigger(StageOneAttacks[attack]);
        
    }
}
