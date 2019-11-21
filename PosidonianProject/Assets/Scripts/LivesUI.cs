using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    #region VARIABLES
    public Text livesText;
    #endregion

    #region UPDATE
    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " LIVES";
    }
    #endregion
}
