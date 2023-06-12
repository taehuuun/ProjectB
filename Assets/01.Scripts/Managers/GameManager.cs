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
            planet.SetPlanet(blackHole);
        }
    }
    
    private void Update()
    {
        foreach (var planet in planets)
        {
            if(planet.gameObject.activeSelf)
                blackHole.InteractPlanet(planet);
        }
    }
}