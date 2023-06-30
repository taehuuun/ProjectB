using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
   [SerializeField] private TMP_Text upgradeNameText;
   [SerializeField] private TMP_Text levelText;
   [SerializeField] private TMP_Text costText;

   private Upgrade _linkedUpgrade;

   public void SetUpgrade(Upgrade upgrade)
   {
      _linkedUpgrade = upgrade;
      UpdateUI();
   }

   public void OnButtonClick()
   {
      _linkedUpgrade.PurchaseUpdate();
      UpdateUI();
   }

   private void UpdateUI()
   {
      upgradeNameText.text = levelText.name;
      levelText.text = $"Lv.{_linkedUpgrade.level.ToString()}";
      costText.text = $"$ {_linkedUpgrade.cost.ToString()}";
   }
}