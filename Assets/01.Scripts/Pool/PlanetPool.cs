using System.Collections.Generic;
using UnityEngine;

public class PlanetPool : MonoBehaviour
{
    public Planet planetPrefab;
    public Transform parent;

    public Vector2[,] spawnAbleAreas = new Vector2[4,2];
    public float minMass;
    public float maxMass;
    public float minSpeed;
    public float maxSpeed;
    
    public List<Planet> PlanetPools { get; private set; }
    private const int PoolSize = 10;

    private void SetSpawnAbleAreas()
    {
        Vector2 screenLeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        
        // 왼쪽 영역 왼쪽 아래, 오른쪽 위
        spawnAbleAreas[0, 0] = new Vector2(screenLeftBottom.x - 1, screenLeftBottom.y - 1);
        spawnAbleAreas[0, 1] = new Vector2(screenLeftBottom.x, (screenLeftBottom.y * -1) + 1);
        
        // 위쪽 영역 왼쪽 아래, 오른쪽 위
        spawnAbleAreas[1, 0] = new Vector2(screenLeftBottom.x - 1, (screenLeftBottom.y * -1));
        spawnAbleAreas[1, 1] = new Vector2((screenLeftBottom.x * -1) + 1, (screenLeftBottom.y * -1) + 1);
        
        // 오른쪽 영역 왼쪽 아래, 오른쪽 위
        spawnAbleAreas[2, 0] = new Vector2((screenLeftBottom.x*-1), screenLeftBottom.y  - 1);
        spawnAbleAreas[2, 1] = new Vector2((screenLeftBottom.x*-1)+1, (screenLeftBottom.y*-1) +1);
        
        // 아래 영역 왼쪽 아래, 오른쪽 위
        spawnAbleAreas[3, 0] = new Vector2(screenLeftBottom.x - 1, screenLeftBottom.y - 1);
        spawnAbleAreas[3, 1] = new Vector2((screenLeftBottom.x * -1) + 1, screenLeftBottom.y);
    }

    public Vector2 GetRandomSpawnPosition()
    {
        int randIdx = Random.Range(0, spawnAbleAreas.GetLength(0));
        float minX = spawnAbleAreas[randIdx, 0].x;
        float maxX = spawnAbleAreas[randIdx, 1].x;
        float minY = spawnAbleAreas[randIdx, 0].y;
        float maxY = spawnAbleAreas[randIdx, 1].y;

        float randX = Random.Range(minX, maxX);
        float randY = Random.Range(minY, maxY);

        return new Vector2(randX, randY);
    }
    public void SetPool()
    {
        SetSpawnAbleAreas();
        
        PlanetPools = new List<Planet>();
        for (int i = 0; i < PoolSize; i++)
        {
            Planet planet = Instantiate(planetPrefab, parent, true);
            planet.gameObject.SetActive(false);
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
                Vector2 spawnPosition = GetRandomSpawnPosition();
                
                float mass = Random.Range(minMass, maxMass);
                float speed = Random.Range(minSpeed, maxSpeed);

                planet.SetPlanet(spawnPosition, mass, speed);
                planet.gameObject.SetActive(true);
                break;
            }
        }
    }
}