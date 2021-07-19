using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowPlayer : MonoBehaviour
{
    Transform player;
    [SerializeField] float DistanceDamp = 10f;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 Target = new Vector3(player.position.x, 0, 0);
        Vector3 LerpPos = Vector3.Lerp(transform.position, Target, DistanceDamp * Time.deltaTime);
        transform.position = LerpPos;
    }
}
