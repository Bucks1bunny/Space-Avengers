using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text moneyText;
    public Text livesText;
    public static int Money, Lives;
    public int startMoney = 300, startLives = 20;
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        livesText.text = $"Lives:{Lives}";
        moneyText.text = $"${Money}";
    }
    void Update()
    {
        if (Money != startMoney)
            OnMoneyChange();
        if (Lives != startLives)
            OnLivesChange();
    }
    private void OnLivesChange()
    {
        livesText.text = $"Lives:{Lives}";
    }
    private void OnMoneyChange()
    {
        moneyText.text = $"${Money}";
    }
}
