using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    #region VARIABLES
    public Text roundsText;
    #endregion

    #region OnEnable
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }
    #endregion

    #region Retry
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion

    #region Menu
    public void Menu()
    {
        Debug.Log("Go to menu");
    }
    #endregion

    // Start is called before the first frame update
    #region START
    void Start()
    {
        
    }
    #endregion

    // Update is called once per frame
    #region UPDATE
    void Update()
    {
        
    }
    #endregion

    #region QUIT
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT APP");
    }
    #endregion
}
