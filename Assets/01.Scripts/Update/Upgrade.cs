using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string name;
    public float cost;
    public float costMultiplier;
    public float amount;
    public int level;

    public Upgrade(string name, float cost, float costMultiplier, float amount, int level)
    {
        this.name = name;
        this.cost = cost;
        this.costMultiplier = costMultiplier;
        this.amount = amount;
        this.level = level;
    }

    public void Apply()
    {
        cost *= costMultiplier;
        level++;
    }
}
