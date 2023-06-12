using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Planet : MonoBehaviour
{
    public static event Action OnPlanetEnabled;
    public static event Action OnPlanetDisabled;
    
    public float Speed { get; private set; }
    public float Mass { get; private set; }
    public Vector2 Velocity { get;  set; }

    private BlackHole _blackHole;

    private void OnEnable()
    {
        OnPlanetEnabled?.Invoke();
    }
    private void OnDisable()
    {
        OnPlanetDisabled?.Invoke();
    }
    private void Update()
    {
        transform.position += (Vector3)Velocity * Time.deltaTime;
    }

    public void SetPlanet(float x, float y, float mass, float speed)
    {
        transform.position = new Vector2(x, y);
        Speed = speed;
        Mass = mass;
        
        Vector2 randomDirection = new Vector2(Random.Range(-1,1), Random.Range(-1,1));

        Velocity = randomDirection.normalized * Speed;
    }
}
