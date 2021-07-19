using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTrigger : MonoBehaviour
{

    public float ForceKick = 10f;

    private void OnTriggerEnter(Collider t)
    {
        if (t.CompareTag("Player"))
        {

            t.GetComponent<Rigidbody>().velocity = transform.right * ForceKick;
        }
    }
}
