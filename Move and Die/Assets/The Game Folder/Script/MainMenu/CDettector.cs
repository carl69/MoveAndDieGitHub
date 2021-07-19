using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDettector : MonoBehaviour
{
    public static bool HasController = false;
    public static bool ControllerAdded = false;

    public bool KeepChecking = false;

    bool registeredController = false;


    void Awake()
    {
        ControllerAdded = false;

        string[] names = Input.GetJoystickNames();

        HasController = false;
        for (int x = 0; x < names.Length; x++)
        {
            if (names[x].Length == 19)
            {
                HasController = true;

            }
            if (names[x].Length == 33)
            {
                HasController = true;

            }
        }


    }

    private void Update()
    {
        if (KeepChecking)
        {
            string[] names = Input.GetJoystickNames();

            HasController = false;
            for (int x = 0; x < names.Length; x++)
            {
                if (names[x].Length == 19)
                {
                    HasController = true;

                }
                if (names[x].Length == 33)
                {
                    HasController = true;

                }
            }

            if (!HasController)
            {
                registeredController = false;
            }

            if (HasController)
            {
                GetController();
            }
            
        }
    }

    void GetController()
    {
        if (!registeredController)
        {
            registeredController = true;

            ControllerAdded = true;
        }
        
    }
}
