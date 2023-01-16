using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public PlayerMain playerMain;
    public PlayerMovement playerMovement;
    public UIController uiController;
    public SkillsManager skillsManager;

    private float startTime = 0f;
    public TextMeshProUGUI timeText;
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        startTime = Time.time;
    }

    private void Update()
    {
        Timer();
    }
    private void Timer()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString("00");
        string seconds = ((int)t%60).ToString("00");
        timeText.text = minutes+":"+seconds;
    }
    public enum EnemyType{
        Basic,
        Fridge,
        Oven,
        Microwave
    }
}
