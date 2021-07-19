using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomBullet : bulletScript
{
    public float RotateRate = 5;

    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void BulletUpdate()
    {
        var dir = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, dir, RotateRate * Time.deltaTime);

    }
}
