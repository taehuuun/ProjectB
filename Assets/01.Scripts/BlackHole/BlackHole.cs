using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private Transform influenceRadius;
    [SerializeField] private float mass;
    [SerializeField] private float influenceRadiusValue;
    
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
        
        influenceRadius.localScale = new Vector3(influenceRadiusValue, influenceRadiusValue, 1);
    }
    
    public void InteractPlanet(Planet planet)
    {
        float distance = Vector2.Distance(this.transform.position, planet.transform.position);

        if (distance < influenceRadiusValue * 0.7f)
        {
            Vector2 direction = (this.transform.position - planet.transform.position).normalized;
            float force = (GravityConst * mass * planet.Mass) /  (distance * distance);
            planet.Velocity += direction * (force * 0.5f);

            if (distance < EventHorizonRadius)
            {
                planet.gameObject.SetActive(false);
                Debug.Log("흡수 됨");
            }
        }
    }
}