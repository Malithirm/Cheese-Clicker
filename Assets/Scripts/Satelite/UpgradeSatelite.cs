using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UpgradeSatelite : MonoBehaviour
{
    [SerializeField] public int UpgradeCount = 1;
    [SerializeField] public int UpgradeCost = 100;
    public TextMeshProUGUI _TMPro;
    public GameObject Satelite;

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

            if (!Satelite.activeSelf)
            {
                Satelite.SetActive(true);
            }
        }
    }
}
