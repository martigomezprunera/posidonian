using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region VARIABLES
    private Transform target;

    public int damage = 50;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;
    #endregion

    #region Seek
    public void Seek (Transform _target)
    {
        target = _target;
    }
    #endregion

    // Update is called once per frame
    #region Update
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        transform.LookAt(target);
    }
    #endregion

    #region HitTarget
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }        
        Destroy(gameObject);

    }
    #endregion

    #region EXPLODE
    void Explode()
    {
        Collider[] colliders=  Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                //Damage(collider.transform);
                Enemy aux = collider.gameObject.GetComponent<Enemy>();
                aux.SlowDown();
            }
        }
    }
    #endregion

    #region DAMAGE
    void Damage(Transform enemyGO)
    {
        Enemy e = enemyGO.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
    #endregion
   
    #region GIZMOS SELECTEDS
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    #endregion
}
