using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private UpgradeButton upgradeButtonPrefab;
    [SerializeField] private Transform blackHoleUpdateButtonParent;
    [SerializeField] private BlackHole blackHole;

    [SerializeField] private List<Upgrade> blackHoleUpdateList = new List<Upgrade>();

    private void Start()
    {
        UpdateSetting();
    }

    private void UpdateSetting()
    {
        foreach (var blackUpdate in blackHoleUpdateList)
        {
        }
    }
}