using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    public float Speed;
    public Transform RightCol;
    public Transform LeftCol;
    public Transform HeadPoint;
    private bool Colliding;
    public LayerMask Layer;
    public BoxCollider2D BoxCollider2D;
    public CircleCollider2D CircleCollider2D;
    private bool PlayerDie = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.linearVelocityX = Speed;

        Colliding = Physics2D.Linecast(RightCol.position, LeftCol.position, Layer);

        if (Colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            Speed *= -1f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - HeadPoint.position.y;

            if (height > 0 && !PlayerDie)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                Speed = 0;
                Animator.SetTrigger("die");
                BoxCollider2D.enabled = false;
                CircleCollider2D.enabled = false;
                Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.18f);
            }
            else
            {
                PlayerDie = true;
                GameController.GameControllerInstance.GameOver();
            }
        }
    }
}
