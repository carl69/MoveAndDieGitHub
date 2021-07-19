using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float Speed;
    [HideInInspector]
    public GameManagerScript GMS;
    public GameObject impactMark;


    void Update()
    {
        transform.localPosition += transform.rotation * Vector3.forward * Speed * Time.deltaTime;

        BulletUpdate();
    }

    public virtual void BulletUpdate()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<playerMovement>().PlayerGotHit();
        }
        else if (other.tag != "Trigger") 
        {
            GMS.BS.Remove(this); // happens if bullets hits walls or other things

        }

        if (other.tag != "Trigger")
        {
            DestroyBullet();
        }
    }


    public void DestroyBullet()
    {
        Instantiate(impactMark, gameObject.transform.position, gameObject.transform.rotation);
        if (gameObject != null)
        {
            Destroy(this.gameObject); // bullet gets destroyed

        }

    }
}