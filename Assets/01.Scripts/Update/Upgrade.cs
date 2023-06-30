public abstract class Upgrade
{
    public string Name;
    public float Cost;
    public float CostMultiplier;
    public float Amount;
    public int Level;

    protected Upgrade(string name, float cost, float costMultiplier, float amount)
    {
        Name = name;
        Cost = cost;
        CostMultiplier = costMultiplier;
        Amount = amount;
    }

    protected abstract void ApplyUpgrade();
    public void PurchaseUpdate()
    {
        if (GameManager.TmpMoney >= Cost)
        {
            Level++;
            Cost *= CostMultiplier;
            ApplyUpgrade();
        }
    }
}
