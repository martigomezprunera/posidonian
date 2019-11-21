using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region VARIABLES
    private bool gameEnded = false;
    #endregion



    #region UPDATE
    void Update()
    {
        if (gameEnded)
        {
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    #endregion

    #region END GAME
    void EndGame()
    {
        gameEnded = true;
        Debug.Log("GAME OVER!!!!!");
    }
    #endregion

}
