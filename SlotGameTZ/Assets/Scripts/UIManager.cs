using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI prizeText;

    private int prizeValue = 0;

    public int _prizeValue => this.prizeValue;
    public TextMeshProUGUI _prizeText => this.prizeText;

    public void UpdatePrizeValue(int newValue)
    {
        prizeValue = newValue;
        prizeText.text = "Prize: " + prizeValue.ToString();
    }
}
