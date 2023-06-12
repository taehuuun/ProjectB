using UnityEngine;

public class Planet : MonoBehaviour
{
    public float Speed { get; private set; }
    public float Mass { get; private set; }
    public Vector2 Velocity { get;  set; }

    private BlackHole _blackHole;

    public void SetBlackHole(BlackHole blackHole)
    {
        _blackHole = blackHole;

        Vector2 direction = (blackHole.transform.position - transform.position).normalized;
        Velocity = direction * Speed;
    }

    private void Update()
    {
        transform.position += (Vector3)Velocity * Time.deltaTime;
    }
}
