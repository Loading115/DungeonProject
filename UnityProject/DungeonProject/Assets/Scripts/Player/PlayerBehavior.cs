using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rB2;
    public Animator anim;

    private Vector2 moveDirection;

    private float lastXDirection;
    private float lastYDirection;

    private void Start()
    {
        lastXDirection = 0;
        lastYDirection = -1;
    }

    private void Update()
    {
        ProcessInput();
        Animations();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void ProcessInput ()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveV = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveH, moveV);

        if (moveDirection.x != 0)
        {
            lastXDirection = moveDirection.x;
            if (moveDirection.y == 0)
            {
                lastYDirection = 0;
            }
            else
            {
                lastYDirection = moveDirection.y;
            }
        }
        if (moveDirection.y != 0)
        {
            lastYDirection = moveDirection.y;
            if (moveDirection.x == 0)
            {
                lastXDirection = 0;
            }
            else
            {
                lastXDirection = moveDirection.x;
            }
        }
    }

    void Movement ()
    {
        rB2.velocity = new Vector2(moveDirection.normalized.x * speed, moveDirection.normalized.y * speed);
    }

    void Animations ()
    {
        anim.SetFloat("AnimMoveX", lastXDirection);
        anim.SetFloat("AnimMoveY", lastYDirection);
    }
}
