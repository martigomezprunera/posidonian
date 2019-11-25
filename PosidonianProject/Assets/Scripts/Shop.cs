using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop : MonoBehaviour
{
    #region VARIABLES

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserTurret;

    BuildManager buildManager;
    #endregion

    #region START
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    #endregion

    #region PURCHASE STANDARD TURRET
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret selected!");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    #endregion

    #region PURCHASE MISILE INK TURRET
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher selected!");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    #endregion

    #region PURCHASE LASER TURRET
    public void SelectLaserTurret()
    {
        Debug.Log("Laser Turret selected!");
        buildManager.SelectTurretToBuild(laserTurret);
    }
    #endregion

}
