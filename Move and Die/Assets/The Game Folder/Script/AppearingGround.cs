using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingGround : MonoBehaviour
{
    public bool TempBool_MakeThisFalseOnTheNewBlocksGeir = true;


    public bool appear;
    public GameObject child;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<playerMovement>().Blocks.Add(this);
    }


    public void Appear()
    {
        if (TempBool_MakeThisFalseOnTheNewBlocksGeir)
        {
            child = this.gameObject.transform.GetChild(0).gameObject;

        }
        else
        {
            child = this.gameObject;
        }

        child.GetComponent<DissapearingGround>().DestroyBlock();
        child.SetActive(true); child.GetComponent<Animator>().Play("Idle", -1, 0f);
    }
}
