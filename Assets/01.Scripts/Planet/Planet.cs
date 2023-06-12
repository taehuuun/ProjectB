using UnityEngine;

public class Planet : MonoBehaviour
{
    public float Speed { get; private set; }
    public float Mass { get; private set; }
    public Vector2 Velocity { get;  set; }

    private BlackHole _blackHole;

    public void SetPlanet(float mass, float speed)
    {
        Speed = speed;
        Mass = mass;
        
        float direction = Random.Range(0f, 360f);
        Vector2 randomDirection = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction));

        Velocity = randomDirection.normalized * Speed;
    }

    private void Update()
    {
        transform.position += (Vector3)Velocity * Time.deltaTime;
    }
}
