using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(ScoreManager.Instance.GetScore());
    }
}
