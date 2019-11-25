using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] Transform target;
    [SerializeField] int waypointIndex = 0;

    private Enemy enemy;
    #endregion

    #region  START
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
        enemy = GetComponent<Enemy>();
    }
    #endregion

    #region UPDATE
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
    }
    #endregion

    #region GET NEXT WAY POINT
    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
    #endregion

    #region END PATH
    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
    #endregion
}
