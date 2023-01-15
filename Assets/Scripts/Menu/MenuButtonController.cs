using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public int index;
    [SerializeField] private bool keyDown;
    [SerializeField] private int maxIndex;
    [SerializeField] private int minIndex;
    [SerializeField] private GameObject settingsGO;
    [SerializeField] private GameObject generalSettingsGO;
    [SerializeField] private GameObject controlsSettingsGO;
    [SerializeField] private GameObject audioSettingsGO;
    [SerializeField] private GameObject videoSettingsGO;
    private GameObject[] settingsGOs;
    private enum IESettings
    {
        general = 4,
        controls = 5,
        audio = 6,
        video = 7
    }

    void Start()
    {
        settingsGOs = new GameObject[] { generalSettingsGO, controlsSettingsGO, audioSettingsGO, videoSettingsGO };
        //for (int i = 0; i < settingsGOs.Length; i++)
        //{
        //    settingsGOs[i].SetActive(false);
        //}
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") > 0)
                {
                    if (index < maxIndex)
                    {
                        index++;
                    }
                    else
                    {
                        index = minIndex;
                    }
                }
                else if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") < 0)
                {
                    if (index > minIndex)
                    {
                        index--;
                    }
                    else
                    {
                        index = maxIndex;
                    }
                }
                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
        }

        if (Input.GetAxis("Cancel") > 0 && minIndex > 2)
        {
            BackToMain();
        }

        switch (index)
        {
            case (int)IESettings.general:
                settingsGOs[0].SetActive(true);
                break;
            case (int)IESettings.controls:
                settingsGOs[1].SetActive(true);
                break;
            case (int)IESettings.audio:
                settingsGOs[2].SetActive(true);
                break;
            case (int)IESettings.video:
                settingsGOs[3].SetActive(true);
                break;
        }

        for (int i = 4; i < settingsGOs.Length + 4; i++)
        {
            if (i == index)
            {
                settingsGOs[i - 4].SetActive(true);
            }
            else
            {
                settingsGOs[i - 4].SetActive(false);
            }
        }

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenSettings()
    {
        Debug.Log("Settings opened!");
        maxIndex = 7;
        minIndex = 3;
        index = 4;
        settingsGO.SetActive(true);
    }

    public void OpenPlay()
    {
        Debug.Log("Play opened!");
        SceneManager.LoadScene(1);
    }

    public void BackToMain()
    {
        Debug.Log("Back To Main!");
        maxIndex = 2;
        minIndex = 0;
        index = 1;
        settingsGO.SetActive(false);
    }


}
