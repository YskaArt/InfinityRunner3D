using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float destroyZ = -30f;
    public float speed = 5f;

    void Update()
    {
        // Movimiento hacia -Z (hacia el jugador)
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        

        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }
    }
}
