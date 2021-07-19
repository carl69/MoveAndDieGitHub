
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemSelecting : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject firstSelectedButton;

    GameObject selectObject;
    private void Start()
    {
        StartCoroutine(SetButton());

    }

    IEnumerator SetButton()
    {
        yield return new WaitForEndOfFrame();

        selectObject = firstSelectedButton; 

        if (CDettector.HasController)
        {
            eventSystem.SetSelectedGameObject(firstSelectedButton);

        }
    }
    bool controller = false;
    private void Update()
    {

        if (CDettector.ControllerAdded)
        {
            print("Controller Added");
            CDettector.ControllerAdded = false;
            eventSystem.SetSelectedGameObject(selectObject);
            controller = true;
        }

        if (!CDettector.HasController)
        {
            if (controller)
            {
                controller = false;
                eventSystem.SetSelectedGameObject(null);
            }
        }
    }


    public void SelectSelected(GameObject select)
    {
        selectObject = select;

        if (CDettector.HasController)
        {
            eventSystem.SetSelectedGameObject(select);
        }
    }
}
