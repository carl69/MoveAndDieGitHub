using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLazzorMovement : MonoBehaviour
{
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 stageDimensions = new Vector3(player.position.x + 21, 0, 0);

        transform.position = stageDimensions;

    }
}
