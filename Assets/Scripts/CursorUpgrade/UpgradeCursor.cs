using TMPro;
using UnityEngine;

public class UpgradeCursor : MonoBehaviour
{
    public int UpgradeCount = 1;
    public int UpgradeCost = 50;
    [HideInInspector] [SerializeField] private TextMeshProUGUI _TMPro;

    [HideInInspector] [SerializeField] private CheeseMoon _cheeseMoon;

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
        }
    }
}
