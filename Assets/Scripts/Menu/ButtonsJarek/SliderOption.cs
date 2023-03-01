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
        slider.onValueChanged.AddListener((v) =>
        {
            Debug.Log(v.ToString());
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (button.isSelected)
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                slider.value--;
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                slider.value++;
            }
        }
    }
}
