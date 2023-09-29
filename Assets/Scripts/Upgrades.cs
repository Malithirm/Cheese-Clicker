using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    [Header("Upgrades")]
    public UpgradeHammer _upgradeHammer;
    public UpgradeSatelite _upgradeSatelite;
    public UpgradeCursor _upgradeCursor;

    [Header("Cursor related")]
    [SerializeField] private Texture2D _cursor;
    [SerializeField] private Texture2D _upgradedCursor;

    [HideInInspector] private Vector2 _cursorHotspot = Vector2.zero;

    [HideInInspector] private int _hammerMiningSpeed;
    [HideInInspector] private int _sateliteMiningSpeed;
    [HideInInspector] public int _cursorMiningSpeed;

    [HideInInspector] public TextMeshProUGUI hammerCPS;
    [HideInInspector] public TextMeshProUGUI sateliteCPS; // -||- Second
    [HideInInspector] public TextMeshProUGUI cursorCPC;   // Cheese Per Click

    public CheeseMoon _cheeseMoon;
    private float _timer = 0f;
    public bool cursorUpgraded = false;

    private void Start()
    {
        Cursor.SetCursor(_cursor, _cursorHotspot, CursorMode.Auto);
    }

    private void Update()
    {
        hammerCPS.text = $"CPS:\n{_hammerMiningSpeed.ToString()}\nCount: {_upgradeHammer.UpgradeCount - 1}";
        sateliteCPS.text = $"CPS:\n{_sateliteMiningSpeed.ToString()}\nCount: {_upgradeSatelite.UpgradeCount - 1}";
        cursorCPC.text = $"CPC:\n{_cursorMiningSpeed.ToString()}\nCount: {_upgradeCursor.UpgradeCount - 1}";

        _timer += Time.deltaTime;

        _hammerMiningSpeed = Mathf.RoundToInt(Mathf.Pow(2, _upgradeHammer.UpgradeCount));
        _sateliteMiningSpeed = Mathf.RoundToInt(Mathf.Pow(4, _upgradeSatelite.UpgradeCount));
        _cursorMiningSpeed = Mathf.RoundToInt(Mathf.Pow(2, _upgradeCursor.UpgradeCount) / 2);

        if (_timer >= 1.0f)
        {
            // ################################## Cheese Hammer
            if (_upgradeHammer.UpgradeCount > 1)
            {
                _cheeseMoon.CheeseAmount += _hammerMiningSpeed;

                _timer = 0f;
            }

            // ################################## Laser Satelite
            if (_upgradeSatelite.UpgradeCount > 1)
            {
                _cheeseMoon.CheeseAmount += _sateliteMiningSpeed;

                _timer = 0f;
            }

            // ################################## Cursor Upgrade
            if (_upgradeCursor.UpgradeCount > 1)
            {
                cursorUpgraded = true;
            }
            else cursorUpgraded = false;
        }


        if (cursorUpgraded)
        {
            Cursor.SetCursor(_upgradedCursor, _cursorHotspot, CursorMode.Auto);
        }
    }
}
