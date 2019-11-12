using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region VARIABLES
    public static BuildManager instance;

    private TurretBlueprint turretToBuild;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    public GameObject buildEffect;
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
       
    public bool CanBuild { get { return turretToBuild != null;  } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    #region BUILD TURRET ON
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("NOT ENOUGHT MONEY TO BUILD THAT!!!!!!!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret Build! Money Left:     " + PlayerStats.Money);
    }
    #endregion

    #region SELECT TURRET TO BUILD
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
    #endregion
}
