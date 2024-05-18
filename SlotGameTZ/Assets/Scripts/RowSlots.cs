using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSlots : MonoBehaviour
{
    [SerializeField] private UIManager manager;

    private int randomValue;
    private float timeInterval;
    private bool rowStopped;
    private string stoppedSlot;

    public bool _rowStopped => this.rowStopped;
    public string _stoppedSlot => this.stoppedSlot;

    #region MONO

    private void Start()
    {
        rowStopped = true;
    }
    private void OnEnable()
    {
        GameControl.ButtonClicked += SpinClicked;
    }
    private void OnDisable()
    {
        GameControl.ButtonClicked -= SpinClicked;
    }

    #endregion

    private void SpinClicked()
    {
        stoppedSlot = "";
        StartCoroutine(RotateSlots());
    }

    private IEnumerator RotateSlots()
    {
        rowStopped = false;
        timeInterval = 0.025f; // time interval between changing every slot position in a row
        float endRowSlot = -1f; // end slot line position
        float startRowSlot = 1.2f; // start slot line position
        float stepRowSpin = 0.3f; // every small spin between two slots

        // Setting initial position
        float currentY = transform.position.y;

        // Initial fast spins
        for (int i = 0; i < 30; i++)
        {
            currentY -= stepRowSpin;
            if (currentY <= endRowSlot)
            {
                currentY = startRowSlot;
            }
            transform.position = new Vector2(transform.position.x, currentY);
            yield return new WaitForSeconds(timeInterval);
        }

        randomValue = Random.Range(60, 100);

        // Ensure randomValue is a multiple of 3
        randomValue += 3 - randomValue % 3;

        for (int i = 0; i < randomValue; i++)
        {
            currentY -= stepRowSpin;
            if (currentY <= endRowSlot)
            {
                currentY = startRowSlot;
            }
            transform.position = new Vector2(transform.position.x, currentY);

            // Adjust time interval based on progress
            if (i > Mathf.RoundToInt(randomValue * 0.8f))
            {
                timeInterval = 0.15f;
            }
            else if (i > Mathf.RoundToInt(randomValue * 0.6f))
            {
                timeInterval = 0.1f;
            }
            else if (i > Mathf.RoundToInt(randomValue * 0.4f))
            {
                timeInterval = 0.05f;
            }

            yield return new WaitForSeconds(timeInterval);
        }

        Dictionary<float, string> slotMappings = new Dictionary<float, string>
        {
            {-1.5f, "Diamond"},
            {-1.1f, "Crown"},
            {-0.5f, "Melon"},
            {0.15f, "Bar"},
            {0.8f, "Seven"}
        };

        float closestY = float.MaxValue;
        float minDistance = float.MaxValue;

        foreach (float key in slotMappings.Keys)
        {
            float distance = Mathf.Abs(currentY - key);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestY = key;
            }
        }

        stoppedSlot = slotMappings[closestY];
        transform.position = new Vector2(transform.position.x, closestY);

        rowStopped = true;
    }
}
