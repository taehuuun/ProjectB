using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradeButton upgradeButtonPrefab;
    [SerializeField] private Transform blackHoleUpgradeButtonParent;
    [SerializeField] private BlackHole blackHole;

    private List<Upgrade> _blackHoleUpgradeList;

    private void Start()
    {
        _blackHoleUpgradeList = new List<Upgrade>()
        {
            new BlackHoleMassAbsorptionUpdate(blackHole),
            new BlackHoleMassReductionUpdate(blackHole),
            new BlackHoleRadiusIncreaseUpdate(blackHole)
        };
        
        UpgradeSetting();
    }

    private void UpgradeSetting()
    {
        foreach (var blackHoleUpgrade in _blackHoleUpgradeList)
        {
            UpgradeButton upgradeButton = Instantiate(upgradeButtonPrefab, blackHoleUpgradeButtonParent);
            upgradeButton.SetUpgrade(blackHoleUpgrade);
        }
    }
}