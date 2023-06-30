public class BlackHoleRadiusIncreaseUpdate : Upgrade
{
    private BlackHole _blackHole;
    public BlackHoleRadiusIncreaseUpdate(BlackHole blackHole) : 
        base("블랙홀 중력 영향 범위 증가",
            GlobalSettings.InitialBlackHoleRadiusIncreaseCost,
            GlobalSettings.BlackHoleRadiusIncreaseCostMultiplier,
            GlobalSettings.BlackHoleRadiusIncreaseAmount)
    {
        _blackHole = blackHole;
    }

    protected override void ApplyUpgrade()
    {
        _blackHole.InfluenceRadiusValue += Amount;
    }
}
