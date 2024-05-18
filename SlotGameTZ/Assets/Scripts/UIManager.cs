using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BetAndWinnings betAndWinnings;

    [SerializeField] private TextMeshProUGUI prizeText;
    [SerializeField] private TextMeshProUGUI balanceText;
    [SerializeField] private TextMeshProUGUI betText; 
 
    public TextMeshProUGUI _prizeText => this.prizeText;
    public TextMeshProUGUI _balanceText => this.balanceText;
    public TextMeshProUGUI _betText => this.betText;

    #region MONO
    private void Start()
    {
        UpdateBalanceText();
        UpdateBetText();
    }
    #endregion

    public void UpdatePrizeValue(int newValue)
    {
        betAndWinnings._prizeValue = newValue;
        prizeText.text = "Prize: " + betAndWinnings._prizeValue.ToString();
    }

    public void UpdateBalanceText()
    {
        balanceText.text = "Balance: " + betAndWinnings._balance.ToString();
    }

    public void UpdateBetText()
    {
        betText.text = "Bet: " + betAndWinnings._bet.ToString();
    }
}
