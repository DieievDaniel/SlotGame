using System.Collections.Generic;
using UnityEngine;

public class VictoryChecker : MonoBehaviour
{
    [SerializeField] private RowSlots[] rows;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private BetAndWinnings betAndWinnings;
    [SerializeField] private GameControl gameControl;

    private bool resultsChecked = false;

    public bool _resultsChecked
    {
        get => this.resultsChecked;
        set => this.resultsChecked = value;
    }

    private Dictionary<string, int> winValues = new Dictionary<string, int>
    {
        { "Diamond", 200 },
        { "Crown", 400 },
        { "Melon", 600 },
        { "Bar", 800 },
        { "Seven", 1500 },
        { "Cherry", 3000 },
        { "Lemon", 5000 }
    };

    private Dictionary<string, int> partialWinValues = new Dictionary<string, int>
    {
        { "Diamond", 100 },
        { "Crown", 300 },
        { "Melon", 500 },
        { "Bar", 700 },
        { "Seven", 1000 },
        { "Cherry", 2000 },
        { "Lemon", 4000 }
    };

    public void CheckResults()
    {
        Dictionary<string, int> slotCounts = new Dictionary<string, int>();

        // Count occurrences of each slot type in the rows
        foreach (var row in rows)
        {
            string slot = row._stoppedSlot;
            if (!string.IsNullOrEmpty(slot))
            {
                if (slotCounts.ContainsKey(slot))
                {
                    slotCounts[slot]++;
                }
                else
                {
                    slotCounts[slot] = 1;
                }
            }
        }

        foreach (var slotCount in slotCounts)
        {
            if (slotCount.Value == 3) // Three matching slots
            {
                uIManager.UpdatePrizeValue(winValues[slotCount.Key]);
                betAndWinnings.CalculateWinnings();
                resultsChecked = true;
                gameControl.BonusSpin();
                return;
            }
            else if (slotCount.Value == 2) // Two matching slots
            {
                uIManager.UpdatePrizeValue(partialWinValues[slotCount.Key]);
                betAndWinnings.CalculateWinnings();
                resultsChecked = true;
                return;
            }
        }

        resultsChecked = true;
    }
}
