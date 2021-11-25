using System;
using UnityEngine;
using UnityEngine.UI;

public class TurretsInfo : MonoBehaviour
{
    public TurretBlueprint missileLauncher;
    public TurretBlueprint standartTurret;

    public GameObject launcherInfoUI;
    public GameObject turretInfoUI;

    public void TurretBuyClick()
    {
        turretInfoUI.SetActive(true);
        launcherInfoUI.SetActive(false);
    }
    public void LauncherBuyClick()
    {
        turretInfoUI.SetActive(false);
        launcherInfoUI.SetActive(true);
    }
}
