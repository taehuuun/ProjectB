using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BlackHole blackHole;
    public PlanetPool planetPool;
    
    private int _activeCount;
    private int _currentWave;
    
    private const int BasePlanetCountPerWave = 5;
    private const float WaveMultiplier  = 1.2f;
    
    private void OnEnable()
    {
        Planet.OnPlanetEnabled += HandlePlanetEnabled;
        Planet.OnPlanetDisabled += HandlePlanetDisabled;
        Planet.OnPlanetRespawn += HandlePlanetRespawn;
    }
    private void OnDisable()
    {
        Planet.OnPlanetEnabled -= HandlePlanetEnabled;
        Planet.OnPlanetDisabled -= HandlePlanetDisabled;
        Planet.OnPlanetRespawn -= HandlePlanetRespawn;
    }
    private void Start()
    {
        planetPool.SetPool();
        StartNextWave();
    }
    private void Update()
    {
        foreach (var planet in planetPool.PlanetPools)
        {
            if(planet.gameObject.activeSelf)
                blackHole.InteractPlanet(planet);
        }
    }

    private void StartNextWave()
    {
        _currentWave++;
        planetPool.AdjustPlanetProperties(_currentWave);
        
        int planetCountForThisWave = Mathf.FloorToInt(BasePlanetCountPerWave * Mathf.Pow(WaveMultiplier, _currentWave));
        
        Debug.Log($"Current Wave : {_currentWave}");
        Debug.Log($"Current Wave Plant : {planetCountForThisWave}");

        for (int i = 0; i < planetCountForThisWave; i++)
        {
            planetPool.Spawn();
        }
    }
    private void HandlePlanetEnabled()
    {
        _activeCount++;
    }
    private void HandlePlanetDisabled()
    {
        _activeCount--;
    }
    private void HandlePlanetRespawn(Planet planet)
    {
        planet.SetPlanet(planetPool.GetRandomSpawnPosition(), planet.Mass,planet.Speed);
    }
}