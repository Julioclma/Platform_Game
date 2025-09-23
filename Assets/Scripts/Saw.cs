using UnityEngine;

public class Saw : MonoBehaviour
{
    public float Speed;
    public float MoveTime;
    private bool DirectionRight = true;
    private float Timer;
    private Transform Transform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DirectionRight)
        {
            //serra para direita
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        else
        {
            //serra para esquerda
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }

        Timer += Time.deltaTime;
        if (Timer >= MoveTime)
        {
            DirectionRight = !DirectionRight;
            Timer = 0f;
        }

    }
}
