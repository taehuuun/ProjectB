using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private float mass;

    private const float GravityConst = 6.67430e-11f;
    private const float SppedOfLight = 299792458f;

    private float EventHorizonRadius => (2 * GravityConst * mass / (SppedOfLight * SppedOfLight));

    public void InteractPlanet(Planet planet)
    {
        float distance = Vector2.Distance(this.transform.position, planet.transform.position);

        Vector2 direction = (this.transform.position - planet.transform.position).normalized;
        planet.Velocity += direction * (mass / (distance * distance));
        
        if (distance < EventHorizonRadius)
        {
            Debug.Log("흡수 됨");
        }
    }
}