using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UpgradeHammer : MonoBehaviour
{
    public int UpgradeCount = 1;
    public int UpgradeCost = 10;
    public TextMeshProUGUI _TMPro;
    public GameObject CheeseHammer;

    public CheeseMoon _cheeseMoon;

    private void Update()
    {
        _TMPro.text = UpgradeCost.ToString();
    }

    public void IncrementUpgrade()
    {
        if (_cheeseMoon != null && _cheeseMoon.CheeseAmount >= UpgradeCost)
        {
            UpgradeCount++;
            _cheeseMoon.CheeseAmount -= UpgradeCost;
            UpgradeCost *= UpgradeCount;

            if (!CheeseHammer.activeSelf)
            {
                CheeseHammer.SetActive(true);
            }
        }
    }
}
