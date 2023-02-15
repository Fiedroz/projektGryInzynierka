using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    #region Debug
    public PlayerMovement player;
    public TextMeshProUGUI[] textDebugs;
    #endregion

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIDebug();
    }
    public void UIDebug()
    {
        textDebugs[0].text = "HP: " + player.playerMain.health + "/" + player.playerMain.maxHealth;
        textDebugs[1].text = "Armor: " + player.playerMain.armor;
        textDebugs[2].text = "Speed: " + player.playerMain.speed;
        textDebugs[3].text = "Attack: " + player.playerMain.attackPower;
        textDebugs[4].text = "ProtectionDome lvl: " + SkillsManager.protectionDomeLevel;
        textDebugs[5].text = "Beam lvl: " + SkillsManager.beamLevel;
    }
}
