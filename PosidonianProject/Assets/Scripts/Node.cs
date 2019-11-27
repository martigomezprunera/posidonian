using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    // Start is called before the first frame update
    #region VARIABLES
    public Color hoverColor;
    private Color startColor;
    public Color notEnoughmMoneyColor;

    private Renderer rend;

    public BuildManager buildManager;

    //INITIAL POSITION TURRET
    public Vector3 positionOffset;


    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    #endregion

    #region START
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    #endregion

    #region GET BUILD POSITION
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    #endregion

    #region ON MOUSE DOWN
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

         if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughmMoneyColor;
        }
              

        if (!buildManager.CanBuild)
            return;

        //Build a turret
        BuildTurret(buildManager.GetTurretToBuild());
    }
    #endregion

    #region BUILD TURRET
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("NOT ENOUGHT MONEY TO BUILD THAT!!!!!!!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret Build!");
    }
    #endregion

    #region  UPGRADE TURRET
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("NOT ENOUGHT MONEY TO UPGRADE THAT!!!!!!!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Get rid of the old turret
        Destroy(turret);

        //Building new one

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
        Debug.Log("Turret Upgraded!");
    }
    #endregion


    #region ON MOUSE ENTER
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;

        rend.material.color = hoverColor;
    }
    #endregion

    #region ON MOUSE EXIT
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    #endregion
}
