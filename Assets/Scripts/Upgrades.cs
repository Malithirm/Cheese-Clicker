using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public UpgradeTest _upgradeTest;
    public CheeseMoon _cheeseMoon;
    private float _timer = 0f;
    private int _cheesiumMiningSpeed = 1;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 1.0f)
        {
            if (_upgradeTest.UpgradeCount > 0)
            {
                _cheesiumMiningSpeed = Mathf.RoundToInt(Mathf.Pow(2, _upgradeTest.UpgradeCount));

                _cheeseMoon.CheeseAmount += _cheesiumMiningSpeed;

                _timer = 0f;
            }

        }
    }
}
