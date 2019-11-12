using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    // Start is called before the first frame update
    #region VARIABLES
    public Color hoverColor;
    private Color startColor;
    public Color notEnoughmMoneyColor;

    private Renderer rend;

    public BuildManager buildManager;

    //INITIAL POSITION TURRET
    public Vector3 positionOffset;


    [Header("Optional")]
    public GameObject turret;
    #endregion

    #region START
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    #endregion

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    #region ON MOUSE DOWN
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        
        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughmMoneyColor;
        }

        if(turret != null)
        {
            Debug.Log("Can't build a turret there! - TODO: Display on screen");
            return;
        }

        //Build a turret
        buildManager.BuildTurretOn(this);
    }
    #endregion

    #region ON MOUSE ENTER
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;

        rend.material.color = hoverColor;
    }
    #endregion


    #region ON MOUSE EXIT
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    #endregion
}
