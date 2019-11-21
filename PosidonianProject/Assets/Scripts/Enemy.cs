using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] float speed;
    [SerializeField] Transform target;
    [SerializeField] int waypointIndex = 0;
    [SerializeField] float slowDownFactor = 0.7f;
    public GameObject deathEffect;
    private bool isSlowed = false;
    public int health = 100;

    public int value = 50;

    #endregion

    #region  START
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
    }
    #endregion

    #region UPDATE
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }
    #endregion

    #region GET NEXT WAY POINT
    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
    #endregion

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

    #region END PATH
    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
    #endregion

    #region TAKE DAMAGE
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    #endregion

    #region DIE
    void Die()
    {
        PlayerStats.Money += value;
        
        GameObject effect = (GameObject)Instantiate(deathEffect,  transform.position, Quaternion.identity );
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
    #endregion

}
