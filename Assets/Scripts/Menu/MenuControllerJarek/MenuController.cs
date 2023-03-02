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
        
    }
    public void OnGoDown()
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
    public void OnGoUp()
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
    public void OnConfirm()
    {
        buttons[index].DoAction();
        index = 0;
    }
    public void OnReturn()
    {
        buttons[menuLength].DoAction();
        index = 0;
    }
}
