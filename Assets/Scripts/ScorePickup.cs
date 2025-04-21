using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    public int scoreAmount = 10; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(scoreAmount);
            Destroy(gameObject); 
        }
    }
}
