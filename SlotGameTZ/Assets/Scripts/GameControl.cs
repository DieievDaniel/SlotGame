using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameControl : MonoBehaviour
{
    public static event Action ButtonClicked = delegate { };

    [SerializeField] private RowSlots[] rows;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private VictoryChecker victoryChecker;


    #region MONO

    private void Update()
    {
        if (!rows[0]._rowStopped || !rows[1]._rowStopped || !rows[2]._rowStopped)
        {
            uIManager._prizeText.enabled = false;
            uIManager.UpdatePrizeValue(uIManager._prizeValue);
            victoryChecker._resultsChecked = false;
        }

        if (rows[0]._rowStopped && rows[1]._rowStopped && rows[2]._rowStopped && !victoryChecker._resultsChecked)
        {
            victoryChecker.CheckResults();
            uIManager._prizeText.enabled = true;
            uIManager.UpdatePrizeValue(uIManager._prizeValue);
        }
    }

    #endregion

    public void StartSpin()
    {
        if (rows[0]._rowStopped && rows[1]._rowStopped && rows[2]._rowStopped)
        {
            ButtonClicked();
        }
    }

}
