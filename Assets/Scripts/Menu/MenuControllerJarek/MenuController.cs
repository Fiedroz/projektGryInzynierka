using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] MenuButtonTest[] buttons;
    [SerializeField] bool isMainPanel = false;
    public int index;
    int menuLength;
    void Start()
    {
        if(!isMainPanel)
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
        if (Input.GetKeyDown(KeyCode.DownArrow))
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
        else if (Input.GetKeyDown(KeyCode.UpArrow))
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
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            buttons[index].DoAction();
            index = 0;
        }
    }
}
