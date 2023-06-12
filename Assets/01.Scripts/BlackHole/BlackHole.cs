using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float Mass { get; private set; }
    public float EventHorizonRadius { get; private set; }

    public void InteractPlanet(Planet planet)
    {
        float distance = Vector2.Distance(this.transform.position, planet.transform.position);

        if (distance < EventHorizonRadius)
        {
            Vector2 direction = (this.transform.position - planet.transform.position).normalized;
            planet.Velocity += direction * (Mass / (distance * distance));
        }
    }
}