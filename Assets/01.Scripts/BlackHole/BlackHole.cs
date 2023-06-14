using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private Transform blackHoleSprite;
    [SerializeField] private LineRenderer lineRenderer;
    
    [SerializeField] private float mass;
    [SerializeField] private float influenceRadiusValue;
    
    private const float GravityConst = 5f;
    private const float SpeedOfLight = 30f;

    private float EventHorizonRadius => (2 * GravityConst * mass / SpeedOfLight);

    private void Update()
    {
        float convertRadius = influenceRadiusValue * 0.3f;
        DrawInfluenceRadius(convertRadius);
        blackHoleSprite.localScale = new Vector3(EventHorizonRadius, EventHorizonRadius, 1);
    }
    
    public void InteractPlanet(Planet planet)
    {
        float distance = Vector2.Distance(this.transform.position, planet.transform.position);

        if (distance > influenceRadiusValue * 0.3f)
        {
            return;
        }
        
        Vector2 direction = (this.transform.position - planet.transform.position).normalized;
        
        float force = (GravityConst * mass * planet.Mass) /  (distance * distance);
        planet.Velocity += direction * (force * 0.5f);

        if (distance < EventHorizonRadius)
        {
            planet.gameObject.SetActive(false);
            Debug.Log("흡수 됨");
        }
    }

    private void DrawInfluenceRadius(float radius)
    {
        int segments = 50;
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = true;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;

        float angle = 0f;
        
        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius; 
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            lineRenderer.SetPosition(i,  transform.position + new Vector3(x, y, 0));
        
            angle += 360f / segments;
        }
    }
}