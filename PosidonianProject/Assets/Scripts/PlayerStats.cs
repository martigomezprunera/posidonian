using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region VARIABLES
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;
    #endregion

    #region START
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
    #endregion
}
