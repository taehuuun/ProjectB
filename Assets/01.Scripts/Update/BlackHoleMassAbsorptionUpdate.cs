public class BlackHoleMassAbsorptionUpdate : Upgrade
{
    private BlackHole _blackHole;
    public BlackHoleMassAbsorptionUpdate(BlackHole blackHole) : 
        base("블랙홀 질량 흡수량",
            GlobalSettings.InitialPlanetMassAbsorptionIncreaseCost,
            GlobalSettings.BlackHoleMassAbsorptionIncreaseCostMultiplier,
            GlobalSettings.BlackHoleMassAbsorptionIncreaseAmount)
    {
        _blackHole = blackHole;
    }

    protected override void ApplyUpgrade()
    {
        _blackHole.MassAbsorption += Amount;
    }
}
