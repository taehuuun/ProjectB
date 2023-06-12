using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BlackHole blackHole;

    public List<Planet> planets;

    private void Start()
    {
        foreach (var planet in planets)
        {
            planet.SetPlanet(blackHole, Random.Range(0,5),Random.Range(0,5));
        }
    }
    
    private void Update()
    {
        foreach (var planet in planets)
        {
            blackHole.InteractPlanet(planet);
        }
    }
}