using UnityEngine;

public class MoveTile : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float maxLifetime = 120f; // Tiempo máximo que puede vivir el tile (en segundos)

    private float lifeTimer = 0f;

    void Update()
    {
        // Movimiento hacia atrás
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // Contador de vida
        lifeTimer += Time.deltaTime;

        if (lifeTimer >= maxLifetime)
        {
            Destroy(gameObject); 
        }
    }
}
