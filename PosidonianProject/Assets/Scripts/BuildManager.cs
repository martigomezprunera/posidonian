using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region VARIABLES
    public static BuildManager instance;

    private GameObject turretToBuild;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    #endregion

    #region AWAKE
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one build manager in scene");
        }
        instance = this;
    }
    #endregion
       
    #region GETTURRETTOBUILD
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    #endregion


    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
