using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerAnimations : MonoBehaviour
{
    Animator anim;
    public Animator[] LevelSelect01Anims;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void LevelSelect01()
    {
        anim.SetTrigger("LevelSelect01");
    }

    public void BackToMainMenu()
    {
        anim.SetTrigger("MainMenu");
    }
}
