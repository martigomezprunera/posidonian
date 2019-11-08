using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update
    #region VARIABLES
    public Color hoverColor;
    private Color startColor;

    private GameObject turret;

    private Renderer rend;

    public BuildManager buildManager;

    //INITIAL POSITION TURRET
    public Vector3 positionOffset;
    #endregion

    #region START
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    #endregion

    #region ONMOUSEENTER
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }
    #endregion

    #region ONMOUSEDOWN
    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build a turret there! - TODO: Display on screen");
            return;
        }

        //Build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    #endregion

    #region ONMOUSEEXIT
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    #endregion
}
