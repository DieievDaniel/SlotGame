using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetAndWinnings : MonoBehaviour
{
    [SerializeField] private UIManager manager;

    private int prizeValue = 0;
    private int balance = 1000;
    private int bet = 1;

    public int _prizeValue
    {
        get => this.prizeValue;
        set => this.prizeValue = value;
    }
    public int _balance => this.balance;
    public int _bet => this.bet;

    private const string BalanceKey = "Balance";

    #region MONO
    private void Start()
    {
        LoadBalance();
        manager.UpdateBalanceText();
        manager.UpdateBetText();
    }
    #endregion

    public void DeductBalanceOnSpin(int value)
    {
        balance -= value;
        SaveBalance();
        manager.UpdateBalanceText();
    }

    public void IncreaseBet()
    {
        if (bet < 5)
        {
            bet++;
            manager.UpdateBetText();
        }
    }

    public void DecreaseBet()
    {
        if (bet > 1)
        {
            bet--;
            manager.UpdateBetText();
        }
    }

    public void CalculateWinnings()
    {
        int winnings = bet * prizeValue;
        balance += winnings;
        SaveBalance();
        manager.UpdateBalanceText();
    }

    private void SaveBalance()
    {
        PlayerPrefs.SetInt(BalanceKey, balance);
        PlayerPrefs.Save();
    }

    private void LoadBalance()
    {
        if (PlayerPrefs.HasKey(BalanceKey))
        {
            balance = PlayerPrefs.GetInt(BalanceKey);
        }
    }
}
