using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    // Movimiento lateral
    private int currentLane = 1; // 0 = izquierda (-4), 1 = centro (0), 2 = derecha (4)
    private float laneDistance = 4f; // distancia entre carriles
    private float moveSpeed = 10f;   // velocidad de desplazamiento lateral

    // Salto
    public float jumpForce = 3f;
    public float gravity = 6f;
    private float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLane = Mathf.Max(0, currentLane - 1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane = Mathf.Min(2, currentLane + 1);
        }

        
        if (controller.isGrounded)
        {
            verticalVelocity = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

       
        float targetX = (currentLane - 1) * laneDistance;
        float newX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * moveSpeed);

        Vector3 move = new Vector3(newX - transform.position.x, verticalVelocity, 0f); 

        
        controller.Move(move);
    }
}

