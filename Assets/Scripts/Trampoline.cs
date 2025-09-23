using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float JumpForce;
    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision2d)
    {
        if (collision2d.gameObject.tag == "Player")
        {
            Jump(collision2d);
        }
    }

    void Jump(Collision2D collision2d)
    {
        collision2d.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        Animator.SetTrigger("jump");
    }
}
