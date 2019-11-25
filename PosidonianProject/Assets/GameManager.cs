using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region VARIABLES
    public static bool GameIsOver;

    public GameObject gameOverUI;
    #endregion

    #region START

    private void Start()
    {
        GameIsOver = false;
    }
    #endregion

    #region UPDATE
    void Update()
    {
        if (GameIsOver)
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
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }
    #endregion

}
