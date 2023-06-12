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
            planet.SetBlackHole(blackHole);
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