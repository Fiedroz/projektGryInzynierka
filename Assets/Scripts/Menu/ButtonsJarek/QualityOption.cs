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

    private NavigationControls navigationControls;
    // Start is called before the first frame update
    void Start()
    {
        currentId = 1;
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        navigationControls = new NavigationControls();
        navigationControls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentId)
        {
            case 0:
                buttonText.text = "LOW";
                break;
            case 1:
                buttonText.text = "MEDIUM";
                break;
            case 2:
                buttonText.text = "HIGH";
                break;
        }
        if (button.isSelected)
        {
            QualitySettings.SetQualityLevel(currentId);
            if (navigationControls.Navigation.GoLeft.triggered && navigationControls.Navigation.GoLeft.ReadValue<float>() > 0 && currentId > 0) {
                currentId--;
            }
            else if(navigationControls.Navigation.GoRight.triggered && navigationControls.Navigation.GoRight.ReadValue<float>() > 0 && currentId < 2) { 
                currentId++;
            }
        }
    }
}
