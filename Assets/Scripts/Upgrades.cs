using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public UpgradeHammer _upgradeHammer;
    public UpgradeSatelite _upgradeSatelite;

    public CheeseMoon _cheeseMoon;
    private float _timer = 0f;

    private int _cheesiumMiningSpeed;
    private int _hammerMiningSpeed;
    private int _sateliteMiningSpeed;

    public TextMeshProUGUI hammerCPS;
    public TextMeshProUGUI sateliteCPS;

    private void Update()
    {
        hammerCPS.text = _hammerMiningSpeed.ToString();
        sateliteCPS.text = _sateliteMiningSpeed.ToString();

        _timer += Time.deltaTime;

        if (_timer >= 1.0f)
        {
            // ################################## Cheese Hammer
            if (_upgradeHammer.UpgradeCount > 1)
            {
                _hammerMiningSpeed = Mathf.RoundToInt(Mathf.Pow(2, _upgradeHammer.UpgradeCount));
                AddCheesium();

                _timer = 0f;
            }

            // ################################## Laser Satelite
            if (_upgradeSatelite.UpgradeCount > 1)
            {
                _sateliteMiningSpeed = Mathf.RoundToInt(Mathf.Pow(4, _upgradeSatelite.UpgradeCount));
                AddCheesium();

                _timer = 0f;
            }

        }
    }

    private void AddCheesium()
    {
        _cheesiumMiningSpeed = _hammerMiningSpeed + _sateliteMiningSpeed;
        _cheeseMoon.CheeseAmount += _cheesiumMiningSpeed;
    }
}
