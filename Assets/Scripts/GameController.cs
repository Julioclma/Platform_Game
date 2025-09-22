using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int TotalScore;
    public static GameController GameControllerInstance;
    public TextMeshProUGUI ScoreText;
    public GameObject GameOverObject;
    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameControllerInstance = this;
        GameOverObject.SetActive(false);
    }

    public void UpdateScoreText()
    {
        ScoreText.text = TotalScore.ToString();
    }

    public void GameOver()
    {
        GameOverObject.SetActive(true);
        Destroy(Player);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextScene)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
