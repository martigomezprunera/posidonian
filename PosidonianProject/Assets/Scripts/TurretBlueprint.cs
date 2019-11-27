using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    #region VARIBLES
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    #endregion

    #region GET SELL AMOUNT
    public int GetSellAmount()
    {
        return cost / 2;
    }
    #endregion

}
