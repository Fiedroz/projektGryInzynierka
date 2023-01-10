using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    #region Debug
    public TextMeshProUGUI[] textDebugs;
    public Vector3 way = new Vector3();
    public Vector3 move= new Vector3();
    public Transform playerTransform;
    #endregion

    private void Update()
    {
        UIDebug();
    }
    void UIDebug()
    {
        textDebugs[0].text = "Way: " + way;
        textDebugs[1].text = "Move: " + move;
        textDebugs[2].text = "PlayerRot: " + playerTransform.rotation;
    }
}
