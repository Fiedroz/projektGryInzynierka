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
    public float expMax = 100;
    public float level = 1;
    public bool alive = true;

    public List<SkillsManager.SkillsData> skillsDatas = new List<SkillsManager.SkillsData>();
    public List<SkillsManager.PassiveSkillsData> passiveSkillsDatas= new List<SkillsManager.PassiveSkillsData>();

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
        if (other.tag=="Exp")
        {
            AddExp(other.GetComponent<ExpCrystal>().ExpAmount);
            other.GetComponent<ExpCrystal>().isGathered = true;
        }
    }
    void AddExp(float expRef)
    {
        exp += expRef;
        if (exp>=expMax)
        {
            exp -= expMax;
            level++;
            expMax += 50f;
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
    public IEnumerator ProtectionDome()
    {
        GameObject dome = GameManager.Instance.vFXManager.SpawnVFX(1, GameManager.Instance.playerMovement.PlayerTransform.position, GameManager.Instance.playerMovement.PlayerTransform);
        SkillsManager.protectionDomeObject = dome;
        for (; ; )
        {
            Collider[] hitColliders = Physics.OverlapSphere(GameManager.Instance.playerMovement.PlayerTransform.position, SkillsManager.protectionDomeRadius, LayerMask.GetMask("Enemy"));
            if (hitColliders.Length > 0)//hitColliders[i].gameObject.GetComponent<EnemyBehaviour>().ApplyDamage(garlicDamage);
            {
                foreach (Collider col in hitColliders)
                {
                    if (col != null)
                    {
                        col.GetComponent<EnemyBehaviour>().ApplyDamage(SkillsManager.protectionDomeDamage);
                        StartCoroutine(col.GetComponent<EnemyBehaviour>().ApplySlow(SkillsManager.protectionDomeRefresh, SkillsManager.protectionDomeSlow));
                    }
                }
            }
            yield return new WaitForSeconds(SkillsManager.protectionDomeRefresh);
        }
    }
    public IEnumerator Beam()
    {
        for (; ; )
        {
            float angle = Random.Range(0f, 2 * Mathf.PI); 
            Vector3 spawnPos = GameManager.Instance.playerMovement.spawnTransform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * (SkillsManager.beamRandomRadius); 

            //if (Physics.Raycast(spawnPos, Vector3.down, out hit, height, groundLayer))
            //{
                GameObject vfx = GameManager.Instance.vFXManager.SpawnVFX(2, spawnPos);

            //}
            
            Collider[] hitColliders = Physics.OverlapSphere(spawnPos, SkillsManager.beamRadius, LayerMask.GetMask("Enemy"));
            yield return new WaitForSeconds(0.4f);
            if (hitColliders.Length > 0)//hitColliders[i].gameObject.GetComponent<EnemyBehaviour>().ApplyDamage(garlicDamage);
            {
                foreach (Collider col in hitColliders)
                {
                    if (col != null) {
                        col.GetComponent<EnemyBehaviour>().ApplyDamage(SkillsManager.beamDamage);
                        StartCoroutine(col.GetComponent<EnemyBehaviour>().ApplySlow(SkillsManager.beamSlowDuration, SkillsManager.beamSlow));
                    }
                }
            }
            yield return new WaitForSeconds(SkillsManager.beamRefresh);
        }
    }
    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(GameManager.Instance.playerMovement.PlayerTransform.position, SkillsManager.protectionDomeRadius);
    }
}
