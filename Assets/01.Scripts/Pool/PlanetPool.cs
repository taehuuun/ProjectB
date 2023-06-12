using System.Collections.Generic;
using UnityEngine;

public class PlanetPool : MonoBehaviour
{
    public Planet planetPrefab;
    public Transform parent;

    public float minMass;
    public float maxMass;
    public float minSpeed;
    public float maxSpeed;
    
    public List<Planet> PlanetPools { get; private set; }
    private const int PoolSize = 50;

    public void SetPool()
    {
        PlanetPools = new List<Planet>();
        for (int i = 0; i < PoolSize; i++)
        {
            Planet planet = Instantiate(planetPrefab, parent, true);
            PlanetPools.Add(planet);
        }
    }

    public void AdjustPlanetProperties(int wave)
    {
        minMass += wave * 1f;
        maxMass += wave * 1.5f;
        minSpeed += wave * 0.5f;
        maxSpeed += wave * 1f;
    }

    public void Spawn()
    {
        foreach (var planet in PlanetPools)
        {
            if (!planet.gameObject.activeSelf)
            {
                planet.SetPlanet(Random.Range(minMass,maxMass),Random.Range(minSpeed,maxSpeed));
                planet.gameObject.SetActive(true);
                break;
            }
        }
    }
}