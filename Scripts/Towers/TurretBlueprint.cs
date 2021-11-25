using System;
using UnityEngine;

[Serializable]
public class TurretBlueprint
{
    public GameObject turretPrefab;
    public int cost;
    public int damageCost, fireRateCost, rangeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
