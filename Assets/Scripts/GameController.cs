using Praticando_Game_2D.Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int TotalScore;
    public static GameController GameControllerInstance;
    public TextMeshProUGUI ScoreText;
    public GameObject GameOverObject = null;
    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameControllerInstance = this;
        if (GameOverObject != null)
        {
            GameOverObject.SetActive(false);
        }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (SceneManager.sceneCountInBuildSettings > nextScene)
        {
            //atualiza global score
            GlobalPontuation.Instance.UpdateScore(TotalScore);
            Debug.Log(GlobalPontuation.Instance.Score);
            //carrega prox cena
            SceneManager.LoadScene(nextScene);
        }
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - SceneManager.sceneCountInBuildSettings);
    }
}
