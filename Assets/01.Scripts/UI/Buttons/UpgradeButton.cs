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
      upgradeNameText.text = _linkedUpgrade.Name;
      UpdateUI();
   }

   public void OnButtonClick()
   {
      _linkedUpgrade.PurchaseUpdate();
      UpdateUI();
   }

   private void UpdateUI()
   {
      levelText.text = $"Lv.{_linkedUpgrade.Level.ToString()}";
      costText.text = $"$ {_linkedUpgrade.Cost.ToString()}";
   }
}