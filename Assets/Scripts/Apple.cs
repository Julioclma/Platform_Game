using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    private CircleCollider2D CircleCollider2D;
    public GameObject Collected;
    private int Score = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        CircleCollider2D = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            SpriteRenderer.enabled = false;
            CircleCollider2D.enabled = false;
            Collected.SetActive(true);
            //Soma coleta ao score do controlador
            GameController.GameControllerInstance.TotalScore += Score;
            GameController.GameControllerInstance.UpdateScoreText();
            
            Destroy(gameObject, 0.2f);
        }
    }
}
