using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderOption : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] MenuButtonTest button;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnGoRight()
    {
        if (button.isSelected)
        {
            slider.value++;
        } 
    }
    public void OnGoLeft()
    {
        if (button.isSelected)
        {
            slider.value--;
        }
    }
}
