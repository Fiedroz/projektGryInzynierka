using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] MenuButtonTest[] buttons;
    [SerializeField] bool isMainPanel = false;
    public int index;
    int menuLength;

    private NavigationControls navigationControls;

    void Start()
    {
        navigationControls = new NavigationControls();
        navigationControls.Enable();

        if (!isMainPanel)
        {
            gameObject.SetActive(false);
        }
        index = 0;
        menuLength = buttons.Length - 1;
    }
    void Update()
    {
        if (gameObject.activeSelf) detectChange();
    }
    private void detectChange()
    {
        if (navigationControls.Navigation.GoDown.triggered && navigationControls.Navigation.GoDown.ReadValue<float>() > 0)
        {
            if (index >= menuLength)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
        else if (navigationControls.Navigation.GoUp.triggered && navigationControls.Navigation.GoUp.ReadValue<float>() > 0)
        {
            if (index <= 0)
            {
                index = menuLength;
            }
            else
            {
                index--;
            }
        }
        else if (navigationControls.Navigation.Confirm.triggered && navigationControls.Navigation.Confirm.ReadValue<float>() > 0)
        {
            buttons[index].DoAction();
            index = 0;
        }

        if (navigationControls.Navigation.Return.triggered && navigationControls.Navigation.Return.ReadValue<float>() > 0)
        {
            buttons[buttons.Length - 1].DoAction();
            index = 0;
        }
    }
}
