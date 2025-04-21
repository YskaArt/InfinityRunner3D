using UnityEngine;

public class TimeScoreAdder : MonoBehaviour
{
    public float pointsPerSecond = 5f;

    void Update()
    {
        ScoreManager.Instance.AddScore(pointsPerSecond * Time.deltaTime);
    }
}
