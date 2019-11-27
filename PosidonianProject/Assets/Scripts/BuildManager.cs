using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region VARIABLES
    public static BuildManager instance;

    private TurretBlueprint turretToBuild;

    private Node selectedNode;

    public GameObject buildEffect;

    public NodeUI nodeUI;
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

    #region SELECT TURRET TO BUILD
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        nodeUI.Hide();
    }

    #endregion

    #region GET TURRET TO BUILD
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
    #endregion
}
