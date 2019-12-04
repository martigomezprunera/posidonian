using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region VARIABLES
    public static bool GameIsOver;

    public GameObject gameOverUI;

    public GameObject[] posidonianMaster;

    //BOOLS POSIDIONIAN GAMEOBJECTS
    bool done0 = false;
    bool done5 = false;
    bool done10 = false;
    bool done15 = false;

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

        //DestroyPosidonians
        ChangeGreyPosidonian(PlayerStats.Lives);

    }
    #endregion

    #region END GAME
    void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }
    #endregion

    #region ChangeGreyPosidonian
    public void ChangeGreyPosidonian(int lifes)
    {
        switch (lifes)
        {
            case 0:

                if (done0 == false)
                {
                    //DESTROY GAMEOBJECTS
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();

                    done0 = true;
                }

                break;
            case 5:

                if (done5== false)
                {
                    //DESTROY GAMEOBJECTS
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();

                    done5 = true;
                }

                break;
            case 10:

                if (done10 == false)
                {
                    //DESTROY GAMEOBJECTS
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();

                    done10 = true;
                }

                break;
            case 15:

                if (done15 == false)
                {
                    //DESTROY GAMEOBJECTS
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();
                    DestroyPosidonians();

                    done15 = true;
                }

                break;
        }


    }
    #endregion


    #region DestroyPosidonians
    public void DestroyPosidonians()
    {
        int[] rand = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

        //GENERAR RANDOMS
        for (int i = 0; i < rand.Length; i++)
        {
            do
            {
                rand[i] = Random.Range(0, posidonianMaster.Length);
            }
            while (posidonianMaster[rand[i]] == null);
        }

        //DESTROY POSIDONIANS
        for(int i = 0; i < rand.Length; i++)
        {
            Destroy(posidonianMaster[rand[i]]);
        }
    }
    #endregion
}
