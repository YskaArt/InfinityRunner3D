using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOver = false;

    public GameObject gameOverUI;
    public GameObject Score;// Asigna el panel del menú desde el inspector
    public TMPro.TextMeshProUGUI scoreText; // Asigna el texto de score desde el inspector

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        StartCoroutine(ShowGameOverMenu());
    }

    System.Collections.IEnumerator ShowGameOverMenu()
    {
        yield return new WaitForSeconds(2.5f); // Tiempo para que termine la animación

        if (scoreText != null)
        {
            scoreText.text = "Puntaje: " + Mathf.FloorToInt(ScoreManager.Instance.GetScore());
        }

        Score.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
