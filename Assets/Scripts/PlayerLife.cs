using TMPro;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int Life = 3;
    public static PlayerLife Instance;
    public TextMeshProUGUI LifeQuantidadeUi;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
        SetUiText();

    }

    // Recebe dano
    public void Damage()
    {
        Instance.Life -= 1;
        CheckIfPlayerCanContinueGame();
    }

    public void AddLife()
    {
        if (Instance.Life < 3)
        {
            Instance.Life += 1;
        }
    }

    public void SetUiText()
    {

        LifeQuantidadeUi.text = Instance.Life.ToString();
    }

    private void CheckIfPlayerCanContinueGame()
    {
        int actualLife = Instance.Life;
        if (Instance.Life == 0)
        {
            Instance.Life = 3;
        }
        GameController.GameControllerInstance.GameOver(actualLife);
        // GameController.GameControllerInstance.StartNewGame();
    }
}
