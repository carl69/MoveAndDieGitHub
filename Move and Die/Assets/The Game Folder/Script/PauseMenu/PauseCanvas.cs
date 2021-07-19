using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    public static bool IsOn = false;

    private void OnEnable()
    {
        IsOn = true;
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        IsOn = false;
        Time.timeScale = 1;
    }
}
