using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public float armor = 5;
    public float speed = 1;
    public float attackPower = 10;
    public float exp = 0;
    public float level = 1;
    public bool alive = true;
    public List<SkillsManager.Skills> skillsDatas = new List<SkillsManager.Skills>();
    public List<SkillsManager.PassiveSkills> passiveSkillsDatas= new List<SkillsManager.PassiveSkills>();
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Enemy")
        {
            Debug.Log("Ouch "+other.GetComponent<EnemyBehaviour>().attackPower);
            if (health>0) {
                health -= other.GetComponent<EnemyBehaviour>().attackPower;
            }
            else
            {
                Death();
            }
        }
    }
    public void Death()
    {
        Debug.Log("YOU DIED");
        health = 0;
        alive = false;
    }
    public void CheckHP()
    {
        if (health>maxHealth)
        {
            health = maxHealth;
        }
    }
    public IEnumerator GarlicAttack(float garlicRadius,float garlicDamage)
    {
        
        for (int i=0;i<5;i++)
        {
            GameManager.Instance.vFXManager.SpawnVFX(0, GameManager.Instance.playerMovement.PlayerTransform.position, GameManager.Instance.playerMovement.PlayerTransform);
            Collider[] hitColliders = Physics.OverlapSphere(GameManager.Instance.playerMovement.PlayerTransform.position, garlicRadius, LayerMask.GetMask("Enemy"));
            if (hitColliders.Length>0)//hitColliders[i].gameObject.GetComponent<EnemyBehaviour>().ApplyDamage(garlicDamage);
            {
                foreach(Collider col in hitColliders)
                {
                    col.GetComponent<EnemyBehaviour>().ApplyDamage(garlicDamage);
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GameManager.Instance.playerMovement.PlayerTransform.position, 15);
    }
}
