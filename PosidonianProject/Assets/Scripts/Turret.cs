using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    #region VARIABLES
    private Transform target;
    private Enemy targetEnemy;

    [Header("GENERAL")]
    public float range = 15f;

    [Header("Use Bullets(default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1.0f;
    public float fireCountDown = 0.0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public float slowAmount = 0.5f;

    public int damageOverTime = 30;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10;

    
    public Transform FirePoint;
    #endregion

    #region START
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    #endregion

    #region UPDATE TARGET
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
    #endregion

    #region UPDATE
    void Update()
    {
        if ( target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled )
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }

        LookOnTarget();


        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1.0f / fireRate;
            }

            fireCountDown -= Time.deltaTime;
        }
        
    }
    #endregion

    #region LASER
    void Laser()
    {

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled)
        {        
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        //pintar laser
        lineRenderer.SetPosition(0, FirePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = FirePoint.position - target.position;

        //efectos y luces
        impactEffect.transform.position = target.position + dir.normalized ;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    #endregion

    #region LOOK ON TARGET
    void LookOnTarget()
    {
        //TARGET LOOK ON
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    #endregion

    #region SHOOT
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }
    #endregion

    #region DRAW GIZMOS SELECTED
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);   
    }
#endregion
}
