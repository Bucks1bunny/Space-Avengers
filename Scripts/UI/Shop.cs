using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public GameObject launcherInfoUI;
    public GameObject turretInfoUI;


    public Text tDamageCost, tFireRateCost, tRangeCost, lDamageCost, lFireRateCost, lRangeCost;
    public Text tDamage, tFireRate, tRange, lDamage, lFireRate, lRange;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        launcherInfoUI.SetActive(false);
        turretInfoUI.SetActive(false);
    }
    private void Update()
    {
        //-----------STANDART TURRET UPGRADES-----------
        tDamage.text = $"Damage: {Turret.StandartTurretDamage}";
        tDamageCost.text = "Upgrade:\n$" + Convert.ToString(standartTurret.damageCost);
        tFireRateCost.text = "Upgrade:\n$" + Convert.ToString(standartTurret.fireRateCost);
        tFireRate.text = $"Fire Rate: {Turret.StandartTurretFireRate}";
        tRangeCost.text = "Upgrade:\n$" + Convert.ToString(standartTurret.rangeCost);
        tRange.text = $"Range: {Turret.StandartTurretRange}";
        //-----------MISSILE LAUNCHER UPGRADES-----------
        lDamageCost.text = "Upgrade:\n$" + Convert.ToString(missileLauncher.damageCost);
        lDamage.text = $"Damage: {Launcher.MissileLauncherDamage}";
        lFireRateCost.text = "Upgrade:\n$" + Convert.ToString(missileLauncher.fireRateCost);
        lFireRate.text = $"FIre Rate: {Launcher.MissileLauncherFireRate}";
        lRangeCost.text = "Upgrade:\n$" + Convert.ToString(missileLauncher.rangeCost);
        lRange.text = $"Range: {Launcher.MissileLauncherRange}";
    }
    #region Purchases Methods
    #region Standart Turret
    public void PurchaseStandartTurret()
    {
        turretInfoUI.SetActive(true);
        launcherInfoUI.SetActive(false);
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void PurchaseTurretDamage()
    {
        if (buildManager.HasMoneyToUpgrade)
        {
            PlayerStats.Money -= standartTurret.damageCost;
            Turret.StandartTurretDamage += 10f;
            standartTurret.damageCost *= 2;
        }
    }
    public void PurchaseTurretFirerate()
    {
        if (buildManager.HasMoneyToUpgrade)
        {
            PlayerStats.Money -= standartTurret.fireRateCost;
            Turret.StandartTurretFireRate += 0.4f;
            standartTurret.fireRateCost *= 2;
        }
    }
    public void PurchaseTurretRange()
    {
        if (buildManager.HasMoneyToUpgrade)
        {
            PlayerStats.Money -= standartTurret.rangeCost;
            Turret.StandartTurretRange += 5f;
            standartTurret.rangeCost *= 2;
        }
    }
    #endregion
    #region Missile Launcher
    public void PurchaseMissileLauncher()
    {
        turretInfoUI.SetActive(false);
        launcherInfoUI.SetActive(true);
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void PurchaseMissileDamage()
    {
        if (buildManager.HasMoneyToUpgrade)
        { 
            PlayerStats.Money -= missileLauncher.damageCost;
            Launcher.MissileLauncherDamage += 30;
            missileLauncher.damageCost *= 2;
        }
    }
    public void PurchaseMissileFireRate()
    {
        if (buildManager.HasMoneyToUpgrade)
        {
            PlayerStats.Money -= missileLauncher.fireRateCost;
            Launcher.MissileLauncherFireRate += .25f;
            missileLauncher.fireRateCost *= 2;
        }
    }
    public void PurchaseMissileRange()
    {
        if (buildManager.HasMoneyToUpgrade)
        {
            PlayerStats.Money -= missileLauncher.rangeCost;
            Launcher.MissileLauncherRange +=5;
            missileLauncher.rangeCost *= 2;
        }
    }
    #endregion
    #endregion

}
