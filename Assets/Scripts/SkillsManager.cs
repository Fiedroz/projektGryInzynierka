using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager: MonoBehaviour
{
    PlayerMain playerMain;

    public int garlicRadius = 10;
    public float garlicDamage = 10;

    public static float protectionDomeRadius = 3.8f;
    public static float protectionDomeDamage = 5f;
    public static float protectionDomeSlow = 3f;
    public static float protectionDomeRefresh = 0.5f;
    public static int protectionDomeLevel = 0;
    public static GameObject protectionDomeObject;

    public static float beamRandomRadius = 15f;
    public static float beamRadius = 3.8f;
    public static float beamDamage = 15f;
    public static float beamSlow = 100f;
    public static float beamSlowDuration = 2f;//1-2
    public static float beamRefresh = 2f;
    public static int beamLevel = 0;
    private void Start()
    {
        playerMain = GameManager.Instance.playerMain;
    }
    public struct SkillsData
    {
        public Skills skill;
        public float health;
        public float armor;
        public float speed;
        public float damage;
        public int level;
        public bool upgraded;
    }
    public struct PassiveSkillsData
    {
        public PassiveSkills passiveSkill;
        public float health;
        public float armor;
        public float speed;
        public float damage;
        public int level;
        public bool upgraded;
    }
    public enum Skills
    {
        ProtectionDome,//creates protective dome that damages enemies that enters it and slows them
        Beam,//shoots down a beam from the sky that damages and stuns enemies for 1-2 seconds
        BackpackRocketAttack,//shoots rockets upwards from players backpack
        Extinguisher,//heavly damages players infront of the player every 6-8 seconds
        LaserEyes,//every 3-5 seconds shoots laser beam infront of the player
        Wrench,//hits enemies infront of the player in small radius
        Freezer,//shoots ice cube in random direction that freezes enemies for 1-3 seconds
        BananaPeels,//shoots out bananas from backpack in random directions, banana will stay on the floor
                    //for 1-5 seconds damaging enemies that cross it
        Juicer,//every 5-10 seconds leaves trail of juice that damages and slows enemies
        KitchenKnifes,//every 5-10 secondsthrows knifes in random direction, enemy and bosses hit by it
                      //instantly dies
        
    }
    public enum PassiveSkills
    {
        Coffee,//adds more speed
        Letuce,//adds more hp
        BeefJerky,//adds more attack power
        Vitamins,//adds more armor
        Potato,//heals for small hp
        AppleJuice,//heals for small amount 
        Garlic//heals for small amout and dmg nearby enemies for 5 seconds

    }
    public void Coffee()
    {
        PassiveSkillsData skill;

        skill.passiveSkill = SkillsManager.PassiveSkills.Coffee;
        skill.health = 0;
        skill.armor = 0;
        skill.speed = 1;
        skill.damage = 0;
        skill.level = 0;
        skill.upgraded = false;

        playerMain.health += skill.health;
        playerMain.armor += skill.armor;
        playerMain.speed += skill.speed;
        playerMain.attackPower += skill.damage;

        playerMain.passiveSkillsDatas.Add(skill);
    }
    public void Letuce()
    {
        PassiveSkillsData skill;

        skill.passiveSkill = SkillsManager.PassiveSkills.Letuce;
        skill.health = 25;
        skill.armor = 0;
        skill.speed = 0;
        skill.damage = 0;
        skill.level = 0;
        skill.upgraded = false;

        playerMain.health += skill.health;
        playerMain.maxHealth += skill.health;
        playerMain.armor += skill.armor;
        playerMain.speed += skill.speed;
        playerMain.attackPower += skill.damage;

        playerMain.passiveSkillsDatas.Add(skill);
        playerMain.CheckHP();
    }
    public void BeefJerky()
    {
        PassiveSkillsData skill;

        skill.passiveSkill = SkillsManager.PassiveSkills.BeefJerky;
        skill.health = 0;
        skill.armor = 0;
        skill.speed = 0;
        skill.damage = 5;
        skill.level = 0;
        skill.upgraded = false;

        playerMain.health += skill.health;
        playerMain.armor += skill.armor;
        playerMain.speed += skill.speed;
        playerMain.attackPower += skill.damage;

        playerMain.passiveSkillsDatas.Add(skill);
    }
    public void Vitamins()
    {
        PassiveSkillsData skill;

        skill.passiveSkill = SkillsManager.PassiveSkills.Vitamins;
        skill.health = 0;
        skill.armor = 3;
        skill.speed = 0;
        skill.damage = 0;
        skill.level = 0;
        skill.upgraded = false;

        playerMain.health += skill.health;
        playerMain.armor += skill.armor;
        playerMain.speed += skill.speed;
        playerMain.attackPower += skill.damage;

        playerMain.passiveSkillsDatas.Add(skill);
    }
    public void Potato()
    {
        PassiveSkillsData skill;

        skill.passiveSkill = SkillsManager.PassiveSkills.Potato;
        skill.health = 15f;
        skill.armor = 0;
        skill.speed = 0;
        skill.damage = 0;
        skill.level = 0;
        skill.upgraded = false;

        playerMain.health += skill.health;
        playerMain.armor += skill.armor;
        playerMain.speed += skill.speed;
        playerMain.attackPower += skill.damage;

        playerMain.passiveSkillsDatas.Add(skill);
        playerMain.CheckHP();
    }
    public void AppleJuice()
    {
        PassiveSkillsData skill;

        skill.passiveSkill = SkillsManager.PassiveSkills.AppleJuice;
        skill.health = 20;
        skill.armor = 0;
        skill.speed = 0;
        skill.damage = 0;
        skill.level = 0;
        skill.upgraded = false;

        playerMain.health += skill.health;
        playerMain.armor += skill.armor;
        playerMain.speed += skill.speed;
        playerMain.attackPower += skill.damage;

        playerMain.passiveSkillsDatas.Add(skill);
        playerMain.CheckHP();
    }
    public void Garlic()
    {
        PassiveSkillsData skill;

        skill.passiveSkill = SkillsManager.PassiveSkills.Garlic;
        skill.health = 20;
        skill.armor = 0;
        skill.speed = 0;
        skill.damage = 0;
        skill.level = 0;
        skill.upgraded = false;

        playerMain.health += skill.health;
        playerMain.armor += skill.armor;
        playerMain.speed += skill.speed;
        playerMain.attackPower += skill.damage;

        playerMain.passiveSkillsDatas.Add(skill);
        playerMain.CheckHP();
        GarlicAttack(garlicDamage);
    }
    public void GarlicAttack(float garlicDamage)
    {
        StartCoroutine(playerMain.GarlicAttack(garlicRadius,garlicDamage));
    }
    public void ProtectionDome()
    {
        SkillsData skill;

        skill.skill = SkillsManager.Skills.ProtectionDome;
        skill.health = 0;
        skill.armor = 0;
        skill.speed = 0;
        skill.damage = 0;
        skill.level = 1;
        skill.upgraded = false;

        playerMain.health += skill.health;
        playerMain.armor += skill.armor;
        playerMain.speed += skill.speed;
        playerMain.attackPower += skill.damage;
        if(!playerMain.skillsDatas.Contains(skill)) {
            protectionDomeLevel = skill.level;
            playerMain.skillsDatas.Add(skill);
            playerMain.CheckHP();
            ProtectionDomeStart();
        }
        else
        {
            protectionDomeLevel++;
            ProtectionDomeUpgrade(protectionDomeLevel);
        }
    }
    public void ProtectionDomeUpgrade(int level) 
    {
        switch (level)
        {
            case 2: 
                {
                    protectionDomeObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    protectionDomeObject.transform.GetChild(0).transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    protectionDomeRadius = 5.8f;
                    protectionDomeDamage += 1;
                    protectionDomeSlow += 1;
                    protectionDomeRefresh -= 0.1f;
                    break; 
                }
            case 3:
                {
                    protectionDomeObject.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
                    protectionDomeObject.transform.GetChild(0).transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
                    protectionDomeRadius = 6.4f;
                    protectionDomeDamage += 1;
                    protectionDomeSlow += 1;
                    protectionDomeRefresh -= 0.1f;
                    break;
                }
            case 4:
                {
                    protectionDomeObject.transform.localScale = new Vector3(2f, 2f, 2f);
                    protectionDomeObject.transform.GetChild(0).transform.localScale = new Vector3(2f, 2f, 2f);
                    protectionDomeRadius = 8f;
                    protectionDomeDamage += 2;
                    protectionDomeSlow += 1;
                    protectionDomeRefresh -= 0.1f;
                    break;
                }
            case 5:
                {
                    protectionDomeObject.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
                    protectionDomeObject.transform.GetChild(0).transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
                    protectionDomeRadius = 9f;
                    protectionDomeDamage += 2;
                    protectionDomeSlow += 1;
                    protectionDomeRefresh -= 0.1f;
                    break;
                }
        }
        
    }
    public void ProtectionDomeStart()
    {
        StartCoroutine(playerMain.ProtectionDome());
    }
    public void Beam()
    {
        SkillsData skill;

        skill.skill = SkillsManager.Skills.Beam;
        skill.health = 0;
        skill.armor = 0;
        skill.speed = 0;
        skill.damage = 0;
        skill.level = 1;
        skill.upgraded = false;

        playerMain.health += skill.health;
        playerMain.armor += skill.armor;
        playerMain.speed += skill.speed;
        playerMain.attackPower += skill.damage;
        if (!playerMain.skillsDatas.Contains(skill))
        {
            beamLevel = skill.level;
            playerMain.skillsDatas.Add(skill);
            playerMain.CheckHP();
            BeamStart();
        }
        else
        {
            beamLevel++;
            BeamUpgrade(beamLevel);
        }
    }
    public void BeamUpgrade(int level)
    {
        switch (level)
        {
            case 2:
                {

                    break;
                }
            case 3:
                {

                    break;
                }
            case 4:
                {

                    break;
                }
            case 5:
                {

                    break;
                }
        }

    }
    public void BeamStart()
    {
        StartCoroutine(playerMain.Beam());
    }


}
