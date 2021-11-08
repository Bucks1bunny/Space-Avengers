using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBlueprint turretToBuild;
    private Tile selectedTile;

    public TileUI tileUI;
    
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("There is already a buildmanager ");
            return;
        }
        instance = this;
    }
    public bool CanBuildTurret { get { return turretToBuild != null; } }

    public bool HasMoneyToBuild { get { return PlayerStats.Money >= turretToBuild.cost; } }
    public bool HasMoneyToUpgrade { get { return 
                   PlayerStats.Money >= turretToBuild.damageCost 
                || PlayerStats.Money >= turretToBuild.fireRateCost 
                || PlayerStats.Money >= turretToBuild.rangeCost; } }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void SelectedTile(Tile tile)
    {
        if (selectedTile == tile)
        {
            DeselectTile();
            return;
        }
        selectedTile = tile;
        turretToBuild = null;

        tileUI.SetTarget(tile);
    }
    public void DeselectTile()
    {
        selectedTile = null;
        tileUI.Hide(); 
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectTile();
    }
}
