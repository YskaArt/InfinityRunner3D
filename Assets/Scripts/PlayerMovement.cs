using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float laneDistance = 4f;
    public float laneChangeSpeed = 10f;
    public float jumpForce = 8f;
    public float slideDuration = 1f;

    private CharacterController controller;
    private Vector3 direction;
    private int currentLane = 1;
    private bool isSliding = false;

    private Animator animator;

    // Hitbox para el slide
    private float originalHeight;
    private Vector3 originalCenter;
    public float slideHeight = 1f;
    public Vector3 slideCenterOffset = new Vector3(0f, -0.5f, 0f);

    [Header("Audio")]
    public AudioClip footstepSound;
    public AudioClip slideSound;
    public AudioClip deathSound;
    public AudioClip jumpSound;

    private AudioSource audioSource;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        originalHeight = controller.height;
        originalCenter = controller.center;

        audioSource = GetComponent<AudioSource>();
        if (!audioSource) audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            direction.y = -1f;

            animator.SetBool("isJumping", false);
            animator.SetBool("isRunning", !isSliding);

            if (!isSliding && !audioSource.isPlaying && footstepSound)
            {
                PlaySound(footstepSound, true); // loop pisadas
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jumpForce;
                animator.SetBool("isJumping", true);
                animator.SetBool("isRunning", false);
                audioSource.Stop(); // Cortamos las pisadas al saltar
                PlaySound(jumpSound, false); // Sonido del salto
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && !isSliding)
            {
                StartCoroutine(Slide());
            }
        }
        else
        {
            direction.y += Physics.gravity.y * Time.deltaTime * 2;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
            currentLane = Mathf.Min(currentLane + 1, 2);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            currentLane = Mathf.Max(currentLane - 1, 0);

        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (currentLane == 0) targetPosition += Vector3.left * laneDistance;
        else if (currentLane == 2) targetPosition += Vector3.right * laneDistance;

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = (targetPosition - transform.position).x * laneChangeSpeed;
        moveDirection.y = direction.y;
        moveDirection.z = direction.z;

        controller.Move(moveDirection * Time.deltaTime);
    }

    System.Collections.IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        animator.SetBool("isRunning", false);

        controller.height = slideHeight;
        controller.center = originalCenter + slideCenterOffset;

        PlaySound(slideSound, false); // Reproducir sonido de deslizamiento
        yield return new WaitForSeconds(slideDuration);

        controller.height = originalHeight;
        controller.center = originalCenter;

        animator.SetBool("isSliding", false);
        isSliding = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            Die();
        }
    }


    public void Die()
    {
        GameManager.Instance.GameOver();
        animator.SetTrigger("Die");
        audioSource.Stop();
        PlaySound(deathSound, false);
        enabled = false;
    }

    void PlaySound(AudioClip clip, bool loop)
    {
        if (clip == null) return;

        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();
    }
    

    



}
