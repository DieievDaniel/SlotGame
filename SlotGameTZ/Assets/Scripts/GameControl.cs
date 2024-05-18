using UnityEngine;
using System;


public class GameControl : MonoBehaviour
{
    public static event Action ButtonClicked = delegate { };

    [SerializeField] private RowSlots[] rows;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private VictoryChecker victoryChecker;
    [SerializeField] private BetAndWinnings betAndWinnings;
    [SerializeField] private MusicManager musicManager;


    #region MONO

    private void Update()
    {
        if (!rows[0]._rowStopped || !rows[1]._rowStopped || !rows[2]._rowStopped)
        {
            uIManager._prizeText.enabled = false;
            uIManager.UpdatePrizeValue(betAndWinnings._prizeValue);
            victoryChecker._resultsChecked = false;
        }

        if (rows[0]._rowStopped && rows[1]._rowStopped && rows[2]._rowStopped && !victoryChecker._resultsChecked)
        {
            victoryChecker.CheckResults();
            uIManager._prizeText.enabled = true;
            uIManager.UpdatePrizeValue(betAndWinnings._prizeValue);
        }
    }

    #endregion

    public void StartSpin()
    {
        if (rows[0]._rowStopped && rows[1]._rowStopped && rows[2]._rowStopped)
        {
            ButtonClicked();
            betAndWinnings.DeductBalanceOnSpin(100 * betAndWinnings._bet);
            musicManager.PlaySpinSound();
        }
    }
    public void BonusSpin()
    {
        if (rows[0]._rowStopped && rows[1]._rowStopped && rows[2]._rowStopped)
        {
            ButtonClicked();
            musicManager.PlaySpinSound();
        }
    }

}
