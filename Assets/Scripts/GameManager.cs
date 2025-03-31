using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject GameOverText;
    [SerializeField] public GameObject restartButton;
    [SerializeField] public GameObject mainMenuButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    PlayerController playerController;
    private int totalScore = 0;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        GameOverText.SetActive(false);
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);

        IncreaseScore(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GameOver()
    {
        playerController.isGameOver = true;
        GameOverText.SetActive(true);
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
    }

    public void IncreaseScore(int score)
    {
        totalScore += score;
        scoreText.text = $"Score : {totalScore}";
    }

}
