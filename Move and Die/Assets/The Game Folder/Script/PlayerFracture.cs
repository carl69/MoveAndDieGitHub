using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFracture : MonoBehaviour
{
    public float minForce;
    public float maxForce;
    public float radius;

    private void Start()
    {
        Explosion();
    }
    public void Explosion()
    {
        foreach(Transform t in transform)
        {
            var rb = t.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(Random.Range(minForce, maxForce),transform.position, radius);
            }
        }
    }
}
