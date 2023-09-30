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
    [HideInInspector] public int _cursorMiningSpeed;    // The variable is left as public in order to be accessed in the CheeseMoon script

    [HideInInspector] [SerializeField] private TextMeshProUGUI hammerCPS;
    [HideInInspector] [SerializeField] private TextMeshProUGUI sateliteCPS; // -||- Second
    [HideInInspector] [SerializeField] private TextMeshProUGUI cursorCPC;   // Cheese Per Click
    [HideInInspector] [SerializeField] private TextMeshProUGUI totalCPS;

    [HideInInspector] public CheeseMoon _cheeseMoon;
    private float _timer = 0f;
    public bool cursorUpgraded = false;

    private void Start()
    {
        Cursor.SetCursor(_cursor, _cursorHotspot, CursorMode.Auto);     // Setting the default cursor
    }

    private void Update()
    {
        UpgradeHandler();
        CheeseMiningHandler();
        UpgradeTextHandler();

        if (cursorUpgraded)
        {
            Cursor.SetCursor(_upgradedCursor, _cursorHotspot, CursorMode.Auto);     // If upgraded, changing the cursor sprite to the upgraded one
        }
    }

    private void UpgradeHandler()
    {
        if (_upgradeHammer.UpgradeCount > 1)
        {
            _hammerMiningSpeed = Mathf.RoundToInt(Mathf.Pow(2, _upgradeHammer.UpgradeCount));
        }

        if (_upgradeSatelite.UpgradeCount > 1)
        {
            _sateliteMiningSpeed = Mathf.RoundToInt(Mathf.Pow(4, _upgradeSatelite.UpgradeCount));
        }

        if (_upgradeCursor.UpgradeCount > 1)
        {
            _cursorMiningSpeed = Mathf.RoundToInt(Mathf.Pow(3, _upgradeCursor.UpgradeCount) / 2);
        }
    }

    private void CheeseMiningHandler()
    {
        _timer += Time.deltaTime;

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
    }

    private void UpgradeTextHandler()
    {
        hammerCPS.text = $"CPS:\n{_hammerMiningSpeed.ToString()}\nCount: {_upgradeHammer.UpgradeCount - 1}";
        sateliteCPS.text = $"CPS:\n{_sateliteMiningSpeed.ToString()}\nCount: {_upgradeSatelite.UpgradeCount - 1}";
        cursorCPC.text = $"CPC:\n{_cursorMiningSpeed.ToString()}\nCount: {_upgradeCursor.UpgradeCount - 1}";

        totalCPS.text = $"Total CPS:\n{_hammerMiningSpeed + _sateliteMiningSpeed}";
    }
}
