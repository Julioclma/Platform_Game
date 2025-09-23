using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Praticando_Game_2D.Assets.Scripts
{
    public class GlobalPontuation : MonoBehaviour
    {
        public static GlobalPontuation Instance;
        public int Score = 0;
        public TextMeshProUGUI ScoreText;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            DontDestroyOnLoad(gameObject);
            ResetPontuationWhenFirstScene();
            ShowPontuationWhenCreditScene();
        }

        private void ResetPontuationWhenFirstScene()
        {
            if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - SceneManager.sceneCountInBuildSettings))
            {
                Instance.Score = 0;
            }
        }

        private void ShowPontuationWhenCreditScene()
        {
            if (SceneManager.GetActiveScene().name == "Creditos")
            {
                ScoreText.text = Instance.Score.ToString();
            }
        }

        public void UpdateScore(int value)
        {
            Instance.Score += value;
        }
    }
}