using System;
using System.Runtime.CompilerServices;
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

    public void SetPlanet(float mass, float speed)
    {
        Speed = speed;
        Mass = mass;
        
        float direction = Random.Range(0f, 360f);
        Vector2 randomDirection = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));

        Velocity = randomDirection.normalized * Speed;
    }
}
