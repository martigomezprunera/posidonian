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

    public Text sellAmount;

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

        sellAmount.text = target.turretBlueprint.GetSellAmount() + "O2";

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

    #region SELL
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
    #endregion
}
