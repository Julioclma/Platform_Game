using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D RigiBody;
    private Animator Animator;
    private Transform Transform;
    public bool IsJumping;
    public bool DoubleJumping;
    public int DoubleJumpingPercentil;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RigiBody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

    }

    public float DoubleJumpingValue()
    {
        return (float)DoubleJumpingPercentil / 100;
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
            Transform.position += movement * Time.deltaTime * Speed;
            Animator.SetBool("walk", true);
            PlayerDirection(horizontalInput);
            return;
        }

        Animator.SetBool("walk", false);
    }

    void PlayerDirection(float horizontalInput)
    {
        if (horizontalInput > 0) // Looking for right
        {
            Transform.eulerAngles = new Vector3(0f, 0f, 0f);
            return;
        }

        if (horizontalInput < 0) // Looking for left
        {
            Transform.eulerAngles = new Vector3(0f, 180f, 0f);
            return;
        }
    }

    void Jump()
    {
        if (
        Input.GetButtonDown("Jump")
        )
        {
            Animator.SetBool("jump", true);
            Animator.SetBool("walk", false);

            if (!IsJumping)
            {
                RigiBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                DoubleJumping = true;
                return;
            }

            if (DoubleJumping)
            {
                RigiBody.AddForce(new Vector2(0f, (JumpForce * DoubleJumpingValue())), ForceMode2D.Impulse);
                DoubleJumping = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.layer == 8)
        {
            IsJumping = false;
            Animator.SetBool("jump", false);
        }

        if (collision2D.gameObject.tag == "Spike")
        {
            GameController.GameControllerInstance.GameOver();
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.layer == 8)
        {
            IsJumping = true;
        }
    }
}
