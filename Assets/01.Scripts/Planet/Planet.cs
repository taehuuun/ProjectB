using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Planet : MonoBehaviour
{
    public static event Action OnPlanetEnabled;
    public static event Action OnPlanetDisabled;
    public static event Action<Planet> OnPlanetRespawn;
    
    public Vector2 Velocity { get;  set; }
    
    public float Speed { get; private set; }
    public float Mass { get; private set; }
    
    public bool isOnScreen = false;
    
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
        transform.position += (Vector3)Velocity * (Time.deltaTime * 0.01f);

        if (IsOffScreen())
        {
            if (isOnScreen)
            {
                OnPlanetRespawn?.Invoke(this);
            }
        }
        else
        {
            isOnScreen = true;
        }
    }

    public void SetPlanet(Vector2 spawnPosition, float mass, float speed)
    {
        transform.position = spawnPosition;
        Speed = speed;
        Mass = mass;
        isOnScreen = false;

        Vector2 rotatedDirection = CalculateRandomDirection();

        Velocity = rotatedDirection * Speed * 10;
    }

    private Vector2 CalculateRandomDirection()
    {
        Vector2 centerVec = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f));
        
        Vector2 direction = centerVec - (Vector2)transform.position.normalized;
        float randomAngle = Random.Range(-30f, 30f) * Mathf.Deg2Rad;

        Vector2 rotatedDirection = new Vector2
        (
            direction.x * Mathf.Cos(randomAngle) - direction.y * Mathf.Sin(randomAngle),
            direction.x * Mathf.Sin(randomAngle) + direction.y * Mathf.Cos(randomAngle)
        );

        return rotatedDirection;
    }
    private bool IsOffScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1;
    }
}
