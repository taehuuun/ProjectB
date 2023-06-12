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
        transform.position += (Vector3)Velocity * (Time.deltaTime * 0.01f);
    }

    public void SetPlanet(float x, float y, float mass, float speed)
    {
        transform.position = new Vector2(x, y);
        Speed = speed;
        Mass = mass;

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
}
