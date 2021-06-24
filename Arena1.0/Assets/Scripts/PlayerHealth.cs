using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    public float HealthPercentage;
    public bool dead = false;

    //ScreenShake Camera;
    GameObject Camera;
    public float Duration, Strength;

    //public event System.Action OnDeath;

    void Start()
    {
        currentHealth = health;
        HealthPercentage = currentHealth / health;
        
        Camera = GameObject.FindGameObjectWithTag("MainCamera");//.GetComponent<ScreenShake>();
        //health = StartHealth;
        
        //Debug.Log(health + "start with this");
    }
    private void Update()
    {
        Damage(0);
       
    }
    private void Damage(float amount)
    {
        currentHealth -= amount;
        HealthPercentage = currentHealth / health;
        //Debug.Log(health);
        if (currentHealth <= 0 && !dead)
        {
            //StartCoroutine(Camera.ShakeScreen(Duration, Strength));
            //ShakeScreen(Duration, Strength);
            Debug.Log("dead");
            Die();
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            //ShootProjectile bullet = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootProjectile>();
            EnemyAttack bullet = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAttack>();
            Damage(bullet.EnemyDMG);
        }
        if(other.tag== "BossBullet")
        {
            BossAttack bullet = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossAttack>();
            Damage(bullet.EnemyDMG);
        }
    }
    void Die()
    {
        dead = true;
        SceneManager.LoadScene("MainMenu");
        // Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        //Destroy(gameObject);

        //set endgame
    }
}
