using UnityEngine;
using TMPro;

public class UpgradeHammer : MonoBehaviour
{
    public int UpgradeCount = 1;
    public int UpgradeCost = 10;
    [HideInInspector] [SerializeField] private TextMeshProUGUI _TMPro;
    [HideInInspector] [SerializeField] private GameObject CheeseHammer;

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

            if (!CheeseHammer.activeSelf)
            {
                CheeseHammer.SetActive(true);
            }
        }
    }
}
