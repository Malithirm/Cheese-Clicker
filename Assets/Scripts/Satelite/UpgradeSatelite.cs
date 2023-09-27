using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UpgradeSatelite : MonoBehaviour
{
    public int UpgradeCount = 1;
    public int UpgradeCost = 100;
    public TextMeshProUGUI _TMPro;
    public GameObject Satelite;

    public CheeseMoon _cheeseMoon;

    private void Update()
    {
        _TMPro.text = UpgradeCost.ToString(); // the problem
    }

    public void IncrementUpgrade()
    {
        if (_cheeseMoon != null && _cheeseMoon.CheeseAmount >= UpgradeCost)
        {
            UpgradeCount++;
            _cheeseMoon.CheeseAmount -= UpgradeCost;
            UpgradeCost *= UpgradeCount;
            Satelite.SetActive(true);

            Debug.Log(UpgradeCount);
        }
    }
}
