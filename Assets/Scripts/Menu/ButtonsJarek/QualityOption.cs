using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QualityOption : MonoBehaviour
{
    public int currentId;
    [SerializeField] MenuButtonTest button;
    [SerializeField] TextMeshProUGUI buttonText;

    const string SETTING_LOW = "LOW";
    const string SETTING_MEDIUM = "MEDIUM";
    const string SETTING_HIGH = "HIGH";
    // Start is called before the first frame update
    void Start()
    {
        currentId = 1;
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnGoRight()
    {
        if(button.isSelected && currentId < 2)
        {
            currentId++;
            UpdateText();
        }
    }
    public void OnGoLeft()
    {
        if(button.isSelected && currentId > 0)
        {
            currentId--;
            UpdateText();
        }
    }
    private void UpdateText()
    {
        switch (currentId)
        {
            case 0:
                buttonText.text = SETTING_LOW;
                break;
            case 1:
                buttonText.text = SETTING_MEDIUM;
                break;
            case 2:
                buttonText.text = SETTING_HIGH;
                break;
        }
    }
}
