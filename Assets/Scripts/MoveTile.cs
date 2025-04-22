using UnityEngine;

public class MoveTile : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float destroyZPosition = -500f; // Punto detrás del jugador donde ya no se necesita

    void Update()
    {
        if (GameManager.Instance.isGameOver) return;

        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        if (transform.position.z < destroyZPosition)
        {
            Destroy(gameObject);
        }
    }
}

