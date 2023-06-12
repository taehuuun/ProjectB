using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private float mass;

    private const float GravityConst = 1f;
    private const float SpeedOfLight = 3f;

    private float EventHorizonRadius => (2 * GravityConst * mass / (SpeedOfLight * SpeedOfLight));

    private void Start()
    {
        Debug.Log(EventHorizonRadius);
    }

    private void Update()
    {
        float scaledRadius = EventHorizonRadius;
        transform.localScale = new Vector3(scaledRadius, scaledRadius, scaledRadius);
    }
    
    public void InteractPlanet(Planet planet)
    {
        float distance = Vector2.Distance(this.transform.position, planet.transform.position);

        Vector2 direction = (this.transform.position - planet.transform.position).normalized;
        
        float force = (GravityConst * mass * planet.Mass) /  (distance * distance);
        planet.Velocity += direction * force;

        if (distance < EventHorizonRadius)
        {
            planet.gameObject.SetActive(false);
            Debug.Log("흡수 됨");
        }
    }
}