using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public Color hoverColor;
    public Color noMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    private Color startColor;
    private Renderer rend;
    BuildManager buildManager;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return; 

        if (turret != null)
        {
            buildManager.SelectedTile(this);
            return;
        }

        if (!buildManager.CanBuildTurret)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuildTurret)
            return;

        if(buildManager.HasMoneyToBuild)
            rend.material.color = hoverColor;

        if (!buildManager.HasMoneyToBuild)
            rend.material.color = noMoneyColor;

    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.turretPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

    }
    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        Destroy(turret);
        turretBlueprint = null;
    }
}
