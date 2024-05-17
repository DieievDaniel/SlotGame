using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryChecker : MonoBehaviour
{
    [SerializeField] private RowSlots[] rows;
    [SerializeField] private UIManager uIManager;

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
        if (rows[0]._stoppedSlot == "Diamond" && rows[1]._stoppedSlot == "Diamond" && rows[2]._stoppedSlot == "Diamond")
        {
            uIManager.UpdatePrizeValue(200);
        }
        else if (rows[0]._stoppedSlot == "Crown" && rows[1]._stoppedSlot == "Crown" && rows[2]._stoppedSlot == "Crown")
        {
            uIManager.UpdatePrizeValue(400);
        }
        else if (rows[0]._stoppedSlot == "Melon" && rows[1]._stoppedSlot == "Melon" && rows[2]._stoppedSlot == "Melon")
        {
            uIManager.UpdatePrizeValue(600);
        }
        else if (rows[0]._stoppedSlot == "Bar" && rows[1]._stoppedSlot == "Bar" && rows[2]._stoppedSlot == "Bar")
        {
            uIManager.UpdatePrizeValue(800);
        }
        else if (rows[0]._stoppedSlot == "Seven" && rows[1]._stoppedSlot == "Seven" && rows[2]._stoppedSlot == "Seven")
        {
            uIManager.UpdatePrizeValue(1500);
        }
        else if (rows[0]._stoppedSlot == "Cherry" && rows[1]._stoppedSlot == "Cherry" && rows[2]._stoppedSlot == "Cherry")
        {
            uIManager.UpdatePrizeValue(3000);
        }
        else if (rows[0]._stoppedSlot == "Lemon" && rows[1]._stoppedSlot == "Lemon" && rows[2]._stoppedSlot == "Lemon")
        {
            uIManager.UpdatePrizeValue(5000);
        }
        else if (((rows[0]._stoppedSlot == rows[1]._stoppedSlot) && (rows[0]._stoppedSlot == "Diamond")) || ((rows[0]._stoppedSlot == rows[2]._stoppedSlot) && (rows[0]._stoppedSlot == "Diamond")) || ((rows[1]._stoppedSlot == rows[2]._stoppedSlot) && (rows[1]._stoppedSlot == "Diamond")))
        {
            uIManager.UpdatePrizeValue(100);
        }
        else if (((rows[0]._stoppedSlot == rows[1]._stoppedSlot) && (rows[0]._stoppedSlot == "Crown")) || ((rows[0]._stoppedSlot == rows[2]._stoppedSlot) && (rows[0]._stoppedSlot == "Crown")) || ((rows[1]._stoppedSlot == rows[2]._stoppedSlot) && (rows[1]._stoppedSlot == "Crown")))
        {
            uIManager.UpdatePrizeValue(300);
        }
        else if (((rows[0]._stoppedSlot == rows[1]._stoppedSlot) && (rows[0]._stoppedSlot == "Melon")) || ((rows[0]._stoppedSlot == rows[2]._stoppedSlot) && (rows[0]._stoppedSlot == "Melon")) || ((rows[1]._stoppedSlot == rows[2]._stoppedSlot) && (rows[1]._stoppedSlot == "Melon")))
        {
            uIManager.UpdatePrizeValue(500);
        }
        else if (((rows[0]._stoppedSlot == rows[1]._stoppedSlot) && (rows[0]._stoppedSlot == "Bar")) || ((rows[0]._stoppedSlot == rows[2]._stoppedSlot) && (rows[0]._stoppedSlot == "Bar")) || ((rows[1]._stoppedSlot == rows[2]._stoppedSlot) && (rows[1]._stoppedSlot == "Bar")))
        {
            uIManager.UpdatePrizeValue(700);
        }
        else if (((rows[0]._stoppedSlot == rows[1]._stoppedSlot) && (rows[0]._stoppedSlot == "Seven")) || ((rows[0]._stoppedSlot == rows[2]._stoppedSlot) && (rows[0]._stoppedSlot == "Seven")) || ((rows[1]._stoppedSlot == rows[2]._stoppedSlot) && (rows[1]._stoppedSlot == "Seven")))
        {
            uIManager.UpdatePrizeValue(1000);
        }
        else if (((rows[0]._stoppedSlot == rows[1]._stoppedSlot) && (rows[0]._stoppedSlot == "Cherry")) || ((rows[0]._stoppedSlot == rows[2]._stoppedSlot) && (rows[0]._stoppedSlot == "Cherry")) || ((rows[1]._stoppedSlot == rows[2]._stoppedSlot) && (rows[1]._stoppedSlot == "Cherry")))
        {
            uIManager.UpdatePrizeValue(2000);
        }
        else if (((rows[0]._stoppedSlot == rows[1]._stoppedSlot) && (rows[0]._stoppedSlot == "Lemon")) || ((rows[0]._stoppedSlot == rows[2]._stoppedSlot) && (rows[0]._stoppedSlot == "Lemon")) || ((rows[1]._stoppedSlot == rows[2]._stoppedSlot) && (rows[1]._stoppedSlot == "Lemon")))
        {
            uIManager.UpdatePrizeValue(4000);
        }

        resultsChecked = true;
    }

}
