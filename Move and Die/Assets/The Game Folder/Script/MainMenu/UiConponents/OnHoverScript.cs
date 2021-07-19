using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverScript : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Hover()
    {
        anim.SetBool("Hover", true);
    }

    public void StopHover()
    {
        anim.SetBool("Hover", false);

    }
}
