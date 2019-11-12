using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    #region VARIABLES
    public Text moneyText;

    #endregion

    #region UPDATE
    void Update()
    {
        moneyText.text = "O₂ " + PlayerStats.Money.ToString();
    }
    #endregion
}