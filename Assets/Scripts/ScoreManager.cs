using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private float currentScore = 0;

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); 
    }

    public void AddScore(float amount)
    {
        currentScore += amount;
        Debug.Log("Puntaje: " + Mathf.FloorToInt(currentScore));
    }

    public float GetScore()
    {
        return currentScore;
    }
}
