using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheeseMoon : MonoBehaviour
{
    public int CheeseAmount;
    [SerializeField] private TextMeshProUGUI _cheeseText;

    void Update()
    {
        _cheeseText.text = $"Cheesium: \n{CheeseAmount.ToString()}";
    }

    public void IncrementCheesium()
    {
        CheeseAmount++;
    }
}
