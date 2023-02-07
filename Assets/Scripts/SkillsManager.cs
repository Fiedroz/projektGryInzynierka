using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager: MonoBehaviour
{
    PlayerMain playerMain;

    public int garlicRadius = 10;
    public float garlicDamage = 10;

    public static float protectionDomeRadius = 3.8f;
    public static float protectionDomeDamage = 2f;//5
    public static float protectionDomeSlow = 3f;
    public static float protectionDomeRefresh = 0.5f;
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

        playerMain.passiveSkillsDatas.Add(skill.passiveSkill);
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

        playerMain.passiveSkillsDatas.Add(skill.passiveSkill);
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

        playerMain.passiveSkillsDatas.Add(skill.passiveSkill);
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

        playerMain.passiveSkillsDatas.Add(skill.passiveSkill);
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

        playerMain.passiveSkillsDatas.Add(skill.passiveSkill);
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

        playerMain.passiveSkillsDatas.Add(skill.passiveSkill);
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

        playerMain.passiveSkillsDatas.Add(skill.passiveSkill);
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
        if(!playerMain.skillsDatas.Contains(skill.skill)) {
            playerMain.skillsDatas.Add(skill.skill);
            playerMain.CheckHP();
            ProtectionDomeStart();
        }
        else
        {
            ProtectionDomeUpgrade();
        }
    }
    public void ProtectionDomeUpgrade() 
    {
        
    }
    public void ProtectionDomeStart()
    {
        StartCoroutine(playerMain.ProtectionDome());
    }
}
