public class BlackHoleMassReductionUpdate : Upgrade
{
    private BlackHole _blackHole;
    public BlackHoleMassReductionUpdate(BlackHole blackHole) 
        : base("블랙홀 질량 감소량 감소",
            GlobalSettings.InitialBlackHoleMassDecreaseCost,
            GlobalSettings.BlackHoleMassDecreaseCostMultiplier,
            GlobalSettings.BlackHoleMassDecreaseAmount)
    {
        _blackHole = blackHole;
    }

    public override void ApplyUpgrade()
    {
        _blackHole.MassDecreasePerSecond -= amount;
    }
}
