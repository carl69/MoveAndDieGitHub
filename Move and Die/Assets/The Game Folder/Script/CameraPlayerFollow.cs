using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    //public Vector3 PlayerPos;
    Transform Player;
    public float moveSpeed = 10;
    public Transform min, max;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector3 targetPos = new Vector3(
        //    Player.position.x + PlayerPos.x,
        //    transform.position.y,
        //    PlayerPos.z);





    Vector3 targetPos = new Vector3(
        Mathf.Clamp(Player.position.x, min.position.x, max.position.x),
        Mathf.Clamp(Player.position.y, min.position.y, max.position.y),
        Player.position.z - 20f);

    transform.position = Vector3.Lerp(
        transform.position,
        targetPos,
        moveSpeed * Time.fixedDeltaTime);
    }
}
