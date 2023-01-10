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
    #endregion

    private void Update()
    {

    }
    public void UIDebug(Vector3 way, Vector3 move, Transform playerTransform)
    {
        textDebugs[0].text = "Way: " + way;
        textDebugs[1].text = "Move: " + move;
        textDebugs[2].text = "PlayerRot: " + playerTransform.rotation;
    }
}
