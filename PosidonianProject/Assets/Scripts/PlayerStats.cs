using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region VARIABLES
    public static int Money;
    public int startMoney = 400;
    #endregion

    #region START
    void Start()
    {
        Money = startMoney;
    }
    #endregion
}
