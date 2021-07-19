using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float PlatformSpeed = 3;
    public bool Reverse = false;
    public float WaitTime = 1f;

    int currentPoint = 0;
    public List<Vector3> MovePoints = new List<Vector3>();



    private void Start()
    {
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {

        float dist = Vector3.Distance(MovePoints[currentPoint], transform.position);

        while (dist >= 0.5f) // the update moving goes on in here
        {

            dist = Vector3.Distance(MovePoints[currentPoint], transform.position); // update the distance

            transform.position = Vector3.MoveTowards(transform.position, MovePoints[currentPoint], PlatformSpeed * Time.deltaTime);


            yield return null; // waits a frame
        }

        yield return new WaitForSeconds(WaitTime);

        if (!Reverse)
        {

            if (currentPoint >= MovePoints.Count - 1)
            {
                currentPoint = 0;
            }
            else
            {
                currentPoint += 1;

            }
        }
        else
        {
            if (currentPoint <= 0)
            {
                currentPoint = MovePoints.Count -1;
            }
            else
            {
                currentPoint -= 1;

            }
        }

        StartCoroutine(Moving());
    }

}
