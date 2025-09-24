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
    public TextMeshProUGUI GameOverButtonTextObject;
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

    public void GameOver(int actualLife)
    {
        GameOverObject.SetActive(true);
        if (actualLife == 0)
        {
            GameOverButtonTextObject.text = "Menu";
        }
        else
        {
            GameOverButtonTextObject.text = "Restart";
        }
        Destroy(Player);
    }

    public void RestartGame()
    {
        if (GameOverButtonTextObject.text == "Restart")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }

        StartNewGame();
    }

    public void NextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (SceneManager.sceneCountInBuildSettings > nextScene)
        {
            try { PlayerLife.Instance.AddLife(); } catch (System.Exception) { }
            //atualiza global score
            GlobalPontuation.Instance.UpdateScore(TotalScore);
            //carrega prox cena
            SceneManager.LoadScene(nextScene);
        }
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - SceneManager.sceneCountInBuildSettings);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
