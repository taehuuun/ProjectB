using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    public string name;
    public float cost;
    public float costMultiplier;
    public float amount;
    public int level;

    protected Upgrade(string name, float cost, float costMultiplier, float amount)
    {
        this.name = name;
        this.cost = cost;
        this.costMultiplier = costMultiplier;
        this.amount = amount;
    }

    protected abstract void ApplyUpgrade();
    public void PurchaseUpdate()
    {
        if (GameManager.TmpMoney >= cost)
        {
            level++;
            cost *= costMultiplier;
            ApplyUpgrade();
        }
    }
}
