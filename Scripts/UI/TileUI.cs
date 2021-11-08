using UnityEngine;

public class TileUI : MonoBehaviour
{
    private Tile target;
    public GameObject ui;
    public void SetTarget(Tile _target)
    {
        target = _target;
        
        transform.position = target.GetBuildPosition();

        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectTile();
    }
}
