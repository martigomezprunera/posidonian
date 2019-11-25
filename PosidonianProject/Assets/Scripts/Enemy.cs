using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region VARIABLES
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float slowDownFactor = 0.7f;
     
    private bool isSlowed = false;

    public float health = 100;

    public int worth = 50;


    public GameObject deathEffect;

    #endregion

    #region START
    private void Start()
    {
        speed = startSpeed;
    }
    #endregion
    //lo usa el pulpo de tinta
    #region SLOWDOWN
    public void SlowDown()
    {
        if (!isSlowed)
        {
            speed *= slowDownFactor;
        }

        isSlowed = true;
        
    }
    #endregion

    #region TAKE DAMAGE
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    #endregion

    //lo usa el pulpo con laser 
    #region SLOW
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
    #endregion

    #region DIE
    void Die()
    {
        PlayerStats.Money += worth;
        
        GameObject effect = (GameObject)Instantiate(deathEffect,  transform.position, Quaternion.identity );
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
    #endregion

}
