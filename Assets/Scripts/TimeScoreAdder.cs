using UnityEngine;

public class TimeScoreAdder : MonoBehaviour
{
    public float pointsPerSecond = 5f;

    void Update()
    {
        if (GameManager.Instance.isGameOver) return;

        ScoreManager.Instance.AddScore(pointsPerSecond * Time.deltaTime);
    }
}
