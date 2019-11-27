using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    #region VARIABLES
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    private Node target;
    #endregion

    #region SET TARGET
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = target.turretBlueprint.upgradeCost + " O2";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        ui.SetActive(true);
    }
    #endregion

    #region HIDE
    public void Hide()
    {
        ui.SetActive(false);
    }
    #endregion

    #region UPGRADE
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    #endregion
}
