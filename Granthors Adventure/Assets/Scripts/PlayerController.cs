using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public Animator animator;

    float moveSpeed = 5.0f;

    float attackTime = 0.25f;
    float attackCounter = 0.15f;
    bool isAttacking;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("HorizontalMove", movement.x);
        animator.SetFloat("VerticalMove", movement.y);
        animator.SetFloat("MoveSpeed", movement.sqrMagnitude);

        if (movement.x == -1 || movement.x == 1 || movement.y == -1 || movement.y == 1)
        {
            animator.SetFloat("HorizontalFace", movement.x);
            animator.SetFloat("VerticalFace", movement.y);
        }

        if (isAttacking)
        {
            rigidbody.velocity = Vector2.zero;

            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetBool("IsAttacking", isAttacking = false);
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            attackCounter = attackTime;
            animator.SetBool("IsAttacking", isAttacking = true);
        }

    }

    // FixedUpdate is called once per frame at a fixed rate (50 frames/sec)
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}