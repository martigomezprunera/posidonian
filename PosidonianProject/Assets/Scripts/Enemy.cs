using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] float speed;
    [SerializeField] Transform target;
    [SerializeField] int waypointIndex = 0;

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
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
    #endregion

}
