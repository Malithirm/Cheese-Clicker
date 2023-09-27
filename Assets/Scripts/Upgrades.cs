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

    private int _hammerMiningSpeed;
    private int _sateliteMiningSpeed;

    public TextMeshProUGUI hammerCPS;
    public TextMeshProUGUI sateliteCPS;

    private void Update()
    {
        hammerCPS.text = $"CPS:\n{_hammerMiningSpeed.ToString()}\nCount: {_upgradeHammer.UpgradeCount - 1}";
        sateliteCPS.text = $"CPS:\n{_sateliteMiningSpeed.ToString()}\nCount: {_upgradeSatelite.UpgradeCount - 1}";

        _timer += Time.deltaTime;

        if (_timer >= 1.0f)
        {
            // ################################## Cheese Hammer
            if (_upgradeHammer.UpgradeCount > 1)
            {
                _hammerMiningSpeed = Mathf.RoundToInt(Mathf.Pow(2, _upgradeHammer.UpgradeCount));
                _cheeseMoon.CheeseAmount += _hammerMiningSpeed;

                _timer = 0f;
            }

            // ################################## Laser Satelite
            if (_upgradeSatelite.UpgradeCount > 1)
            {
                _sateliteMiningSpeed = Mathf.RoundToInt(Mathf.Pow(4, _upgradeSatelite.UpgradeCount));
                _cheeseMoon.CheeseAmount += _sateliteMiningSpeed;

                _timer = 0f;
            }

        }
    }
}
